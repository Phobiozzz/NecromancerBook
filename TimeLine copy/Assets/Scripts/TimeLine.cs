using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TimeLine : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public List<GameObject> cardsOnTimeLine;
    
    GameObject card;
    ManagingTheGame gm;
    SoundManager sm;

    
    public void OnDrop(PointerEventData eventData)
    {
        card = eventData.pointerDrag.gameObject;
        
        if (card != null)
        {
            card.GetComponent<DragNdropDesktop>().DestroyEffect();
            Transform hand = card.GetComponent<DragNdropDesktop>().parentToReturn;
            //Debug.Log("Dropped Card Parent is " + hand.tag);
            card.GetComponent<DragNdropDesktop>().parentToReturn = this.transform;
            card.GetComponent<ShowCard>().ShowYear();
            Invoke("CardVerifyier", 0.5f);
            if (hand.transform.childCount == 0)
            {
                //Debug.Log("Hand has " + hand.childCount + " children. Starting to game over");
                //gm.GameOver();
            }
           
        }
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        { return; }
        card = eventData.pointerDrag.gameObject;
        if (card != null)
        {
            card.GetComponent<DragNdropDesktop>().placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag == null)
        { return; }
        card = eventData.pointerDrag.gameObject;
        if (card != null && card.GetComponent<DragNdropDesktop>().placeholderParent == this.transform)
        {
            card.GetComponent<DragNdropDesktop>().placeholderParent = card.GetComponent<DragNdropDesktop>().parentToReturn;
            
        }
    }

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<ManagingTheGame>();
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }


    
    List<GameObject> GetAllChildren()
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            list.Add(transform.GetChild(i).gameObject);
        }

        return list;
    }

    

    
    public void SwapCards(GameObject _card1, GameObject _card2)
    {
        int helpingIndex = _card1.transform.GetSiblingIndex();
        _card1.transform.SetSiblingIndex(_card2.transform.GetSiblingIndex());
        _card2.transform.SetSiblingIndex(helpingIndex);
    }


    bool CompareValues( List<GameObject> _cardsArray, int _indexCurrentCard)
    {
        if(_cardsArray.Count == 1)
        {
            return true;
        }
        if(_indexCurrentCard == 0)
        {
            return _cardsArray[_indexCurrentCard].GetComponent<ShowCard>().card.Year <= _cardsArray[_indexCurrentCard + 1].GetComponent<ShowCard>().card.Year;
        }
        if(_indexCurrentCard == _cardsArray.Count - 1)
        {
            return _cardsArray[_indexCurrentCard].GetComponent<ShowCard>().card.Year >= _cardsArray[_indexCurrentCard - 1].GetComponent<ShowCard>().card.Year;
        }
        return (_cardsArray[_indexCurrentCard].GetComponent<ShowCard>().card.Year <= _cardsArray[_indexCurrentCard + 1].GetComponent<ShowCard>().card.Year)
            && (_cardsArray[_indexCurrentCard].GetComponent<ShowCard>().card.Year >= _cardsArray[_indexCurrentCard - 1].GetComponent<ShowCard>().card.Year);

    }

    void CardVerifyier()
    {
        cardsOnTimeLine = GetAllChildren();
        int sibilingIndexCurrentCard = card.transform.GetSiblingIndex();

        if (!CompareValues(cardsOnTimeLine, sibilingIndexCurrentCard))
        {
            gm.CardDropped(false);
            sm.CardSignal(false);
            SortTimeLine();
        }
        else
        {
            gm.CardDropped(true);
            sm.CardSignal(true);
            sm.Bubbles();
        }

    }

    public void SortTimeLine()
    {
        cardsOnTimeLine = GetAllChildren();
        
        for (int i = 1; i < cardsOnTimeLine.Count; i++)
        {
            
            for (int j = 0; j < cardsOnTimeLine.Count - i; j++)
            {
                
                if (cardsOnTimeLine[j].GetComponent<ShowCard>().card.Year > cardsOnTimeLine[j + 1].GetComponent<ShowCard>().card.Year)
                {
                    
                    SwapCards(cardsOnTimeLine[j], cardsOnTimeLine[j + 1]);
                    cardsOnTimeLine = GetAllChildren();
                }
            }
        }
    }


    

}
