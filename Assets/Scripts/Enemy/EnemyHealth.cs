using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 10f;
    public float HitPoints { get { return hitPoints; } }

    [SerializeField]
    GameObject hitEffect;

    private bool isAlive = true;
    public bool IsAlive { get { return isAlive; } }

    private void ProcessDeath()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage, RaycastHit hit)
    {
        if (!isAlive) return;

        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal), transform);
        Destroy(impact, 2f);

        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            ProcessDeath();
        }
    }
}
