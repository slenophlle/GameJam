using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu; // Pause men�y� temsil eden GameObject
    private bool isPaused = false; // Oyun duraklat�lm�� m� kontrol eder

    private void Update()
    {
        // Pause tu�una bas�ld���nda
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
    public void TryAgainScene()
    {
        SceneManager.LoadScene(2);
    }
    // Oyun duraklatmay�/tan�mlamay� sa�lar
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Oyun zaman�n� durdur
            Time.timeScale = 0;
            // Pause men�s�n� g�ster
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            // Oyun zaman�n� devam ettir
            Time.timeScale = 1;
            // Pause men�s�n� gizle
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }
    }
}
