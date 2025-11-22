using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 3.25f;

    public GameObject bulletPrefab;


    // Health System
    public int maxHealth = 3;
    private int currentHealth;

    public Slider healthSlider;

    void Start()
    {
        playerSpeed = 6f;

        // Set starting health
        currentHealth = maxHealth;

       

        // Initialize slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }


    }

    void Update()
    {
        Movement();
        Shooting();
    }

    // --------------------------
    // SHOOTING
    // --------------------------

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    // --------------------------
    // MOVEMENT
    // --------------------------

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        float bottomLimit = -verticalScreenLimit;
        float topLimit = 0;
        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);
        transform.position = new Vector3(transform.position.x, clampedY, 0);
    }

    // --------------------------
    // COLLISION
    // --------------------------

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Just hit: " + other.tag);
            FindObjectOfType<ScoreManager>().AddScore(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    // --------------------------
    // HEALTH SYSTEM
    // --------------------------

    public void TakeDamage(int amount)
    {
       

        currentHealth -= amount;
        Debug.Log("Player took damage! Health = " + currentHealth);

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        Debug.Log("Player died!");
        // Add death animation, restart scene, UI, etc.
        Destroy(gameObject);
    }
}
