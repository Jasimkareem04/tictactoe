using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn = false;
    }
    public void SinglePlayer()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn = true;
    }
}
