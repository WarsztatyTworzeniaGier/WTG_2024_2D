using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "Main";

    [Header("References")]
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Window mainScreen, settingsScreen;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ToggleSettings(bool enabled)
    {
        mainScreen.Toggle(!enabled);
        settingsScreen.Toggle(enabled);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }


    private void Awake()
    {
        if(startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            QuitGame();
        }
    }
}
