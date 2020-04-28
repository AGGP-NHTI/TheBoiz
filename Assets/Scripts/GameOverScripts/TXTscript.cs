using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TXTscript : MonoBehaviour
{
    public GameObject txtBox;
    public Text txt;
    public int curL;
    public int endL;

    public TextAsset txtFile;
    public string[] txtLines;

    public bool isActive;
    public bool stopMov;

    public movement Pmov;

    public Branch scr;

    private bool isType = false;
    private bool cancType;
    public float typeSpeed;

    public bool isBranch = false;
    public int count = 0;

    void Start()
    {
        Pmov = FindObjectOfType<movement>();

        scr = FindObjectOfType<Branch>();

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

        while(isType && !cancType && (letter < lineOtxt.Length - 1))
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

        if (stopMov)
        {
            Pmov.canMov = false;
        }

        StartCoroutine(txtScroll(txtLines[curL]));
    }

    public void disableTXTbox()
    {
        if (isBranch)
        {
            count += 1;
            scr.next();
            
            if (count == 2)
            {
                txtBox.SetActive(false);
                scr.choice2();
            }
            if (count == 3)
            {
                txtBox.SetActive(false);
                scr.choice3();
            }
            if (count == 4)
            {
                txtBox.SetActive(false);
                scr.choice4();
            }
            if(count == 5)
            {
                txtBox.SetActive(false);
                scr.killed();
            }
            if (count > 10)
            {
                txtBox.SetActive(false);
            }
        }
        if(!isBranch)
        {
            txtBox.SetActive(false);
            isActive = false;
            Pmov.canMov = true;
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