using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn etmek istedi�iniz d��man prefab'i
    public Transform[] spawnLocations; // D��man�n spawn ve devriye pozisyonlar�

    private GameObject currentEnemy; // Sahnedeki mevcut d��man referans�

    void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (true)
        {
            // Yeni bir d��man spawnla
            SpawnEnemy();

            // 2 dakika bekle (120 saniye)
            yield return new WaitForSeconds(120f);

            // Mevcut d��man� yok et
            if (currentEnemy != null)
            {
                Destroy(currentEnemy);
            }

            // Bir sonraki spawn i�in k�sa bir s�re bekle
            yield return new WaitForSeconds(10f); // Bir sonraki spawn'a kadar k�sa bir gecikme      
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktas� se�
        int randomIndex = Random.Range(0, spawnLocations.Length);

        // D��man� se�ilen noktada spawn et
        currentEnemy = Instantiate(enemyPrefab, spawnLocations[randomIndex].position, spawnLocations[randomIndex].rotation);

        // D��man�n spawnLocations dizisini atay�n
        TargetFollow targetFollow = currentEnemy.GetComponent<TargetFollow>();
        if (targetFollow != null)
        {
            targetFollow.Positions = spawnLocations; // spawnLocations dizisini Positions olarak ayarla
        }
    }
}
