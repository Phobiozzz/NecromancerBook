using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningMessage : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    string exitMessage;
    string reloadMessage;
    string stopMessage;

    string currentMessage;
    int functionIndex;

    public ManagingTheGame gm;
    private void Start()
    {
        exitMessage = "ТОЧНО ВЫЙТИ?";
        reloadMessage = "ПЕРЕЗАГРУЗИТЬ УРОВЕНЬ?";
        stopMessage = "ОСТАНОВИТЬ ИГРУ?";
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<ManagingTheGame>();
        HideMessage();

    }

    public void ShowMessage(int _messageIndx)
    {
        switch (_messageIndx)
        {
            case 1:
                currentMessage = stopMessage;
                functionIndex = 1;
                break;
            case 2:
                currentMessage = exitMessage;
                functionIndex = 2;
                break;
            case 3:
                currentMessage = reloadMessage;
                functionIndex = 3;
                break;

        }
        textBox.text = currentMessage;
        transform.localScale = new Vector3(1, 1, 1);
        
    }

    public void HideMessage()
    {
        transform.localScale = new Vector3(0, 0, 0);
        currentMessage = "";
    }

    public void YesButtonClick()
    {
        switch (functionIndex)
        {
            case 1:
                gm.GameOver();
                break;
            case 2:
                gm.Quit();
                break;
            case 3:
                gm.ReloadGame();
                break;
        }
        HideMessage();
    }
}
