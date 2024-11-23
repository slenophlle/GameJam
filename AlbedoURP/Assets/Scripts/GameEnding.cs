using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject InterFacePanel;
    public GameObject GameEndingPanel;
    private bool isGameOver = false;
    private Soundmanager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<Soundmanager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && !isGameOver)
        {
            TriggerGameEnding();
        }
    }

    private void TriggerGameEnding()
    {
        Cursor.visible = true;
        // Aray�z panelini kapat ve oyun biti� panelini a�
        InterFacePanel.SetActive(false);
        GameEndingPanel.SetActive(true);
        soundManager.deadSound.Play();


        isGameOver = true;
    }

    public void SceneLoader()
    {
        GameEndingPanel.SetActive(false);
        InterFacePanel.SetActive(true);
        Time.timeScale = 1f; // Zaman �l�e�ini s�f�rla

        SceneManager.LoadScene("SpaceShip");
    }
}
