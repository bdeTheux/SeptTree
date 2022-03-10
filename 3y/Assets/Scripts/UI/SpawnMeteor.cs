using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] private Meteor objPrefab;
    private ObjectPool<Meteor> _pool;
    [SerializeField] private bool usePool;
    private void Start()
    {
        //create, onGet, onRelease, onDestroy
        _pool = new ObjectPool<Meteor>(() =>
            {
                return Instantiate(objPrefab);
            }, obj =>
            {
                obj.gameObject.SetActive(true);
            },
            obj =>
            {
                obj.gameObject.SetActive(false);
            },
            Kill,false,2,4);
        InvokeRepeating(nameof(Spawn),0.5f, 0.6f);
    }

    private void Spawn()
    {
        var obj = usePool ? _pool.Get() : Instantiate(objPrefab);
        obj.transform.position = (Vector2)transform.position + Random.insideUnitCircle * 8;
        
    }

    private void Kill(Meteor obj)
    {
        
        if (usePool)
        {
            _pool.Release(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}
