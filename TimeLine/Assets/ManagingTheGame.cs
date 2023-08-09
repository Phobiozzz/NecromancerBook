using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagingTheGame : MonoBehaviour
{
    public SetupInfo setup;
    public List<Player> playersList;

    public TextMeshProUGUI currentPlayerName;
    string playerName;
    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI resultOfDropping;
    public GameObject restartButton;
    public TextMeshProUGUI resultsText;

    public int currentPlayerID;
    int playersCount;
    float showTime;

    public GameObject loadingScreen;
    

    GameObject hand;

    public ResultIndicator resultIndicator;

    GameObject soundManager;

    private void Start()
    {
        Instantiate(loadingScreen, transform.parent);
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        //soundManager.GetComponent<SoundManager>().source1.Play();
        setup = GameObject.FindGameObjectWithTag("SetupInfo").GetComponent<SetupInfo>();
        currentPlayerID = 0;
        playersCount = setup.playersCount;
        playersList[0].isMakingATurn = true;
        for (int i = 0; i < playersList.Count; i++)
        {
            if (i < playersCount)
            {
                playersList[i].isPlaying = true;
            }
            else
            {
                playersList[i].isPlaying = false;
            }
        }
        showTime = 0.5f;
        hand = GameObject.FindGameObjectWithTag("Hand");
        HideText(gameOverText);
        //HideText();
        
        resultOfDropping.text = "";
        restartButton = GameObject.FindGameObjectWithTag("Finish");
        
        restartButton.transform.localScale = new Vector3(0, 0, 0);
        //ShowText();
    }

    //void ShowText()
    //{
    //    currentPlayerName.text = playerName + " Игрок ходит";
       

    //}

    public void AddPointsToPlayer()
    {
        playersList[currentPlayerID].AddPoints();
    }

    public void ChangePlayer()
    {
       
        currentPlayerID++;
        if(currentPlayerID >= playersCount)
        { currentPlayerID = 0; }

        for (int i = 0; i < playersList.Count; i++)
        {
            if (i != currentPlayerID)
            {
                playersList[i].isMakingATurn = false;
            }
            else
            {
                playersList[i].isMakingATurn = true;
            }
        }
       
    }

    

    public void CardDropped(bool _onRigthPlace)
    {
        if (_onRigthPlace)
        {
           
            resultIndicator.IndicateResult(true);
            AddPointsToPlayer();
        }
        else
        {
           
            resultIndicator.IndicateResult(false);
        }
        ChangePlayer();
    }

    
    private void Update()
    {
        
        if (hand.transform.childCount == 0)
        {
            Invoke("GameOver", 2f);
        }
        
    }


    public void GameOver()
    {
        showTime = 20f;
        resultOfDropping.enableAutoSizing = true;
        hand.transform.localScale = new Vector3(0, 0, 0);

       
        HideText(currentPlayerName);
        ShowText(gameOverText);
        ShowRestartButton();
    }

    public void ReloadGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ShowRestartButton()
    {
        ShowResults();
        restartButton.GetComponent<RectTransform>().localScale = new Vector3(3,3,3);
    }

    void HideText(TextMeshProUGUI _text)
    {
        _text.transform.localScale = new Vector3(0, 0, 0);
    }

    void ShowText(TextMeshProUGUI _text)
    {
        _text.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Quit()
    {
        Destroy(soundManager);
        SceneManager.LoadScene("SampleScene");
        
    }


    public int FindBiggestScoreIndex()
    {
        int minIndex = 0;
        int maxIndex = 0;

        for (int i = 1; i < playersCount; i++)
        {
            if (playersList[i].Points <= playersList[minIndex].Points)
            {
                minIndex = i;
            }
            else
            {
                maxIndex = i;
            }
        }
        Debug.Log("Player " + (maxIndex + 1) + " has the biggest score");
        return maxIndex;

    }

    bool ChekIfAllScoresEqual( int _biggestIndex)
    {
        bool isEqual = false;

        for (int i = 0; i < playersCount; i++)
        {
            if (i != _biggestIndex)
            {
                if (playersList[_biggestIndex].Points == playersList[i].Points)
                {
                    isEqual = true;
                }
            }
           
        }

        return isEqual;
        
    }

    void ShowResults()
    {
        int biggestIndex = FindBiggestScoreIndex();
        if (playersCount > 1)
        {
            if (!ChekIfAllScoresEqual(biggestIndex))
            {
                resultsText.text = "ПОБЕДИЛ ИГРОК НОМЕР " + (biggestIndex + 1);
            }
            else
            {
                resultsText.text = "НИЧЬЯ";
            }
        }
        else
        {
            resultsText.text = "ИГРА ОКОНЧЕНА";
        }
    }
    
}
