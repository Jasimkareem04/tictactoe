using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int WhoseTurn = 0; //0 Xturn 1 Oturn
    public Sprite[] PlayerImage;
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();  
    }
    void GameSetup()
    {
        WhoseTurn = 0;
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
            buttons[i].GetComponent<Image>().sprite = null;
        }
    }

    public void OnClick(int whichBtn)
    {
        buttons[whichBtn].image.sprite = PlayerImage[WhoseTurn];
        buttons[whichBtn].enabled = false;

        if (WhoseTurn == 0)
        {
            WhoseTurn = 1;
        }
        else
        {
            WhoseTurn = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
