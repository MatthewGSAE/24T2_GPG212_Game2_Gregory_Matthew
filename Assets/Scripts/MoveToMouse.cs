using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 target;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // Check if the character is moving right or left
        if (transform.position.x > lastPosition.x)
        {
            // Moving right, face right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x < lastPosition.x)
        {
            // Moving left, face left
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Update lastPosition for the next frame
        lastPosition = transform.position;
    }
}
