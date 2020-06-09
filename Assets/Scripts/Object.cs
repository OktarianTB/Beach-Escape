using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField()]
    float speed = 4;
    public enum ObjectType { RECYCLABLE, DANGER };
    public ObjectType type;

    void Start()
    {
        
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
        if(type == ObjectType.DANGER)
        {
            print("Game Over");
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
