using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtManager : MonoBehaviour
{
    public GameObject txtBox;
    public Text txt;
    public int curL;
    public int endL;

    public TextAsset txtFile;
    public string[] txtLines;

    public bool isActive;

    private bool isType = false;
    private bool cancType;
    public float typeSpeed;

    public Branch bra;

    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public int coinPoss = 3;

    // Start is called before the first frame update
    void Start()
    {
        bra = FindObjectOfType<Branch>();

        coin1.SetActive(false);
        coin2.SetActive(false);
        coin3.SetActive(false);

        if (txtFile != null)
        {
            txtLines = (txtFile.text.Split('\n'));
        }

        if (endL == 0)
        {
            endL = txtLines.Length - 1;
        }

        if (isActive)
        {
            enableTXTbox();
        }
        else
        {
            disableTXTbox();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        //txt.text = txtLines[curL];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isType)
            {
                curL += 1;

                if(curL == 10)
                {
                    coin1.SetActive(true);
                    coin2.SetActive(true);
                    coin3.SetActive(true);
                }

                if (curL > endL)
                {
                    disableTXTbox();
                }
                else
                {
                    StartCoroutine(txtScroll(txtLines[curL]));
                }
            }
            else if (isType && !cancType)
            {
                cancType = true;
            }
        }
    }

    private IEnumerator txtScroll(string lineOtxt)
    {
        int letter = 0;
        txt.text = "";
        isType = true;

        while (isType && !cancType && (letter < lineOtxt.Length - 1))
        {
            txt.text += lineOtxt[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        txt.text = lineOtxt;
        isType = false;
        cancType = false;
    }

    public void enableTXTbox()
    {
        txtBox.SetActive(true);
        isActive = true;

        StartCoroutine(txtScroll(txtLines[curL]));
    }

    public void disableTXTbox()
    {
        if(!bra.isBra)
        {
            txtBox.SetActive(false);
        }
        if (bra.isBra)
        {
            bra.giveCoi();
            txtBox.SetActive(false);
        }
    }

    public void reload(TextAsset txt)
    {
        if (txt != null)
        {
            txtLines = new string[1];
            txtLines = (txt.text.Split('\n'));
        }
    }
}
