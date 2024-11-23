using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn etmek istediðiniz düþman prefab'i
    public Transform[] spawnLocations; // Düþmanýn spawn ve devriye pozisyonlarý

    private GameObject currentEnemy; // Sahnedeki mevcut düþman referansý

    void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (true)
        {
            // Yeni bir düþman spawnla
            SpawnEnemy();

            // 2 dakika bekle (120 saniye)
            yield return new WaitForSeconds(120f);

            // Mevcut düþmaný yok et
            if (currentEnemy != null)
            {
                Destroy(currentEnemy);
            }

            // Bir sonraki spawn için kýsa bir süre bekle
            yield return new WaitForSeconds(10f); // Bir sonraki spawn'a kadar kýsa bir gecikme      
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktasý seç
        int randomIndex = Random.Range(0, spawnLocations.Length);

        // Düþmaný seçilen noktada spawn et
        currentEnemy = Instantiate(enemyPrefab, spawnLocations[randomIndex].position, spawnLocations[randomIndex].rotation);

        // Düþmanýn spawnLocations dizisini atayýn
        TargetFollow targetFollow = currentEnemy.GetComponent<TargetFollow>();
        if (targetFollow != null)
        {
            targetFollow.Positions = spawnLocations; // spawnLocations dizisini Positions olarak ayarla
        }
    }
}
