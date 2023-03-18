using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectile : MonoBehaviour
{
   public GameObject firePoint;
   public List<GameObject> vfx = new List<GameObject>();

   public float fireRate = 0.5f;
   public int maxAmmo = 10;
   public float reloadTime = 1.0f;
   public int currentAmmo;
   private float lastShotTime = 0f;
  

   private GameObject effectToSpawn;

   public Text ammoText;

   private bool isReloading = false;

   void Start()
   {
      effectToSpawn = vfx[0];
      currentAmmo = maxAmmo;
      UpdateAmmoText();
   }


   void Update()
   {
      if (currentAmmo == 0)
      {
         Reload();
      }

      if (isReloading)
      {
         return;
      }

      if(Input.GetButton("Fire1") && Time.time > lastShotTime + fireRate)
      {
         if(currentAmmo > 0)
         {
            SpawnVFX();
            lastShotTime = Time.time;
         }
         else
         {
            Reload();
         }
      }

      if (Input.GetKeyDown(KeyCode.R))
      {
         StartCoroutine(ReloadCoroutine());
      }
   }

   void SpawnVFX()
   {
      GameObject vfx;

      if(firePoint!= null)
      {
         vfx = Instantiate(effectToSpawn , firePoint.transform.position , firePoint.transform.rotation);
         currentAmmo--;
         UpdateAmmoText();
         Destroy(vfx , 3f);
        
      }
      else
      {
         Debug.Log("no firepoint");
      }
   }

   IEnumerator ReloadCoroutine()
   {
      isReloading = true;
      Debug.Log("Reloading");
      yield return new WaitForSeconds(reloadTime);
      currentAmmo = maxAmmo;
      UpdateAmmoText();
      isReloading = false;
   }

   void Reload()
   {
      if (currentAmmo == maxAmmo || isReloading)
      {
         return;
      }

      StartCoroutine(ReloadCoroutine());
   }

   void UpdateAmmoText()
   {
      ammoText.text = currentAmmo.ToString();
   }
}
