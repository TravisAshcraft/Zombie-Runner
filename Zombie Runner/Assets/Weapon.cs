using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamerea;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzelFlash;
    [SerializeField] GameObject impactFlash;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRayCast();
        PlayMuzzleFlash();
    }

    private void PlayMuzzleFlash()
    {
        muzzelFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamerea.transform.position, FPCamerea.transform.forward, out hit, range))
        {
            PlayImpactEffect( hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (!target) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void PlayImpactEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(impactFlash, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
        Destroy(impact, 1f);
        
    }
}
