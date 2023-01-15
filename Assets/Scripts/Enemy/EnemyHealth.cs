using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage} damage dealth to {gameObject.name}");
    }
}
