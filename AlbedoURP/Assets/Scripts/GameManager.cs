using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu; // Pause men�y� temsil eden GameObject
    private bool isPaused = false; // Oyun duraklat�lm�� m� kontrol eder

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne y�klendi�inde zaman �l�e�ini s�f�rla
        Time.timeScale = 1f;
        AudioListener.pause = false; // Sesleri tekrar �almaya ba�lat
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SpaceShip");
        }
    }
    public void QuitApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }

    public void TryAgainScene()
    {
        SceneManager.LoadScene("SpaceShip");
    }
    public void MainLobbyScene()
    {
        SceneManager.LoadScene("UI_Men�");
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Oyun zaman�n� durdur
            Time.timeScale = 0;
            // Pause men�s�n� g�ster
            pauseMenu.SetActive(true);
            // T�m sesleri duraklat
            AudioListener.pause = true;
            Cursor.visible = true;
        }
        else
        {
            // Oyun zaman�n� devam ettir
            Time.timeScale = 1;
            // Pause men�s�n� gizle
            pauseMenu.SetActive(false);
            // T�m sesleri tekrar �almaya ba�lat
            AudioListener.pause = false;
            Cursor.visible = false;
        }
    }
}
