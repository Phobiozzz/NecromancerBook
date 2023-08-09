using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBuilder : MonoBehaviour
{
    public string deckName;
    public List<CardInfo> cards;

    public void CreateCard(string _description, int _year)
    {
        CardInfo newCard = new CardInfo(cards.Count+1, _description, _year);
        cards.Add(newCard);
    }

    public void DeleteCard(int _id)
    {
        cards.RemoveAt(_id - 1);
    }

    private void Start()
    {
        CreateCard("test", 1000);
        CreateCard("test2", 0);
    }
}
