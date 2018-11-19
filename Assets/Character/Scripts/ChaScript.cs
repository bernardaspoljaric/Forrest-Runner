using UnityEngine;
using System.Collections;

public class ChaScript : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private Vector3 moveVector;

    void Start()
    {
       // anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector = Vector3.zero;
        controller.Move(moveVector * Time.deltaTime);
       /** anim.SetBool("Run", true);
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("RunLeft", true);
        }
        else
        {
            anim.SetBool("RunLeft", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("RunRight", true);
        }
        else
        {
            anim.SetBool("RunRight", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        */
    }
}
