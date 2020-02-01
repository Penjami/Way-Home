using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShipParts : MonoBehaviour
{

    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _selectedMaterial;


    Renderer _oldSelected;
    Renderer _newSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            SelectShipPart();
        }
    }

    void SelectShipPart() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if ( Physics.Raycast (ray,out hit,100000.0f)) {
            _oldSelected = _newSelected;
            if(_oldSelected != null) {
                _oldSelected.material = _defaultMaterial;
            }
            _newSelected = hit.transform.GetComponent<Renderer>();
            var color = _newSelected.material.color;
            _newSelected.material = _selectedMaterial;
            _newSelected.material.color = color;
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
    }
}
