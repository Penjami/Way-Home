using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour
{
    [SerializeField] List<Renderer> _defaultRenderers = new List<Renderer>(); 
    [SerializeField] List<Renderer> _brokenRenderers = new List<Renderer>(); 
    private PartStatus _partStatus = PartStatus.OK;

    public PartStatus GetPartStatus => _partStatus;

    public PartType partType;

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

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void OnMovement()
    {
        switch (partType)
        {
            case PartType.HULL:
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.COCKPIT: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.CONTAINER: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.GARDEN: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.GENERATOR: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.SATELLITE: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.THRUSTER: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.WATERTANK: 
                if(_partStatus == PartStatus.OK) {
                    
                } else {
                    
                }
            break;
            case PartType.WINGS: 
                
            break;
        }
    }
}

public enum PartStatus {
    OK, BROKEN
}

public enum PartType {
    HULL, COCKPIT, CONTAINER, GARDEN, GENERATOR, SATELLITE, THRUSTER, WATERTANK, WINGS
}
