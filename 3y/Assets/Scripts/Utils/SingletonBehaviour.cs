using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * From Teacher
 */
public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    [SerializeField] private bool _isPersistent;
        private static T _instance;
        public static T instance => _instance;

    protected virtual void Awake()
    {
        if (!_instance)
        {
            _instance = (T)this;
            DontDestroyOnLoad(this);
        }
    }
}
