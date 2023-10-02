using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class myPrefab : MonoBehaviour
{

    public IObjectPool<GameObject> myPool { get; set; }

    public NavMeshAgent agent;
    public GameObject target;
    LineRenderer myLine;
    NavMeshPath myPath;


    private void Awake()
    {
        Debug.Log("I am Awake");

        target = FindAnyObjectByType<Cube>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        myLine = GetComponent<LineRenderer>();
        myLine.startWidth = myLine.endWidth = 0.2f;
        myLine.enabled = false;
    }

    private void Start()
    {
        Debug.Log("I am Start");

        StartCoroutine(makePath());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator makePath()
    {
        Debug.Log("start coroutine");

        agent.SetDestination(target.transform.position);

        yield return new WaitForSeconds(1f);

        drawPath();
    }


    void drawPath()
    {
        myLine.SetPosition(0, this.transform.position);

        for (int i = 0; i < agent.path.corners.Length; ++i)
        {
            myLine.SetPosition(i, agent.path.corners[i]);
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            myPool.Release(this.gameObject);
        }
    }
}
