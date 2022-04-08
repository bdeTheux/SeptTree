using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{

    public ObjectPool<GameObject> pool;
    [SerializeField] private GameObject objPrefab;
    [SerializeField] private int amountPool;
    [SerializeField] private bool usePool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateObj, RetrieveObj,ReleaseObj, DestroyObj,false,amountPool,amountPool);
    
        GameObject tmp;
        for (int i = 0; i < amountPool; i++)
        {
            tmp = Instantiate(objPrefab);
            tmp.SetActive(false);
        }
    }

    GameObject CreateObj()
    {
        return Instantiate(objPrefab);
    }

    void RetrieveObj(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    void ReleaseObj(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    void DestroyObj(GameObject obj)
    {
        pool.Release(obj);
        /*if (usePool)
            pool.Release(obj);
        else
            Destroy(obj);
        */
    }

    
}
