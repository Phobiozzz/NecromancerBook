using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{
    GameObject setup;
    public string deckName;
    public List<Card> cards;
    public GameObject cardPrefab;

    public GameObject timeLineObj;
    public GameObject handObj;
    

    bool setParent;
    int deckCount;
   

    private void Start()
    {
        setup = GameObject.FindGameObjectWithTag("SetupInfo");
        timeLineObj = GameObject.FindGameObjectWithTag("Timeline");
        handObj = GameObject.FindGameObjectWithTag("Hand");
        cards = setup.GetComponent<SetupInfo>().deck;
        deckCount = cards.Count;

        ShuffleDeck();

        for (int i = 0; i < deckCount; i++)
        {
            if (i == 0)
            {
                setParent = true;

            }
            else
            {
                setParent = false;
            }

            CreateCard(i);
           
        }

       
    }


    
    public void CreateCard(int _index)
    {

        GameObject cardParent;
        if (setParent)
        {
            cardParent = timeLineObj;
        }
        else
        {
            cardParent = handObj;
        }

        GameObject newCard = Instantiate(cardPrefab, cardParent.transform);

        //int rndm = Random.Range(0, cards.Count - 1);

        
        newCard.GetComponent<ShowCard>().card = cards[_index];
        newCard.GetComponent<ShowCard>().SetValues();
        if (cardParent == handObj)
        {
            newCard.GetComponent<ShowCard>().HideYear();
        } 
        else
        {
            newCard.GetComponent<ShowCard>().ShowYear();
            newCard.GetComponent<DragNdropDesktop>().parentToReturn = timeLineObj.transform;
        }

        //cards.RemoveAt(rndm);
    }


    void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int rndm = Random.Range(0, cards.Count - 1);
            if (rndm != i)
            {
                Card temp = cards[i];
                cards[i] = cards[rndm];
                cards[rndm] = temp;
            }
        }
    }

}
