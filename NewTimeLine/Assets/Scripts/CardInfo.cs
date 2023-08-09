using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    public int ID;
    public string description;
    public int year;

    public CardInfo(int _id, string _description, int _year)
    {
        this.ID = _id;
        this.description = _description;
        this.year = _year;
    }
}
