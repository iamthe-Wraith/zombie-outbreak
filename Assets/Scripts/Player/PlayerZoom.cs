using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    FirstPersonController fpController;

    void OnZoom()
    {
        ToggleZoom();
    }

    void Start()
    {
        fpController = GetComponent<FirstPersonController>();
    }

    private void ToggleZoom()
    {
        foreach (GameObject weapon in weapons)
        {
            if (weapon.activeInHierarchy)
            {
                WeaponZoom weaponZoom = weapon.GetComponent<WeaponZoom>();
                if (weaponZoom != null)
                {
                    fpController.isZoomed = !fpController.isZoomed;
                    weaponZoom.ToggleZoom();
                }
            }
        }
    }
}
