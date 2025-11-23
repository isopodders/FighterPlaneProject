using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime * 8f);
        if (transform.position.y > 6.5f)
        {
            Destroy(this.gameObject);
        }
    }
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
