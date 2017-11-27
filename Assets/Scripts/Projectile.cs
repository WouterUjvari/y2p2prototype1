using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public bool destroyOnImpact;
    public bool dropOnImpact;
    public bool stickOnImpact;
    public GameObject myFriend;
    public float extraForce;
    public float lifetime;
    public float lifetimeAfterDrop;
    private Quaternion impactRotation;

    private bool live;

    public bool useGravity;



    void Start()
    {
        EnforceMinimumLifetimes();

        if (useGravity)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void EnforceMinimumLifetimes()
    {
        if (lifetime < 3)
        {
            lifetime = 3;
        }
        if (lifetimeAfterDrop < 3)
        {
            lifetimeAfterDrop = 3;
        }
    }

    private void Update()
    {


        if(live)
        {
            lifetime -= Time.deltaTime;
            impactRotation = transform.rotation;
        }
        else
        {
            lifetimeAfterDrop -= Time.deltaTime;
        }
        
        if(lifetime <= 0 || lifetimeAfterDrop <= 0)
        {
            Destroy(this.gameObject);
        }

        
    }

    public void OnCollisionStay(Collision other)
    {
        live = false;

        if (destroyOnImpact)
        {
            Destroy(myFriend);
            Destroy(this.gameObject);
        }

        if (dropOnImpact)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(myFriend);
            GetComponent<MeshRenderer>().enabled = true;
        }

        if (!destroyOnImpact || !dropOnImpact)
        {
            Destroy(myFriend);
            GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.SetParent(other.transform);
            
        }
            
    }




}
