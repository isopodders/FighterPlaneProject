using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Increase score ONLY when hit by bullet
            FindObjectOfType<ScoreManager>().AddScore(1);

            Destroy(other.gameObject); // Destroy the bullet
            Destroy(gameObject);       // Destroy the enemy
        }
    }
}
