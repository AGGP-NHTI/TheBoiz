using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TXTBoxManager : MonoBehaviour
{
    public GameObject txtBox;
    public Text txt;
    public int curL;
    public int endL;

    public TextAsset txtFile;
    public string[] txtLines;

    public GameObject GameOver;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;

    public GameObject Byes;
    public GameObject Bno;

    public bool isYes = false;
    public bool isNo = false;
    
    int count = 0;

    public int coinCount;

    void Start()
    {
        Byes.SetActive(false);
        Bno.SetActive(false);

        coin1.SetActive(false);
        coin2.SetActive(false);
        coin3.SetActive(false);

        GameOver.SetActive(false);

        coinCount = PlayerPrefs.GetInt("Coins");

        if (txtFile != null)
        {
            txtLines = (txtFile.text.Split('\n'));
        }

        if (endL == 0)
        {
            endL = txtLines.Length - 1;
        }

        if (coinCount == 1 || coinCount == 2)
        {
            curL = 23;
            endL = 27;
        }

        if (coinCount == 0)
        {
            curL = 30;
            endL = 33;

            count += 1;
            isNo = true;
        }
    }

    void Update()
    {
        txt.text = txtLines[curL];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            curL += 1;
        }

        if (curL == 9|| curL == 25)
        {
            if (coinCount == 3)
            {
                coin1.SetActive(true);
                coin2.SetActive(true);
                coin3.SetActive(true);
            }
            if (coinCount == 2)
            {
                coin1.SetActive(true);
                coin2.SetActive(true);
            }
            if (coinCount == 1)
            {
                coin2.SetActive(true);
            }
        }

        if (curL > endL)
        {
            txtBox.SetActive(false);

            if (count == 0)
            {
                choice1();
            }

            if (count == 1)
            {
                changeSeen();
            }
        }
    }

    public void yes()
    {
        txtBox.SetActive(true);

        if (coinCount == 3)
        {
            Destroy(coin3);
        }
        if (coinCount == 2)
        {
            Destroy(coin1);
        }
        if (coinCount == 1)
        {
            Destroy(coin2);
        }

        curL = 16;
        endL = 16;

        coinCount--;
        PlayerPrefs.SetInt("Coins", coinCount);

        count += 1;

        isYes = true;
    }

    public void no()
    {
        txtBox.SetActive(true);
        curL = 19;
        endL = 20;

        count += 1;

        isNo = true;
    }

    public void choice1()
    {
        Bno.SetActive(true);
        Byes.SetActive(true);
    }

    public void changeSeen()
    {
        if (isNo == true)
        {
            GameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (isYes == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
