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
    //public Transform hitScanMuzzle;
    public float force;
    private float timer;
    public float fireRate;

    public Animator anim;
    public Animator camAnim;

    public AudioSource Gunshot;
    public AudioSource GunReceive;
    public AudioSource GunSlide;

    public ReloadGun myReload;

    public GameObject debugSphere;

    public GameObject flash;

    public GameObject casing;
    public Transform casingSpawner;


    void Start()
    {
        anim = GetComponent<Animator>();
        myReload = GetComponent<ReloadGun>();
    }



    


    
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

    public void Shoot()
    {
        if (myReload != null )
        {
            if ( myReload.ammoInMagCurrent > 0 && !myReload.reloadingATM)
            {
                anim.SetTrigger("tShoot");
                camAnim.SetTrigger("pCamerakick");
                HitScan();
                timer = 1 / fireRate;
                print("pew");

                /*
                //Fake
                GameObject myProjectile = Instantiate(projectile, muzzleFake.transform.position, muzzleFake.rotation);
                myProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleFake.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
                myProjectile.GetComponent<BoxCollider>().enabled = false;
                myProjectile.name = myProjectile.name + ("fake");

                //Real        
                GameObject myFakeProjectile = Instantiate(projectile, muzzleReal.transform.position, muzzleReal.rotation);
                myFakeProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleReal.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
                //myFakeProjectile.GetComponent<MeshRenderer>().enabled = false;
                myFakeProjectile.GetComponent<BoxCollider>().enabled = true;
                myFakeProjectile.name = myFakeProjectile.name + ("real");


                myFakeProjectile.GetComponent<Projectile>().myFriend = myProjectile;
                */
            }

            else
            {
                anim.SetTrigger("tHammer");
            }
        }
        
        else
        {
            anim.SetTrigger("tShoot");

            timer = 1 / fireRate;
            print("pew");
            //HitScan();

             /*
            //Fake

            GameObject myProjectile = Instantiate(projectile, muzzleFake.transform.position, muzzleFake.rotation);
            myProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleFake.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
            myProjectile.GetComponent<BoxCollider>().enabled = false;
            myProjectile.name = myProjectile.name + ("fake");

            //Real        
            GameObject myFakeProjectile = Instantiate(projectile, muzzleReal.transform.position, muzzleReal.rotation);
            myFakeProjectile.GetComponent<Rigidbody>().AddForce((myAim.myTarget - muzzleReal.transform.position).normalized * (force + projectile.GetComponent<Projectile>().extraForce), ForceMode.Impulse);
            //myFakeProjectile.GetComponent<MeshRenderer>().enabled = false;
            myFakeProjectile.GetComponent<BoxCollider>().enabled = true;
            myFakeProjectile.name = myFakeProjectile.name + ("real");


            myFakeProjectile.GetComponent<Projectile>().myFriend = myProjectile;

            */
        }
    }

    public void HitScan()
    {
        print("debug");

        //if(myAim.myTarget != myAim.myDistance.transform.position)
        //{
        //   GameObject myDebugSphere = Instantiate(debugSphere, myAim.myTarget, Quaternion.identity);
        //   Destroy(myDebugSphere, 1);
        //}

        RaycastHit hit;
        if (Physics.Raycast(myAim.gameObject.transform.position, myAim.gameObject.transform.forward, out hit, 1000))
        {
            print(hit.transform.name);

            GameObject myDebugSphere = Instantiate(debugSphere, hit.point, Quaternion.identity);



                myDebugSphere.GetComponent<LineRenderer>().SetPosition(1, myDebugSphere.transform.position);
                myDebugSphere.GetComponent<LineRenderer>().SetPosition(0, muzzleFake.transform.position);
            
            
            

                print("at Distance");

            
            Destroy(myDebugSphere, 0.05f);

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(transform.forward * 100);
            }
        }
        else
        {
            GameObject myDebugSphere = Instantiate(debugSphere, hit.point, Quaternion.identity);
            myDebugSphere.GetComponent<LineRenderer>().SetPosition(1, myAim.myDistance.transform.position);
            myDebugSphere.GetComponent<LineRenderer>().SetPosition(0, muzzleFake.transform.position);
            Destroy(myDebugSphere, 0.05f);
        }




    }

    public void SpawnCasing()
    {
        GameObject mycasing = Instantiate(casing, casingSpawner.position, casingSpawner.transform.rotation);
        Destroy(mycasing, 10);
        mycasing.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up + Vector3.right * Random.Range(13, 15));

    }

    public void PlaySoundGunShot()
    {
        Gunshot.Play();
    }

    public void PlaySoundGunReceive()
    {
        GunReceive.Play();
    }

    public void PlaySoundGunSlide(float pitch)
    {
        GunSlide.pitch = pitch;
        GunSlide.Play();
        
    }

    public void Flare(bool active)
    {
        flash.SetActive(active);
    }

}
