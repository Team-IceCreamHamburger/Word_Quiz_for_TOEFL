using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }


    public void GameStart() {
        SceneManager.LoadScene(1);
    }

    public void Edit() {
        
    }


    public void Exit() {
        Application.Quit();
    }
}
