using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrDecreaseBtns : MonoBehaviour
{
    public SetupInfo info;
    public TextMeshProUGUI playersCountText;
    public TextMeshProUGUI scoreToWinText;
    public TextMeshProUGUI currentDeckText;

    public int currentDeckIndex;

    public void Start()
    {
        info = GameObject.FindGameObjectWithTag("SetupInfo").GetComponent<SetupInfo>();
        currentDeckIndex = 0;
        currentDeckText.text = info.discoveriesDeckName;
    }

    public void IncreasePlayersCount()
    {
        if (info.playersCount < 4)
            info.playersCount++;
        else
        {
            info.playersCount = 4;
        }
    }

    public void DecreasePlayersCount()
    {
        if (info.playersCount > 1)
        {
            info.playersCount--;
        }
        else
        {

            info.playersCount = 1;
        }
    }

    public void IncreaseScoreToWin()
    {
        if (info.scoreToWin < 100)
            info.scoreToWin+=5;
        else
        {
            info.scoreToWin = 100;
        }
    }

    public void DecreasescoreToWin()
    {
        if (info.scoreToWin > 5)
        {
            info.scoreToWin -= 5;
        }
        else
        {

            info.scoreToWin = 5;
        }
    }


    public void IncreaseDeckName()
    {
        if (currentDeckIndex < info.decknames.Count - 1)
        {
            currentDeckIndex++;
        }            
        else
        {
            currentDeckIndex = 0;
        }
        info.SetDeck(currentDeckIndex);
       
    }

    public void DecreaseDeckName()
    {
        if (currentDeckIndex > 0)
        {
            currentDeckIndex--;
            
        }
        else
        {
            currentDeckIndex = info.decknames.Count - 1;
           
        }
        info.SetDeck(currentDeckIndex);
        
    }

    public void Update()
    {
        playersCountText.text = info.playersCount.ToString();
        scoreToWinText.text = info.scoreToWin.ToString();
        currentDeckText.text = info.decknames[currentDeckIndex];
       
    }
}
