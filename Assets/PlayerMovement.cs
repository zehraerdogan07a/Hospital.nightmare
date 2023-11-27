using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Serialized Fields for attributes
    [SerializeField]
    float movementSpeed = 1f;

    //Variables used within this script
    Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        if(rigidBody == null)
        {
            Debug.Log("This object is missing a rigidbody!");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        float verticalBound = Camera.main.orthographicSize;
        float horizontalBound = Camera.main.orthographicSize * Camera.main.aspect;

        if (transform.position.y < verticalBound && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            rigidBody.velocity = Vector2.up * movementSpeed;
        } else if (transform.position.y > -verticalBound && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            rigidBody.velocity = Vector2.down * movementSpeed;
        } else if (transform.position.x < horizontalBound && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            rigidBody.velocity = Vector2.right * movementSpeed;
        }else if (transform.position.x > -horizontalBound && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            rigidBody.velocity = Vector2.left * movementSpeed;
        }else
        {
            rigidBody.velocity = Vector2.zero;
        }



    }


}
