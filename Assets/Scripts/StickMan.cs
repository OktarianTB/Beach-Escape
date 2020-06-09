using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class StickMan : MonoBehaviour
{
    Vector3 moveDistance;
    float gravity;
    float jumpVelocityY;
    [SerializeField()]
    float jumpHeight = 3f;
    float timeToJumpApex = .5f;

    bool gameIsFinished = false;

    void Start()
    {
        jumpVelocityY = 2 * jumpHeight / timeToJumpApex;
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    }
    
    void FixedUpdate()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {

        if (PlayerIsGrounded())
        {
            moveDistance.y = 0;
        }
        else
        {
            moveDistance.y += gravity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && PlayerIsGrounded() && !gameIsFinished)
        {
            moveDistance.y = jumpVelocityY;
        }

        GetComponent<Rigidbody2D>().transform.Translate(moveDistance * Time.deltaTime);
    }


    bool PlayerIsGrounded()
    {
        return (transform.position.y > -1.5) ? false : true;
    }
}
