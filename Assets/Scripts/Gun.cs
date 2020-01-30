using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float gunForce;
    public Camera fpsCam;
    public float fireRate = 15f;
    public ParticleSystem muzzleFlash; 

    private Rigidbody hitObject;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        //makes a variable representing object hit
        muzzleFlash.Play();
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.tag =="Enemy")
            {
                Debug.Log(hit.transform.name);
                hitObject = hit.rigidbody;
                hitObject.AddForce(fpsCam.transform.forward * gunForce);
            }
        }

    }
}
