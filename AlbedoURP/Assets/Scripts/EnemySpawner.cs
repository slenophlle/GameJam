using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn etmek istediðiniz düþman prefab'i
    public Transform spawnLocation; // Düþmanýn spawn olacaðý yer

    void Start()
    {
        StartCoroutine(SpawnEnemyAfterDelay(120f)); // 120 saniye yani 2 dakika sonra spawn olacak
    }

    IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
