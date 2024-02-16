using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerController player;

    public EnemyController enemy;

    public ParticleSystem attackparticles;

    private bool canAttack = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.isAttacking = true;
                enemy.TakeDamage();
                attackparticles.Play();
                Invoke("StopParticleSystem", 0.8f);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            canAttack = false;
        }
    }
}
