using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //End Game
            Destroy(other.gameObject);
        }
        Debug.Log(other);

        Destroy(other.gameObject);
    }
}
