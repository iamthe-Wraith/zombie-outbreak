using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private StarterAssetsInputs startAssets;
    private Weapon[] weapons;

    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    void Start()
    {
        startAssets = GetComponent<StarterAssetsInputs>();
        weapons = GetComponentsInChildren<Weapon>();
    }

    private void Shoot()
    {
        if (startAssets.IsDisabled) return;
        
        foreach (Weapon weapon in weapons)
        {
            weapon.Shoot();
        }
    }
}
