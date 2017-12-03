using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadGun : MonoBehaviour {
    public int ammoInMagCurrent;
    public int magSize;
    public int maxAmmo;

    public int ammoPerShot;
    
    
    private FireArm firearmScript;

    public bool reloadingATM;
    

    public GameObject gunCanvas;
    public GameObject gunCanvasCurrentAmmo;
    public GameObject gunCanvasMaxAmmo;

    private void Start()
    {
        firearmScript = GetComponent<FireArm>();
        


        gunCanvasCurrentAmmo.GetComponent<Text>().text = ammoInMagCurrent.ToString();

        if(ammoPerShot <= 0)
        {
            gunCanvas.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Reload") && ammoInMagCurrent != magSize && firearmScript.myReload != null && !reloadingATM)
        {
            firearmScript.anim.SetTrigger("tReload");
            reloadingATM = true;
        }

        if(firearmScript.myReload == null)
        {
            gunCanvasCurrentAmmo.GetComponent<Text>().text = "-";
        }



    }

    



    public void SubtractAmmo()
    { 
        if (firearmScript.myReload != null)
        {
            ammoInMagCurrent = ammoInMagCurrent - ammoPerShot;
            gunCanvasCurrentAmmo.GetComponent<Text>().text = ammoInMagCurrent.ToString();
        }
        
    }

    public void RefillAmmo()
    {
        
        gunCanvasCurrentAmmo.GetComponent<Text>().text = magSize.ToString();
        ammoInMagCurrent = magSize;
        reloadingATM = false;
    }

    public void EmptyAmmo()
    {
        ammoInMagCurrent = 0;
    }
}
