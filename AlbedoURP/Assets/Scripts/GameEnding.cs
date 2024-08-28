using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject InterFacePanel;
    public GameObject GameEndingPanel;
    public AudioSource gameOverSound;  // Oyun biti� sesi
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
        // Aray�z panelini kapat ve oyun biti� panelini a�
        InterFacePanel.SetActive(false);
        GameEndingPanel.SetActive(true);

        // Oyun zaman�n� durdur
        Time.timeScale = 0f;

        // Oyun biti� sesini �al
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }

        // Oyun biti� durumunu i�aretle
        isGameOver = true;
    }

    public void SceneLoader()
    {
        // Oyun biti� panelini kapat ve aray�z panelini a�
        GameEndingPanel.SetActive(false);
        InterFacePanel.SetActive(true);

        // Oyun zaman�n� tekrar ba�lat
        Time.timeScale = 1f;

        // Yeni sahneyi y�kle
        SceneManager.LoadScene(1);
    }
}
