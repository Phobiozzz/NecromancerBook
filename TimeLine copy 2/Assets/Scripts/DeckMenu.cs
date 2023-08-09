using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckMenu : MonoBehaviour
{
   
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
       
    }
}
