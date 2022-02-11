using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//From the tutorial of Dani
public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;
    [FormerlySerializedAs("camera")] [SerializeField] public GameObject cam;
    [SerializeField] public float parallaxEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void LateUpdate()
    {
        var temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + lenght)
        {
            startPos += lenght;
        }else if (temp < startPos - lenght)
        {
            startPos -= lenght;
        }
    }
}
