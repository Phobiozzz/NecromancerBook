using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DeckBuilder : MonoBehaviour
{

    public List<CardInfo> cardInfos;

    public void AddCard(string _name, string _value)
    {
        CardInfo card = new CardInfo(_name, _value);
        cardInfos.Add(card);

    }

    public void CreateDeck(string _name)
    {
        string path = Application.dataPath + "/" + _name;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            Debug.Log("The folder already exist");
        }


    }

   
}
