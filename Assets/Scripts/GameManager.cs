using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private int playerDeaths;

    public int PlayerDeaths
    {
        get
        {
            return playerDeaths;
        }
        private set
        {
            playerDeaths = value;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseDeathCount()
    {
        playerDeaths++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }
}
