using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject gun;
    private bool isEnabled;
   
    public Animator anim;
    
    void Update()
    {
        if(isEnabled == false)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(gun.activeSelf)
                {
                    gun.SetActive(false);
                }
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(gun.activeSelf)
                {
                    gun.SetActive(false);
                }
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if(gun.activeSelf)
                {
                    gun.SetActive(false);
                }
            }
            else
            {
                gun.SetActive(true);
                anim.SetBool("GunEnabled" , true);
            }
        }
        else
        {
            gun.SetActive(false);
            anim.SetBool("GunEnabled" , false);
        }
    }

    // This method can be called from other scripts to enable/disable the gun
    public void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
    }
}
