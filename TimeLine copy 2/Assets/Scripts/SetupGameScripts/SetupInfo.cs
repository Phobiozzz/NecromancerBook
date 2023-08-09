using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInfo : MonoBehaviour
{
    public int playersCount;
    public int scoreToWin;
    public List<Card> deck;
    public List<string> decknames;
    public string discoveriesDeckName;
    public List<Card> discoveries;
    public string allCardsName;
    public List<Card> allCardsDeck;
    public string historyDeckName;
    public List<Card> history;
    

    public int index;

    public void Start()
    {
        playersCount = 2;
        scoreToWin = 5;
        discoveriesDeckName = "Открытия";
        allCardsName = "Все Карты";
        historyDeckName = "Мировая История";
        decknames.Add(discoveriesDeckName);
        decknames.Add(allCardsName);
        decknames.Add(historyDeckName);
        //deck = allCardsDeck;
        SetDeck(0);

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetDeck(int _deckIndx)
    {

        if (_deckIndx == 0)
        { 
            deck = discoveries;
        }
        else if (_deckIndx == 1)
        {
            
            deck = history;
        }
        else if (_deckIndx == 2)
        {
            deck = allCardsDeck;
        }

        index = _deckIndx;
    }

    void CopyDeck(List<Card> _deckToCopy)
    {
        for (int i = 0; i < _deckToCopy.Count; i++)
        {
            deck.Add(_deckToCopy[i]);
        }
    }

    public void Update()
    {
       
    }

    
}
