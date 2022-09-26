using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls
{
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void showMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}   
