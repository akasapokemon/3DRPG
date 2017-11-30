using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {
    public void GameStart(){
        SceneManager.LoadScene("Game");
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}

