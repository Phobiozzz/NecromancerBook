using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragNdropDesktop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
   

    public RectTransform rectTransform;
    public bool aboveTimeLine;
   
    public Transform parentToReturn = null;
    public Transform placeholderParent = null;

    public GameObject placeholder = null;
    public Sprite placeholderIMG;
    GameObject gm;
    SoundManager soundManager;
    public GameObject effect;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        rectTransform = GetComponent<RectTransform>();
        parentToReturn = this.transform;
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        placeholder = new GameObject();
        placeholder.AddComponent<Image>().sprite = placeholderIMG;
        placeholder.GetComponent<Image>().color = Color.green;
        placeholder.transform.SetParent(this.transform.parent);
        
        
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeholder.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 450);
        placeholder.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());


        parentToReturn = this.transform.parent;
        placeholderParent = parentToReturn;
        this.transform.SetParent(this.transform.parent.parent);
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        soundManager.CardPick();

    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
        {
            placeholder.transform.SetParent(placeholderParent);
        }

        int sibIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                sibIndex = i;
                if (placeholderParent.transform.GetSiblingIndex() < sibIndex)
                {
                    sibIndex--;
                }
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(sibIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        this.transform.SetParent(parentToReturn);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
        soundManager.CardDrop();
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void DestroyEffect()
    {
        gameObject.GetComponent<ChangeColor>().StartBlink();
    }
    
    private void Update()
    {
        if (parentToReturn.tag == "Timeline")
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }
}
