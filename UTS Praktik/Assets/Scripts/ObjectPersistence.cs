// ================================================================================================================
// UTS Praktik - ObjectPersistence.cs
// 
// Author: Wahyu Candra
// Date:   12/11/2021
// ================================================================================================================
using UnityEngine;

public class ObjectPersistence : MonoBehaviour
{
    private static ObjectPersistence instance = null;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
