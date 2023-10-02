using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using System.Text.RegularExpressions;

public class myObjectPool : MonoBehaviour
{
    private IObjectPool<GameObject> myPool;
    public IObjectPool<GameObject> MyPool { get { return myPool; } }

    private myObjectPool inst;
    public myObjectPool Inst { get { return inst; } }

    public GameObject monsterPrefab = null;



// Start is called before the first frame update
void Awake()
    {
        inst = this;
        myPool = new ObjectPool<GameObject>(CreateNewObject, BringObjectFromPool,
            ReturnObjectToPool, DestroyObjectFromPool, true, 3, 5);
    }


    protected GameObject CreateNewObject()
    {
        GameObject myObject = Instantiate<GameObject>(monsterPrefab, this.transform);

        var pattern = @" ?\(.*?\)";

        myObject.name = Regex.Replace(myObject.name, pattern, "");
        return myObject;
    }

    protected void BringObjectFromPool(GameObject monster)
    {
        monsterPrefab = monster;
        monster.gameObject.SetActive(true);
        monster.transform.position = transform.parent.position;
    }

    protected void ReturnObjectToPool(GameObject myObject)
    {
        myObject.transform.position = transform.parent.position;
        myObject.gameObject.SetActive(false);
    }

    protected void DestroyObjectFromPool(GameObject myObject)
    {
        Destroy(myObject.gameObject);
    }
}
