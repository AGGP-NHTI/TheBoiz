using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*********************************/
    /*Hey guys its james im just working on the Game over scean*/
    public int coinPoss;
    /******************************************/

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        /*********************************/
        /*Hey guys its james im just working on the Game over scean*/
        PlayerPrefs.SetInt("Coins", coinPoss);
        /******************************************/
    }

    public void menureturn()
    {
        SceneManager.LoadScene(0);
    }


public void quitgame()
    {
        Application.Quit();
    }
}
