using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public LevelController levelController;
    public int currentScene = 0;


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // called after each frame
    void Update()
    {
        
    }

    public void enterFirstLevel(){
        SceneManager.LoadScene("Level 1");
        currentScene = 1;
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    public void enterNextScene()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    public void reloadCurrentScene()
    {;
        SceneManager.LoadScene(currentScene);
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void showMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
