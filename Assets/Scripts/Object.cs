using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public float speed;
    public enum ObjectType { RECYCLABLE, DANGER };
    public ObjectType type;

    StickMan stickMan;

    void Start()
    {
        stickMan = FindObjectOfType<StickMan>();
        if (!stickMan)
        {
            Debug.LogError("Stick Man cannot be found!");
        }
    }
    
    void FixedUpdate()
    {
        float movement = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(movement, transform.position.y, transform.position.z);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ObjectType.DANGER && !stickMan.gameIsFinished)
        {
            stickMan.gameIsFinished = true;
            stickMan.PlayScreamSound();
            stickMan.gameOverScreen.SetActive(true);
        }
        else if (!stickMan.gameIsFinished)
        {
            stickMan.score++;
            stickMan.PlaySuccessSound();
            Destroy(gameObject);
        }
    }


}
