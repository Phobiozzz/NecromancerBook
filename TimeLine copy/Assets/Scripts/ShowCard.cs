using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowCard : MonoBehaviour
{
    public string cardName;
    public Card card;

    public TextMeshProUGUI description;
    public TextMeshProUGUI year;
    public Image anim;
    private void Awake()
    {
        anim = GameObject.FindGameObjectWithTag("CardAnim").GetComponent<Image>();
    }

    public void SetValues()
    {
        description.text = card.Description;
        year.text = card.Year.ToString();
    }

    public void HideYear()
    {
        year.text = "";
    }

    public void ShowYear()
    {
        year.text = card.Year.ToString();
    }

    
}
