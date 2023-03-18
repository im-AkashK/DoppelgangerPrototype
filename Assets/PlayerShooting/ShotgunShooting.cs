using UnityEngine;
using UnityEngine.UI;

public class ShotgunShooting : MonoBehaviour
{
    public GameObject shotgunProjectile; // Assign a particle system for the shotgun projectile
    public Transform shootPoint; // Assign the transform where the shotgun projectile will spawn
    public float projectileSpeed = 20f; // Set the speed of the projectile
    public float projectileSpread = 15f; // Set the spread of the projectile
    public float projectileLifetime = .2f;

    private int ammoCount = 6; // Set the initial ammo count
    public Text ammoText;

    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
{
    if (Input.GetButtonDown("Fire1") && ammoCount > 0)
    {
        // Play the muzzle flash particle system

        // Spawn multiple shotgun projectile particle systems
        for (int i = 0; i < 4; i++)
        {
            var projectile = Instantiate(shotgunProjectile, shootPoint.position, shootPoint.rotation);

            // Set the rotation of each projectile to a spread angle
            projectile.transform.rotation *= Quaternion.Euler(Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread), 0);
            UpdateAmmoText();

            Destroy(projectile, projectileLifetime);
        }

        // Decrement the ammo count
        ammoCount--;
    }

    if (ammoCount == 0)
    {
        Reload();
    }
}



    public void Reload()
    {
        ammoCount = 6; // Reset the ammo count
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = ammoCount.ToString();
    }
}
