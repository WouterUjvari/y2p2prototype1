using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour
{

    public GameObject projectile;
    public Transform muzzle;
    public float force;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject g = Instantiate(projectile, muzzle);
            g.transform.SetParent(null);
            g.GetComponent<Rigidbody>().AddForce(transform.forward * force);


        }
    }
}
