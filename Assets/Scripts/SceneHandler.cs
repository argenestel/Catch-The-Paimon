using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public delegate void OnRestart();
    public static event OnRestart OnRestartEvent;
/*    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/
    private void OnEnable()
    {
        HealthManager.OnGameOverEvent += OnGameOver;
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
    public void Play()
    {
        SceneManager.LoadScene("ARPet");
        if(OnRestartEvent != null)
        {
            OnRestartEvent();
        }
    }


    private void OnDisable()
    {
        HealthManager.OnGameOverEvent -= OnGameOver;
    }
}

