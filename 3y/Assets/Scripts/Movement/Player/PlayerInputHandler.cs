using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To split input and movement
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementController controller;

    // Update is called once per frame
    private void Update()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        controller.Move(dir);
        if (Input.GetButton("Jump"))
        {
            controller.Jump();
        }
        else
        {
            controller.Fall();
        }

        if (Input.GetButtonDown("C"))
        {
            controller.Sit();
        }

        
    }
}
