using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    // This function is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit something: " + other.gameObject.name);
        // Check if the object we hit has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit an Enemy! Destroying...");
            // Destroy the enemy object
            Destroy(other.gameObject);

            // Destroy the bullet object after impact
            Destroy(this.gameObject);
        }
    }
}