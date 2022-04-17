using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Rigidbody body;
    private bool isJumpPressed = false;

    private bool isRightPressed = false;

    private bool isLeftPressed = false;

    [SerializeField]
    public int jumpForce;
    void Start()
    {
        body = getRigidbody();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            this.isJumpPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.isLeftPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.isRightPressed = true;
        }
    }

    void FixedUpdate()
    {
        if(this.isJumpPressed){
            body.AddForce(Vector3.up * jumpForce);
        }
        if(this.isLeftPressed){
            
        }
    }

    private Rigidbody getRigidbody()
    {
        return GetComponent<Rigidbody>();
    }
}
