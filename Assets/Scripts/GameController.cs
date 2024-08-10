using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public Vector2 Pos = new Vector2(338, 327);
    bool IsClicked = false;
    Text xText;
    Text oText;
    public Text[] PlayerTxt;
    void Start()
    {
        PlayerPrefs.DeleteKey("Txt");
        xText.text = "X";
        oText.text = "O";
    }
    void Update()
    {
        PlayerTxt[1].text = PlayerPrefs.GetString("Txt");
    }
    public void Onclick()
    {
        if (!IsClicked)
        {
            PlayerPrefs.SetString("Txt","X");
            IsClicked = true;
        }
        
    }
}
