using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameSetup");
    }

    public void OnDecksButtonClick()
    {
        SceneManager.LoadScene("DeckBuilder");
       
    }

    public void OnExitButtonClick()
    {
        
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
