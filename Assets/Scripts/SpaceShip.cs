using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private List<ShipPart> _parts = new List<ShipPart>();

    void Awake()
    {
        _parts.AddRange(GetComponentsInChildren<ShipPart>());
    }

    void OnMovement()
    {
        foreach (var part in _parts)
        {
            part.OnMovement();
        }
    }
}
