using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    
    public GameObject shotgunProjectile; // Assign a particle system for the shotgun projectile
    public Transform shootPoint; // Assign the transform where the shotgun projectile will spawn
    public float projectileSpeed = 20f; // Set the speed of the projectile
    public float projectileSpread = 15f; // Set the spread of the projectile
    public float projectileLifetime = .2f;

    private int ammoCount = 6; // Set the initial ammo count

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            // Play the muzzle flash particle system
           

            // Spawn the shotgun projectile particle system
            var projectile = Instantiate(shotgunProjectile, shootPoint.position, Quaternion.identity);

            // Set the velocity of the projectile
            Vector3 velocity = shootPoint.forward * projectileSpeed;
            velocity = Quaternion.Euler(Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread), 0) * velocity;
            projectile.GetComponent<Rigidbody>().velocity = velocity;

            Destroy(projectile, projectileLifetime);

            // Decrement the ammo count
            ammoCount--;
        }

        if(ammoCount == 0 )
        {
            Reload();
        }
    }

    public void Reload()
    {
        ammoCount = 6; // Reset the ammo count
    }
}
