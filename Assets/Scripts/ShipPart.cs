using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    [SerializeField] List<Renderer> _defaultRenderers = new List<Renderer>(); 
    [SerializeField] List<Renderer> _brokenRenderers = new List<Renderer>(); 
    private PartStatus _partStatus = PartStatus.OK;

    public PartStatus GetPartStatus => _partStatus;

    public void SetPartStatus(PartStatus status) {
        if (status == PartStatus.OK) {
            foreach ( var item in _defaultRenderers)
            {
                item.enabled = true;
            }
            foreach ( var item in _brokenRenderers)
            {
                item.enabled = false;
            }
        } else {
            foreach ( var item in _defaultRenderers)
            {
                item.enabled = false;
            }
            foreach ( var item in _brokenRenderers)
            {
                item.enabled = true;
            }
        }
    }
}

public enum PartStatus {
    OK, BROKEN
}
