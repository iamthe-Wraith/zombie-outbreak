using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    private int currentWeapon = 0;

    void OnSelectWeapon1()
    {
        SetWeaponByIndex(1);
    }

    void OnSelectWeapon2()
    {
        SetWeaponByIndex(2);
    }

    void OnSelectWeapon3()
    {
        SetWeaponByIndex(3);
    }

    void OnSelectWeapon4()
    {
        SetWeaponByIndex(4);
    }

    void OnSelectWeapon5()
    {
        SetWeaponByIndex(5);
    }

    void OnSelectWeapon6()
    {
        SetWeaponByIndex(6);
    }

    void OnSelectWeapon7()
    {
        SetWeaponByIndex(7);
    }

    void OnSelectWeapon8()
    {
        SetWeaponByIndex(8);
    }

    void OnSelectWeapon9()
    {
        SetWeaponByIndex(9);
    }

    void OnNextWeapon()
    {
        SetActiveWeapon(currentWeapon + 1);
    }

    void OnPrevWeapon()
    {
        SetActiveWeapon(currentWeapon - 1);
    }

    void Start()
    {
        currentWeapon = 0;
    }

    private void SetWeaponByIndex(int index)
    {
        if (weapons.Length < index) return;
        SetActiveWeapon(index - 1);
    }

    private void SetActiveWeapon(int index)
    {
        currentWeapon = index;
        
        if (currentWeapon < 0)
        {
            currentWeapon = weapons.Length - 1;
        }

        if (currentWeapon >= weapons.Length)
        {
            currentWeapon = 0;
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeapon);
        }
    }
}
