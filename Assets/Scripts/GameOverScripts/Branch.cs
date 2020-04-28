using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public TextAsset txt;

    public int startL;
    public int endDaL;

    public TXTscript txtBox;

    public bool destroy;

    public bool buttonPress;
    public bool waitForButton;

    //public GameObject box;
    public GameObject world;
    public GameObject npc;
   
    public GameObject Byes;
    public GameObject Bno;
    public GameObject BHeRight;
    public GameObject BHeLie;
    public GameObject Bdoom;
    public GameObject Blife;
    public GameObject Bevil;
    public GameObject Bhero;

    // Start is called before the first frame update
    void Start()
    {
        txtBox = FindObjectOfType<TXTscript>();

        Byes.SetActive(false);
        Bno.SetActive(false);
        BHeLie.SetActive(false);
        BHeRight.SetActive(false);
        Bdoom.SetActive(false);
        Blife.SetActive(false);
        Bhero.SetActive(false);
        Bevil.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForButton && Input.GetKeyDown(KeyCode.Return))
        {
            txtBox.reload(txt);
            txtBox.curL = startL;
            txtBox.endL = endDaL;
            txtBox.enableTXTbox();

            if (txtBox.count == 0)
            {
                txtBox.isBranch = true;
                Byes.SetActive(true);
                Bno.SetActive(true);
            }

            if (destroy)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (buttonPress)
            {
                waitForButton = true;
                return;
            }

            txtBox.reload(txt);
            txtBox.curL = startL;
            txtBox.endL = endDaL;
            txtBox.enableTXTbox();

            if (destroy)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            waitForButton = false;
        }
    }

    public void yes()
    {
        startL = 19;
        endDaL = 19;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();
    }

    public void no()
    {
        startL = 16;
        endDaL = 16;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();
    }

    public void next()
    {
        startL = 21;
        endDaL = 23;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();
    }

    public void lies()
    {
        startL = 26;
        endDaL = 28;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();

        txtBox.count = 10;
    }

    public void right()
    {
        startL = 31;
        endDaL = 33;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();
    }

    public void doom()
    {
        startL = 54;
        endDaL = 54;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();

        txtBox.isBranch = false;

        Destroy(world);
        Destroy(gameObject);
        Destroy(npc);
    }

    public void life()
    {
        startL = 36;
        endDaL = 37;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();
    }

    public void hero()
    {
        startL = 47;
        endDaL = 51;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();

        txtBox.count = 10;
    }

    public void evil()
    {
        startL = 40;
        endDaL = 44;
        txtBox.reload(txt);
        txtBox.curL = startL;
        txtBox.endL = endDaL;
        txtBox.enableTXTbox();

        
    }
    public void killed()
    {
        Destroy(world);
        Destroy(npc);
    }

    public void choice2()
    {
        BHeLie.SetActive(true);
        BHeRight.SetActive(true);
    }

    public void choice3()
    {
        Bdoom.SetActive(true);
        Blife.SetActive(true);
    }

    public void choice4()
    {
        Bhero.SetActive(true);
        Bevil.SetActive(true);
    }
}