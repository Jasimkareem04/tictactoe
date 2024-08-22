using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int WhoseTurn = 0; //0 Xturn 1 Oturn
    public Sprite[] PlayerImage;
    public Button[] buttons;
    SpriteRenderer sprite;
    public int[] markedSpace; //To know marked spaceses
    int turncount;
    public GameObject WinnerPanel;
    public Text WinnerTxt;
    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }
    void GameSetup() 
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

        if (WhoseTurn == 0)
        {
            WhoseTurn = 1;
        }
        else
        {
            WhoseTurn = 0;
        }
    }

    void checkWinner()
    {
        int s1 = markedSpace[0] + markedSpace[1] + markedSpace[2];
        int s2 = markedSpace[3] + markedSpace[4] + markedSpace[5];
        int s3 = markedSpace[6] + markedSpace[7] + markedSpace[8];
        int s4 = markedSpace[0] + markedSpace[3] + markedSpace[6];
        int s5 = markedSpace[1] + markedSpace[4] + markedSpace[7];
        int s6 = markedSpace[2] + markedSpace[5] + markedSpace[8];
        int s7 = markedSpace[0] + markedSpace[4] + markedSpace[8];
        int s8 = markedSpace[2] + markedSpace[4] + markedSpace[6];
        var solution = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < solution.Length; i++)
        {
            if (solution[i] == 3 * (WhoseTurn + 1)) //check 3 spaces contains same icon
            {
                WinnerDisplay();
                return;
            }
        }
    }
    void WinnerDisplay()
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
}

  

