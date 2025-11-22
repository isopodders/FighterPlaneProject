using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = -1;

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
            FindObjectOfType<ScoreManager>().AddScore(1);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            //  DAMAGE THE PLAYER HERE
            Player player = other.GetComponent<Player>();  // Try to get the Player script

            if (player != null)   // If found, deal damage
            {
                player.TakeDamage(damageAmount);
            }

            Destroy(gameObject);  // Enemy dies when touching player
        }
    }
}
