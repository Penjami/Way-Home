using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShipParts : MonoBehaviour
{
    Renderer _selectedRenderer;

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
                foreach (var mat in _selectedRenderer.materials) {
                    mat.SetColor("_EmissionColor", Color.black);
                }
            }
            _selectedRenderer = hit.transform.GetComponent<Renderer>();
            foreach (var mat in _selectedRenderer.materials) {
                mat.SetColor("_EmissionColor", Color.red);
            }
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }
    }
}
