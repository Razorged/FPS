using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float gunForce;
    public Camera fpsCam;

    private Rigidbody hitObject;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        //makes a variable representing object hit
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
