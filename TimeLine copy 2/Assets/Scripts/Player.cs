using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public int maxScore;
    public int Points;
    public TextMeshProUGUI pointsText;

    public bool isPlaying;
    public bool isMakingATurn;


    public Image resultSlider;

    public ResultIndicator indicator;

    private void Start()
    {
        
        maxScore = GameObject.FindGameObjectWithTag("SetupInfo").GetComponent<SetupInfo>().scoreToWin;
        pointsText.text = "0";
    }

    public void AddPoints()
    {
        Points++;
        pointsText.text = Points.ToString();
        if (Points >= maxScore)
        {
            GameObject.FindGameObjectWithTag("GM").GetComponent<ManagingTheGame>().GameOver();
        }
       
    }

    public void LigthOn()
    {
        indicator.IndicatePlayer(true);
    }

    public void LigthOff()
    {
        indicator.IndicatePlayer(false);
    }

    public void FillAmount()
    {
        float pecentage = (float)Points / maxScore;
        resultSlider.fillAmount = pecentage;
    }


    public void Update()
    {
        if (isPlaying)
        { 
            if (isMakingATurn)
            {
                LigthOn();
            }
            else if (!isMakingATurn)
            {
                LigthOff();
            }
            FillAmount();
        }
    }

}
