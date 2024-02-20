using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public PlayerController playerController;
    public bool canHurtPlayer = true;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("god");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("help");
            if (canHurtPlayer)
            {
                Damage();
            }
        }
    }

    private IEnumerator WaitAndEnableHurtAgain()
    {
        Debug.Log("please");
        canHurtPlayer = false;
        yield return new WaitForSeconds(0.5f);
        canHurtPlayer = true;
    }

    private void Damage()
    {
        Debug.Log("me");
        playerController.playerHealth--;
        Debug.Log("--");
        StartCoroutine(WaitAndEnableHurtAgain());
        Damage();
    }
}