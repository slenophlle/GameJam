using UnityEngine;
using NavMeshPlus.Components;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface navMeshSurface; // Bu bile�eni Unity'deki NavMeshSurface'�n�za atay�n

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tetikleyicinin "Player" tag'ini kontrol edin
        {
            Debug.Log("Navmesh");
            navMeshSurface.BuildNavMesh(); // NavMesh'i yeniden olu�turur
        }
    }
}

