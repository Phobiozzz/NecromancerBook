using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckInfo 
{
    public string name;
    public List<CardInfo> cards;

    public DeckInfo(string _name)
    {
        name = _name;
        cards = new List<CardInfo>();
    }

   
}
