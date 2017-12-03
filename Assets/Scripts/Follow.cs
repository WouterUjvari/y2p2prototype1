using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform target;
    public float soberness;
    public bool doFollow;

    void FixedUpdate()
    {
        if(doFollow)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, soberness * Time.deltaTime);

        }

    }

    private void LateUpdate()
    {
        if (doFollow)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, soberness * Time.deltaTime);
        }
        
    }
}
