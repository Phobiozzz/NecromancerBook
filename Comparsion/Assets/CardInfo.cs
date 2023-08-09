using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo 
{
    public string cardName;
    public int value;

    public CardInfo(string _name, string _value)
    {
        cardName = _name;
        value = int.Parse(_value);
    }
}
