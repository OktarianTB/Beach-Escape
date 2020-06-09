using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public bool gameIsFinished = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    public AudioClip scream;
    public AudioClip running;
    public AudioClip[] success;

    void Start()
    {
        gameOverScreen.SetActive(false);
        jumpVelocityY = 2 * jumpHeight / timeToJumpApex;
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);

        if(!gameOverScreen || success.Length == 0 || !scream || !scoreText)
        {
            Debug.LogError("Game Objects missing from inspector!");
        }
    }
    
    void FixedUpdate()
    {
        MovePlayer();
        UpdateText();
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

        if (!gameIsFinished && Input.GetKey(KeyCode.Space) && PlayerIsGrounded())
        {
            moveDistance.y = jumpVelocityY;
        }
 

        GetComponent<Rigidbody2D>().transform.Translate(moveDistance * Time.deltaTime);
    }


    bool PlayerIsGrounded()
    {
        return (transform.position.y > -1.4) ? false : true;
    }



    void UpdateText()
    {
        scoreText.text = "Turtles Saved: " + score.ToString();
    }

    public void PlaySuccessSound()
    {
        AudioSource.PlayClipAtPoint(success[Random.Range(0, success.Length)], transform.position, 0.8f);
    }

    public void PlayScreamSound()
    {
        AudioSource.PlayClipAtPoint(scream, transform.position, 0.8f);
    }

}
