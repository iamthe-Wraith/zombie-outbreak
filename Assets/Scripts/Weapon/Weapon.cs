using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Camera fpCamera;

    [SerializeField]
    [Tooltip("How far this weapon can shoot/reach and still deal damage.")]
    float range = 100f;

    [SerializeField]
    [Tooltip("Is the amount of damage done to a target for each round that hits it.")]
    float damage = 1f;

    [SerializeField]
    [Range(1, 10)]
    [Tooltip("Fire rate is the number of rounds this weapons can fire per second.")]
    int fireRate = 2;

    private float delayBetweenRounds;
    private bool isFiring = false;
    private ParticleSystem[] muzzleFlashParticles;

    void Start()
    {
        delayBetweenRounds = 1f / (float)fireRate;
        muzzleFlashParticles = GetComponentsInChildren<ParticleSystem>();
    }

    public void Shoot()
    {        
        if (!gameObject.activeInHierarchy || isFiring) return;
        StartCoroutine(ProcessShoot());
    }

    private IEnumerator ProcessShoot()
    {
        isFiring = true;

        foreach(ParticleSystem muzzleFlashParticle in muzzleFlashParticles)
        {
            muzzleFlashParticle.Play();
        }

        RaycastHit hit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.TakeDamage(damage, hit);
            }
        }

        yield return new WaitForSeconds(delayBetweenRounds);
        isFiring = false;
    }
}
