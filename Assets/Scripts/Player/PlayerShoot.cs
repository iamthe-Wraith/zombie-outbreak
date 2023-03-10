using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    
    private StarterAssetsInputs startAssets;

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
    }

    private void Shoot()
    {
        if (startAssets.IsDisabled) return;
        
        foreach (GameObject weaponObj in weapons)
        {
            Weapon weapon = weaponObj.GetComponent<Weapon>();
            if (weapon == null) return;
            weapon.Shoot();
        }
    }
}
