using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    /*Hey guys it james trying to work out HUD*/
    public Text HUDHP;
    public PlayerStateMachine psm;
    /*********************************************/

    // Start is called before the first frame update
    void Start()
    {
        psm = FindObjectOfType<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Hey guys it james trying to work out HUD*/
        HUDHP.text = "HP: " + psm.health;
        /*********************************************/
    }
}
