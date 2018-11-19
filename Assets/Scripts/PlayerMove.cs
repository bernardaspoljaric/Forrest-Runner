using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector = Vector3.zero;
    private float verticalVelocity = 0.0f;
    private float gravity = 15.0f;
    private bool isDead = false;
    private float animationDuration = 2.0f;
    private float startTime;


    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }
    
    // Update is called once per frame
    void Update ()
   {
        if (isDead)
            return;
        if(Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        if (controller.isGrounded)
        {
            verticalVelocity = 0.0f;
        }       
        
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x > Screen.width / 2)
            {
                moveVector.x = speed;
            }
            else
            {
                moveVector.x = -speed;
            }
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
        
    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
            Death();
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
