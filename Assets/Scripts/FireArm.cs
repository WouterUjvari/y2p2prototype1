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
    private float timer;
    public float fireRate;
    

    void Update()
    {
        if (Aim.debugMode)
        {
            Debug.DrawLine(muzzleFake.transform.position, myAim.myTarget, Color.blue);
        }
        if (timer >= 0 )
        {
            timer -= Time.deltaTime;
        }
        
        
        
        if (semiAutomatic)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (timer <= 0)
                {
                    Shoot();
                }

            }
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                if(timer <= 0)
                {
                    Shoot();
                }         
            }
        }
    }

    void Shoot()
    {
        timer = 1/fireRate;
        print("pew");

        //Fake
        GameObject myProjectile = Instantiate(projectile, muzzleFake.transform.position, muzzleFake.rotation);       
        myProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleFake.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
        myProjectile.GetComponent<BoxCollider>().enabled = false;
        myProjectile.name = myProjectile.name + ("fake");       

        //Real        
        GameObject myFakeProjectile = Instantiate(projectile, muzzleReal.transform.position, muzzleReal.rotation);
        myFakeProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget -muzzleReal.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
        myFakeProjectile.GetComponent<MeshRenderer>().enabled = false;
        myFakeProjectile.GetComponent<BoxCollider>().enabled = true;
        myFakeProjectile.name = myFakeProjectile.name + ("real");


        myFakeProjectile.GetComponent<Projectile>().myFriend = myProjectile;


    }
  
}
