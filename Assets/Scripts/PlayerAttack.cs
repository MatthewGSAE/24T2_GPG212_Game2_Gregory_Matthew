using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController player;

    private EnemyController currentEnemyController; // Store reference to the current enemy

    public ParticleSystem attackparticles;

    private bool canAttack = false;

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentEnemyController != null)
                {
                    player.isAttacking = true;
                    currentEnemyController.TakeDamage();
                    attackparticles.Play();
                    Invoke("StopParticleSystem", 0.8f);
                }
            }
        }
    }

    private void StopParticleSystem()
    {
        attackparticles.Stop();
        player.isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canAttack = true;
            currentEnemyController = collision.gameObject.GetComponent<EnemyController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canAttack = false;
            currentEnemyController = null; // Reset the current enemy reference
        }
    }
}
