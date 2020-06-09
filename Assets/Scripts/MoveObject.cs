using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    float speed = 1;
    public Transform startPosition;
    public Transform endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedEnd())
        {
            moveToStart();
        }

        float movement = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(movement, transform.position.y, transform.position.z);
    }


    bool reachedEnd()
    {
        if(transform.position.x < endPosition.position.x)
        {
            return true;
        }
        return false;
    }

    void moveToStart()
    {
        transform.position = new Vector3(startPosition.position.x,
            transform.position.y, transform.position.z);
    }

}
