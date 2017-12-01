using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour {

    private Transform gunOrigin;

    void Start()
    {
        gunOrigin = this.gameObject.transform;
    }

    void Update()
    {
        ReturnToOrigin();
    }

    void ReturnToOrigin()
    {
        transform.position = Vector3.Lerp(transform.position, gunOrigin.position, Time.deltaTime * 0.1f);
    }
}
