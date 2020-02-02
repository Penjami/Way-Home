using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShipPartManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI partText;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject fixButton;

    ShipPart _selectedPart;
    MasterScript _masterScript;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        _masterScript = FindObjectOfType<MasterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            SelectShipPart();
        }

        if(Input.GetMouseButtonDown(1)) {
            UnselectShipPart();
        }
    }

    void SelectShipPart() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if ( Physics.Raycast (ray,out hit,100000.0f)) {
            if(_selectedPart != null) {
                foreach(Renderer rend in _selectedPart.GetAllMeshRenderers()) {
                    foreach (var mat in rend.materials) {
                        mat.EnableKeyword("_EMISSION");
                        mat.SetColor("_EmissionColor", Color.black);
                    }
                }
                _selectedPart.isSelected = false;
            }
            var newPart = hit.transform.GetComponent<ShipPart>();
            if(_selectedPart != newPart) {
                _selectedPart = newPart;
                _selectedPart.isSelected = true;
                foreach(Renderer rend in _selectedPart.GetAllMeshRenderers()) {
                    foreach (var mat in rend.materials) {
                        mat.EnableKeyword("_EMISSION");
                        mat.SetColor("_EmissionColor", Color.cyan);
                    }
                }
                partText.text = _selectedPart.name;
                var shipPart = _selectedPart.GetComponent<ShipPart>();
                statusText.text = "Status: " + _selectedPart.GetComponent<ShipPart>().GetPartStatus;
                panel.SetActive(true);
                if(shipPart.GetPartStatus == PartStatus.OK) {
                    fixButton.SetActive(false);
                    panel.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 200);
                } else {
                    fixButton.SetActive(true);
                    panel.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
                }
            } else {
                UnselectShipPart();
            }

            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
    }

    public void OnFixButtonPress() {
        if(_selectedPart != null) {
            if(_masterScript.storyResources.getResource("metal")>=10) {
                _selectedPart.SetPartStatus(PartStatus.OK);
                _masterScript.storyResources.addResource("metal", -10);
            }
        }
    }

    void UnselectShipPart() {
        if(_selectedPart != null) {
            foreach(Renderer rend in _selectedPart.GetAllMeshRenderers()) {
                foreach (var mat in rend.materials) {
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.black);
                }
            }
            _selectedPart.isSelected = false;
            _selectedPart = null;
            panel.SetActive(false);
        }
    }
}
