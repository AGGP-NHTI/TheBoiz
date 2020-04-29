using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public txtManager man;

    public int startL;
    public int endL;

    public GameObject Byes;
    public GameObject Bno;

    public bool isBra = true;

    public TextAsset Btxt;

    // Start is called before the first frame update
    void Start()
    {
        Byes.SetActive(false);
        Bno.SetActive(false);
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            man.reload(txt);
            man.curL = startL;
            man.endL = endL;
            man.enableTXTbox();
        }
    }*/

    public void giveCoi()
    {
        Byes.SetActive(true);
        Bno.SetActive(true);
    }

    public void yes()
    {
        startL = 17;
        endL = 17;
        man.reload(Btxt);
        man.curL = startL;
        man.endL = endL;
        man.enableTXTbox();
    }
}
