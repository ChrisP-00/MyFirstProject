
using UnityEngine;
using Unity.AI.Navigation;

public class MyNavMeshBaker : MonoBehaviour
{
    NavMeshSurface myNavMeshSurface;


    private void Awake()
    {
        myNavMeshSurface = GetComponentInChildren<NavMeshSurface>();
    }


    private void Update()
    {
        myNavMeshSurface.BuildNavMesh();

    }
}

