using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button EasyBtn;
    public Button MediumBtn;
    public Button HardBtn;


    public void Start()
    {
        EasyBtn.gameObject.SetActive(false);
        MediumBtn.gameObject.SetActive(false);
        HardBtn.gameObject.SetActive(false);
    }
    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn = false;
        GameController.BotTurn2 = false;
        GameController.BotTurn3 = false;

    }
    public void SinglePlayer()
    {
        EasyBtn.gameObject.SetActive(true);
        MediumBtn.gameObject.SetActive(true);
        HardBtn.gameObject.SetActive(true);
    }
    public void Medium()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn2 = true;
        GameController.BotTurn = false;
        GameController.BotTurn3 = false;
    }
    public void Easy()
    {
       SceneManager.LoadSceneAsync(0);
       GameController.BotTurn = true;
       GameController.BotTurn2 = false;
       GameController.BotTurn3 = false;
    }
    public void Hard()
    {
        SceneManager.LoadSceneAsync(0);
        GameController.BotTurn = false;
        GameController.BotTurn2 = false;
        GameController.BotTurn3 = true;
    }
}
