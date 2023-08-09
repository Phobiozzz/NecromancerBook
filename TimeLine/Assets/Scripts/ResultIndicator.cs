using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultIndicator : MonoBehaviour
{
    public Image Lamp;
    public Image Halo;

    public Color trueColor;
    public Color falseColor;
    public Color neutralColor;

   

    private void Start()
    {
        Lamp.color = neutralColor;
        Halo.color = neutralColor;
    }

    public void IndicateResult(bool _result)
    {
        if (_result)
        {
            Lamp.color = trueColor;
            Halo.color = trueColor;
        }
        else if (!_result)
        {
            Lamp.color = falseColor;
            Halo.color = falseColor;
        }

        Invoke("ChangeColorToNeutral", 1f);
    }

    void ChangeColorToNeutral()
    {
        Lamp.color = neutralColor;
        Halo.color = neutralColor;
    }

    public void IndicatePlayer( bool _isMakingTurn)
    {
        if (_isMakingTurn)
        {
            Lamp.color = trueColor;
            Halo.color = trueColor;
        }
        else if (!_isMakingTurn)
        {
            Lamp.color = falseColor;
            Halo.color = falseColor;
        }

    }

}
