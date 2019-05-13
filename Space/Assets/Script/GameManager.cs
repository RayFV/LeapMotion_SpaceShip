using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameoverPanel;
    public GameObject[] destoryList;

    public LeapMouse leapMouse;

    public AudioSource audioData;
    public AudioClip loseBgm;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Data.Save();
        
        gameoverPanel.SetActive(true);
        audioData.clip = loseBgm;
        audioData.loop = false;
        audioData.Play();
        GameObject[] allAsteroid = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject obj in destoryList)
        {
            Destroy(obj);
        }
        foreach(GameObject obj in allAsteroid)
        {
            Destroy(obj);
        }
        leapMouse.Enable();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
