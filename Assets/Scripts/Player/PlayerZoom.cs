using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{
    public float RotationSpeed = 1.0f;
    FirstPersonController fpController;

    WeaponZoom[] weapons;

    void OnZoom()
    {
        ToggleZoom();
    }

    void Start()
    {
        fpController = GetComponent<FirstPersonController>();
        weapons = GetComponentsInChildren<WeaponZoom>();
    }

    private void ToggleZoom()
    {
        fpController.isZoomed = !fpController.isZoomed;
        foreach (WeaponZoom weapon in weapons)
        {
            weapon.ToggleZoom();
        }
    }
}
