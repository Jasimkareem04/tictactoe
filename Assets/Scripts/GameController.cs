using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int WhoseTurn = 0; //0 Xturn 1 Oturn
    public Sprite[] PlayerImage;
    public Button[] buttons;
    SpriteRenderer sprite;
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

    void winner(int a,int b,int c)
    {
        for(int i = 0;i < buttons.Length;i++)
        {
            if(i==a|| i==b || i==c)
            {
                continue;
            }
            else
            {
               buttons[i].image.color = new Color(0, 0, 0, 0.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttons[0].image.sprite == PlayerImage[0] && buttons[1].image.sprite == PlayerImage[0] && buttons[2].image.sprite == PlayerImage[0] )
        {
            winner(0,1,2);  
        }
        else if(buttons[3].image.sprite == PlayerImage[0] && buttons[4].image.sprite == PlayerImage[0] && buttons[5].image.sprite == PlayerImage[0])
        {
            winner(3,4,5);
        }
        else if (buttons[6].image.sprite == PlayerImage[0] && buttons[7].image.sprite == PlayerImage[0] && buttons[8].image.sprite == PlayerImage[0])
        {
            winner(6,7,8);
        }
        else if (buttons[0].image.sprite == PlayerImage[0] && buttons[3].image.sprite == PlayerImage[0] && buttons[6].image.sprite == PlayerImage[0])
        {
            winner(0,3,6);
        }
        else if (buttons[1].image.sprite == PlayerImage[0] && buttons[4].image.sprite == PlayerImage[0] && buttons[7].image.sprite == PlayerImage[0])
        {
            winner(1,4,7);
        }
        else if (buttons[2].image.sprite == PlayerImage[0] && buttons[5].image.sprite == PlayerImage[0] && buttons[8].image.sprite == PlayerImage[0])
        {
            winner(2,5,8);
        }
        else if (buttons[0].image.sprite == PlayerImage[0] && buttons[4].image.sprite == PlayerImage[0] && buttons[8].image.sprite == PlayerImage[0])
        {
            winner(0,4,8);
        }
        else if (buttons[2].image.sprite == PlayerImage[0] && buttons[4].image.sprite == PlayerImage[0] && buttons[6].image.sprite == PlayerImage[0])
        {
            winner(2,4,6);
        }


    }
   
}
