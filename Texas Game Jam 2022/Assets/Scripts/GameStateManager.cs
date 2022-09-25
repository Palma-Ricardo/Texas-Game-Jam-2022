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
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        DontDestroyOnLoad(this.gameObject);
    }

    // called after each frame
    void Update()
    {
        
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
}
