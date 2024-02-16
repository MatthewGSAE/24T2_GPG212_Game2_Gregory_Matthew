using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAttacking;

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
