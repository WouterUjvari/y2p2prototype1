using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScriptGun : MonoBehaviour {

    private Animator anim;
    public FireArm fireArmScript;

    void Start()
    {
        anim = GetComponent<Animator>();
        fireArmScript = GetComponent<FireArm>();
    }


 
}


