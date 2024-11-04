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

    public bool EasyLvl;
    public bool MediumLvl;
    public bool HardLvl;
    public static MainMenu Instance;


    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        EasyBtn.gameObject.SetActive(false);
        MediumBtn.gameObject.SetActive(false);
        HardBtn.gameObject.SetActive(false);
    }
    public void MultiPlayer()
    {
        SceneManager.LoadSceneAsync(0);
        EasyLvl = false;
        MediumLvl = false;
        HardLvl = false;

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
        MediumLvl = true;
        EasyLvl = false;
        HardLvl = false;
    }
    public void Easy()
    {
       SceneManager.LoadSceneAsync(0);
       EasyLvl = true;
       MediumLvl = false;
       HardLvl = false;
    }
    public void Hard()
    {
        SceneManager.LoadSceneAsync(0);
        EasyLvl = false;
        MediumLvl = false;
        HardLvl = true;
    }
}
