using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button EasyBtn;
    public Button MediumBtn;


    public void Start()
    {
        EasyBtn.gameObject.SetActive(false);
        MediumBtn.gameObject.SetActive(false);
    }
    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn = false;
        
    }
    public void SinglePlayer()
    {
        EasyBtn.gameObject.SetActive(true);
        MediumBtn.gameObject.SetActive(true);
    }
    public void Medium()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn2 = true;
        GameController.BotTurn = false;
    }
    public void Easy()
    {
       SceneManager.LoadSceneAsync(0);
       GameController.BotTurn = true;
        GameController.BotTurn2 = false;
    }
}
