using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu; // Pause menüyü temsil eden GameObject
    private bool isPaused = false; // Oyun duraklatýlmýþ mý kontrol eder

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
        // Yeni sahne yüklendiðinde zaman ölçeðini sýfýrla
        Time.timeScale = 1f;
        AudioListener.pause = false; // Sesleri tekrar çalmaya baþlat
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
        SceneManager.LoadScene("UI_Menü");
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Oyun zamanýný durdur
            Time.timeScale = 0;
            // Pause menüsünü göster
            pauseMenu.SetActive(true);
            // Tüm sesleri duraklat
            AudioListener.pause = true;
            Cursor.visible = true;
        }
        else
        {
            // Oyun zamanýný devam ettir
            Time.timeScale = 1;
            // Pause menüsünü gizle
            pauseMenu.SetActive(false);
            // Tüm sesleri tekrar çalmaya baþlat
            AudioListener.pause = false;
            Cursor.visible = false;
        }
    }
}
