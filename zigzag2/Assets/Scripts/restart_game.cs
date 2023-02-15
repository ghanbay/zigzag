using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_game : MonoBehaviour
{
    public static bool is_restart = false;
    public void restartgame()
    {
        is_restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void quit_game()
    {
        Application.Quit();
    }
}
