using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    public bool isAttacking;

    public float playerHealth;
    public float playerMaxHealth;

    [SerializeField] PlayerHealthBar playerHealthBar;

    private void Awake()
    {
        playerHealthBar = GetComponentInChildren<PlayerHealthBar>();
    }   

    void Start()
    {
        Time.timeScale = 1f;
        isAttacking = false;
        playerHealthBar.UpdatePlayerHealth(playerHealth, playerMaxHealth);
        playerHealth = 4;
    }

    void Update()
    {
        playerHealthBar.UpdatePlayerHealth(playerHealth, playerMaxHealth);


        if (playerHealth == 0)
        {
            gameOver.PlayerDied();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthPot"))
        {
            playerHealth++;
            Destroy(collision.gameObject);
        }
    }
}
