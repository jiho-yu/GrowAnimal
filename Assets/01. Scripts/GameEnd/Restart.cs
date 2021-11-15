using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void GameRestart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}
