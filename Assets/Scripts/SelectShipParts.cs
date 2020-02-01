﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShipParts : MonoBehaviour
{
    Transform _selectedRenderer;

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
            } else {
                foreach(Renderer rend in _selectedRenderer.GetComponentsInChildren<Renderer>()) {
                    foreach (var mat in rend.materials) {
                        mat.EnableKeyword("_EMISSION");
                        mat.SetColor("_EmissionColor", Color.black);
                    }
                }
                _selectedRenderer = null;
            }

            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
    }
}
