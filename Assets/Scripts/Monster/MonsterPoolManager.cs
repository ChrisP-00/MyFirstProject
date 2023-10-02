using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MonsterPoolManager : MonoBehaviour
{
    //  dictionary 
    static Dictionary<string, GameObject> myObjectPools = new Dictionary<string, GameObject>();

    [SerializeField] GameObject myPool;

    private static MonsterPoolManager inst = null;
    public static MonsterPoolManager Inst { get { if (inst == null) { return null; } return inst; } }


    private void Awake()
    {
        // Singleton Pattern 
        #region Singleton Pattern
        if (inst == null)
        {
            inst = FindAnyObjectByType<MonsterPoolManager>();

            if (inst == null)
            {
                inst = this;

                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
        //// Singleton Pattern
    }


    public GameObject BringObject(GameObject targetObject)
    {
        string key = targetObject.name.ToString();

        GameObject newObject = null;

        // check if requested object has its own pool, if not, make new pool 
        if (!myObjectPools.ContainsKey(key))
        {
            createNewPool(targetObject);
        }

        // Bring object from pool by key 
        newObject = myObjectPools[key].GetComponent<myObjectPool>().Inst.MyPool.Get();

        return newObject;
    }

    public void DestroyObject(GameObject destroyObject)
    {
        string key = destroyObject.name.ToString();

        // check if requested object has its own pool, if not, make new pool 
        if (!myObjectPools.ContainsKey(key))
        {
            createNewPool(destroyObject);
        }

        // return object to pool by key 
        myObjectPools[key].GetComponent<myObjectPool>().Inst.MyPool.Release(destroyObject);
    }


    void createNewPool(GameObject targetObject)
    {
        string key = targetObject.name.ToString();

        // create new pool 
        GameObject newPool = Instantiate<GameObject>(myPool, this.transform);
        newPool.GetComponent<myObjectPool>().monsterPrefab = targetObject;
        // rename the pool 
        newPool.name = $"MonsterPool_{Regex.Replace(key, @"Monster|Prefab", "")}";
        // add pool to dictionary 
        myObjectPools.Add(key, newPool);
    }
}