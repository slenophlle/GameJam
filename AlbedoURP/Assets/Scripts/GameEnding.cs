using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject InterFacePanel;
    public GameObject GameEndingPanel;
    public AudioSource gameOverSound;  // Oyun bitiþ sesi
    private bool isGameOver = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && !isGameOver)
        {
            TriggerGameEnding();
        }
    }

    private void TriggerGameEnding()
    {
        // Arayüz panelini kapat ve oyun bitiþ panelini aç
        InterFacePanel.SetActive(false);
        GameEndingPanel.SetActive(true);

        // Oyun zamanýný durdur
        Time.timeScale = 0f;

        // Oyun bitiþ sesini çal
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }

        // Oyun bitiþ durumunu iþaretle
        isGameOver = true;
    }

    public void SceneLoader()
    {
        // Oyun bitiþ panelini kapat ve arayüz panelini aç
        GameEndingPanel.SetActive(false);
        InterFacePanel.SetActive(true);

        // Oyun zamanýný tekrar baþlat
        Time.timeScale = 1f;

        // Yeni sahneyi yükle
        SceneManager.LoadScene(1);
    }
}
