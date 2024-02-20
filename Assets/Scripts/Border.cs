using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public PlayerController playerController;
    public bool canHurtPlayer = true;
    public bool inBorder = false;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("god");
        if (collision.CompareTag("Player"))
        {
            inBorder = true;
            Debug.Log("help");
            if (canHurtPlayer)
            {
                Damage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBorder = false;
        }
    }

    private IEnumerator WaitAndEnableHurtAgain()
    {
        Debug.Log("please");
        canHurtPlayer = false;
        yield return new WaitForSeconds(0.5f);
        canHurtPlayer = true;
        if (inBorder)
        {
            Damage();
        }
    }

    private void Damage()
    {
        Debug.Log("me");
        playerController.playerHealth--;
        Debug.Log("--");
        StartCoroutine(WaitAndEnableHurtAgain());
    }
}