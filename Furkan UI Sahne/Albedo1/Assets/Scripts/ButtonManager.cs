using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject SettingsPanel;
    [Header("Game Panel")]
    public GameObject GamePanel;

    [Header("Buttons")]
    public GameObject PlayButton;
    public GameObject SettingButton;
    public GameObject Credits;

    private bool isSettingsPanelVisible = false;
    private bool isGamePanelVisible = true;

    private void Start()
    {
        // Initialize the settings panel visibility
        SettingsPanel.SetActive(isSettingsPanelVisible);
        GamePanel.SetActive(isGamePanelVisible);

    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Toggle the settings panel visibility
    public void ToggleSettingsPanel()
    {
        isGamePanelVisible = !isGamePanelVisible;
        GamePanel.SetActive(isGamePanelVisible);
        isSettingsPanelVisible = !isSettingsPanelVisible;
        SettingsPanel.SetActive(isSettingsPanelVisible);
    }

    // Quit the application or stop playing in the editor
    public void QuitApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
    
}
