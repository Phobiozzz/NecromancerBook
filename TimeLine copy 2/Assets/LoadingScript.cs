using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadingScript : MonoBehaviour
{
    bool onLoad;

    public float speed;

    public Image slider;

    public float currentValue;
    public float maxValue;

    public TextMeshProUGUI loadingText;
    string deckPreparing;
    string deckShuffling;
    string cardsPreparing;
    string statrtingTimeLine;

    public void Start()
    {
        onLoad = true;
        currentValue = 0;

        statrtingTimeLine ="Запускаем машину времени...";
        deckPreparing ="Ищем коллоду...";
        deckShuffling ="Тасуем коллоду...";
        cardsPreparing ="Раздаем карты...";
    }


    void Loading()
    {
        if (onLoad)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (currentValue < maxValue)
            {
                speed = Random.Range(3, 50);
                currentValue += speed * Time.deltaTime;
            }
            else
            {
                onLoad = false;

            }
            slider.fillAmount = currentValue / maxValue;
        }
        else
        {
            currentValue = 0;
            transform.localScale = new Vector3(0, 0, 0);
        }
    }

    private void Update()
    {
        Loading();
        if (slider.fillAmount <= 0.25f && slider.fillAmount >= 0)
        {
            loadingText.text = statrtingTimeLine;
        }
        else if (slider.fillAmount <= 0.5f && slider.fillAmount > 0.25f)
        {
            loadingText.text = deckPreparing;
        }
        else if (slider.fillAmount <= 0.75f && slider.fillAmount > 0.5f)
        {
            loadingText.text = deckShuffling;
        }
        else
        {
            loadingText.text = cardsPreparing;
        }
    }
}
