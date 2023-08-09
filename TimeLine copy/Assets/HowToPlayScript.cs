using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public Transform howToPlaywindow;

    public void ShowWindow()
    {
        howToPlaywindow.localScale = new Vector3(1, 1, 1);
    }

    public void HideWindow()
    {
        howToPlaywindow.localScale = new Vector3(0,0,0);
    }

    public void Start()
    {
        HideWindow();
    }
}
