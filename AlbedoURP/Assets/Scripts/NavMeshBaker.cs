using UnityEngine;
using NavMeshPlus.Components;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface navMeshSurface; // Bu bileþeni Unity'deki NavMeshSurface'ýnýza atayýn

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tetikleyicinin "Player" tag'ini kontrol edin
        {
            Debug.Log("Navmesh");
            navMeshSurface.BuildNavMesh(); // NavMesh'i yeniden oluþturur
        }
    }
}

