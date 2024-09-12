using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu; // Pause menüyü temsil eden GameObject
    private bool isPaused = false; // Oyun duraklatýlmýþ mý kontrol eder

    private void Update()
    {
        // Pause tuþuna basýldýðýnda
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
    public void TryAgainScene()
    {
        SceneManager.LoadScene(2);
    }
    // Oyun duraklatmayý/tanýmlamayý saðlar
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Oyun zamanýný durdur
            Time.timeScale = 0;
            // Pause menüsünü göster
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            // Oyun zamanýný devam ettir
            Time.timeScale = 1;
            // Pause menüsünü gizle
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }
    }
}
