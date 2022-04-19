using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        //call 1 meth in GameManager ?
        GameManagerProxy.AskAPlayer();
        GameManagerProxy.AskACamera();
    }
}
