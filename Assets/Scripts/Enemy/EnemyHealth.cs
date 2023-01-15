using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 10f;
    public float HitPoints { get { return hitPoints; } }

    private bool isAlive = true;
    public bool IsAlive { get { return isAlive; } }

    private void ProcessDeath()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage, RaycastHit hit)
    {
        if (!isAlive) return;

        Debug.Log($"{hit.transform.name} takes {damage} damage");

        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            ProcessDeath();
        }
    }
}
