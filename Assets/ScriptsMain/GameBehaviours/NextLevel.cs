using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public GameObject nextLevel;

    private void OnTriggerEnter()
    {
        
        SceneManager.LoadScene("LevelComplete");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
