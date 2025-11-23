using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : MonoBehaviour
{


    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1,1), -4f, 0) * Time.deltaTime * 3f);
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
    //removed due to redundancies in damaging the player
            //    if (player != null)   // If found, deal damage
            //    {
            //        player.TakeDamage(damageAmount);
            //    }

            Destroy(gameObject);  // Enemy dies when touching player
        }
    }
}
