using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeTXT : MonoBehaviour
{
    public TextAsset txt;

    public int startL;
    public int endDaL;

    public TXTscript txtBox;

    public bool destroy;

    public bool buttonPress;
    public bool waitForButton;

    // Start is called before the first frame update
    void Start()
    {
        txtBox = FindObjectOfType<TXTscript>();
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
}
