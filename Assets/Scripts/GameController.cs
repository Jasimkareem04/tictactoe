using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int WhoseTurn = 0; //0 Xturn 1 Oturn
    public Sprite[] PlayerImage;
    public Button[] buttons;
    SpriteRenderer sprite;
    public int[] markedSpace; //To know marked spaces
    int turncount;
    public GameObject WinnerPanel;
    public Text WinnerTxt;
    public static bool BotTurn;
    public static bool BotTurn2;
    int s1, s2, s3, s4, s5, s6, s7, s8;
    public int[] solution;


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }
    public void GameSetup() 
    {
        WhoseTurn = 0;
        turncount = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
            buttons[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < markedSpace.Length; i++)
        {
            markedSpace[i] = -10;
        }
    }

    public void OnClick(int whichBtn)
    {
        buttons[whichBtn].image.sprite = PlayerImage[WhoseTurn];
        buttons[whichBtn].enabled = false;

        markedSpace[whichBtn] = WhoseTurn + 1;
        turncount++;

        if (turncount > 4)
        {
            checkWinner();
        }
        
        if(BotTurn == true)
        {
            bot();
        }
        else if(BotTurn2 == true)
        {
            botLvl2();
        }
        else if (BotTurn == false && WhoseTurn == 0)
        {
            WhoseTurn = 1;
            
        }
        else if (BotTurn == false)
        {
            WhoseTurn = 0;
        }
    }

    public void checkWinner()
    {
        s1 = markedSpace[0] + markedSpace[1] + markedSpace[2];
        s2 = markedSpace[3] + markedSpace[4] + markedSpace[5];
        s3 = markedSpace[6] + markedSpace[7] + markedSpace[8];
        s4 = markedSpace[0] + markedSpace[3] + markedSpace[6];
        s5 = markedSpace[1] + markedSpace[4] + markedSpace[7];
        s6 = markedSpace[2] + markedSpace[5] + markedSpace[8];
        s7 = markedSpace[0] + markedSpace[4] + markedSpace[8];
        s8 = markedSpace[2] + markedSpace[4] + markedSpace[6];
        solution = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < solution.Length; i++)
        {
            if (solution[i] == 3 * (WhoseTurn + 1)) //check 3 spaces contains same icon
            {
                if(BotTurn == true)
                {
                    BotTurn = false;
                }
                WinnerDisplay();
                return;
            }
        }
    }
    public void WinnerDisplay()
    {
        WinnerPanel.gameObject.SetActive(true);
        if(WhoseTurn == 0)
        {
            WinnerTxt.text = "Player X won!";
        }
        else if(WhoseTurn == 1)
        {
            WinnerTxt.text = "Player O won!";
        }
    }
    public void bot()
    {
        WhoseTurn = 1;
        for (int i = Random.Range(0, markedSpace.Length); i < markedSpace.Length;i++)
        {
            if(markedSpace[i] == -10)
            {                  
                buttons[i].image.sprite = PlayerImage[WhoseTurn];
                buttons[i].enabled = false;
                markedSpace[i] = WhoseTurn + 1;
                checkWinner();
                turncount++;                
                WhoseTurn = 0;
                break;
            }
        }
    }
    public void botLvl2()
    {
        bool blocked = false;
        checkWinner();
           for (int i = 0; i < solution.Length; i++)
           {           
              if (solution[i] == -8) //check 2 spaces contains Xicon
              {
                    blocked = true;
                    Debug.Log("Bot2 found");
                    WhoseTurn = 1;
                    switch(i)
                    {
                        case 0:
                            for (int j = 0;j<3;j++)
                               {
                                if (markedSpace[j]==-10)
                                {
                                 blockPlayer(j); 
                                }
                               }
                               break;
                        case 1:
                            for (int j = 3; j < 6; j++)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 2:
                            for (int j = 6; j < 9; j++)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 3:
                            for (int j = 0; j < 7; j=j+3)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 4:
                            for (int j = 1; j < 8; j=j+3)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 5:
                            for (int j = 2; j < 9; j = j + 3)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 6:
                            for (int j = 0; j < 9; j = j + 4)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        case 7:
                            for (int j = 2; j < 7; j = j + 2)
                            {
                                if (markedSpace[j] == -10)
                                {
                                    blockPlayer(j);
                                }
                            }
                            break;
                        default: Debug.Log("default");
                            break;


                    }
                    break;
              }
           }
       if(!blocked)
       {
         bot();
       }
    }
    public void blockPlayer(int j)
    {
        buttons[j].image.sprite = PlayerImage[WhoseTurn];
        buttons[j].enabled = false;
        markedSpace[j] = WhoseTurn + 1;
        checkWinner();
        turncount++;
        WhoseTurn = 0;
    }
}

  

