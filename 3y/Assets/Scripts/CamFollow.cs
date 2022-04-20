using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindWithTag("Player").transform;
    }
}
