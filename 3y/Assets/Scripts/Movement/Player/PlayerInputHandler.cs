using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To split input and movement
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementController controller;
    private Rigidbody2D rb;

    // Update is called once per frame
    private void Update()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        controller.Move(dir);
        if (Input.GetButtonDown("Jump"))
        {
            controller.Jump();
            Debug.Log("hello");
        }

       /* if (Input.GetButtonUp("Jump") && rb.velocity.y >0)
        {
            
        }*/
    }
}
