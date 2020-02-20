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
            Debug.Log("I hit: " + hit.transform.name);
            //TODO: add hit effecfor visual 
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (!target) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
