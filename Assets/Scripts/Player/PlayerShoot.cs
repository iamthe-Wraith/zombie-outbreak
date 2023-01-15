using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    Weapon[] weapons;

    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
    }

    private void Shoot()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.Shoot();
        }
    }
}
