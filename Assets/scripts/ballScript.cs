using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    private Rigidbody body;
    private bool isJumpPressed = false;

    private bool isRightPressed = false;

    private bool isLeftPressed = false;

    private bool isLeftMove = false;
    
    private bool isAbleToJump = true;

    private static readonly int layerFloor = 8;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int moveForce;
    void Start()
    {
        body = getRigidbody();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.isJumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (this.isJumpPressed && this.isAbleToJump)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            this.isJumpPressed = false;
            this.isAbleToJump = false;
        }
        var axisHorizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(axisHorizontal * moveForce, body.velocity.y, 0);
    }

    private Rigidbody getRigidbody()
    {
        return GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == layerFloor){
            this.isAbleToJump = true;
        }
    }
}
