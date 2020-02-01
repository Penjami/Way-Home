﻿using System.Collections;
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

    Transform _selectedRenderer;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
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
            if(_selectedRenderer != null) {
                foreach(Renderer rend in _selectedRenderer.GetComponentsInChildren<Renderer>()) {
                    foreach (var mat in rend.materials) {
                        mat.EnableKeyword("_EMISSION");
                        mat.SetColor("_EmissionColor", Color.black);
                    }
                }
            }
            if(_selectedRenderer != hit.transform) {
                _selectedRenderer = hit.transform;
                foreach(Renderer rend in _selectedRenderer.GetComponentsInChildren<Renderer>()) {
                    foreach (var mat in rend.materials) {
                        mat.EnableKeyword("_EMISSION");
                        mat.SetColor("_EmissionColor", Color.cyan);
                    }
                }
                partText.text = _selectedRenderer.name;
                var shipPart = _selectedRenderer.GetComponent<ShipPart>();
                statusText.text = "Status: " + _selectedRenderer.GetComponent<ShipPart>().GetPartStatus;
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
        if(_selectedRenderer != null) {
            _selectedRenderer.GetComponent<ShipPart>().SetPartStatus(PartStatus.OK);
        }
    }

    void UnselectShipPart() {
        if(_selectedRenderer != null) {
            foreach(Renderer rend in _selectedRenderer.GetComponentsInChildren<Renderer>()) {
                foreach (var mat in rend.materials) {
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.black);
                }
            }
            _selectedRenderer = null;
            panel.SetActive(false);
        }
    }
}