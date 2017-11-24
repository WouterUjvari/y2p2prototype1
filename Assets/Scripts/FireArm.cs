using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour
{
    public Aim myAim;
    public bool semiAutomatic;
    public GameObject projectile;
    public Transform muzzleFake;
    public Transform muzzleReal;
    public float force;

    void Update()
    {
        Debug.DrawLine(muzzleFake.transform.position, myAim.myTarget, Color.blue);

        if (semiAutomatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                
            }
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                
            }
        }
    }

    void Shoot()
    {
        //Fake
        GameObject myProjectile = Instantiate(projectile, muzzleFake.transform.position, Quaternion.identity);      
        myProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleFake.transform.position).normalized * force, ForceMode.Impulse);       
        print("pew");

        //Real

        Instantiate(myProjectile, muzzleReal.transform.position, Quaternion.identity);

    }
  
}
