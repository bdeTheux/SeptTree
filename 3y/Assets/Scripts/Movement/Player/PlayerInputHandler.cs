using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To split input and movement
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MovementController controller;
    [SerializeField] private GameManagerProxy proxy;

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

        if (Input.GetButtonDown("Sit"))
        {
            controller.Sit();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            proxy.MenuInGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //shrink
            controller.Shrimp();
        }

        
    }
}
