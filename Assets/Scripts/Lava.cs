using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*********************************/
/*Hey guys its james im just working on the Game over scean*/
using UnityEngine.SceneManagement;
/******************************************/
public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            collision.transform.GetComponentInParent<PlayerStateMachine>().isAlive = false;
            /*********************************/
            /*Hey guys its james im just working on the Game over scean*/
            if (collision.name == "player")
            {
                SceneManager.LoadScene("Charon");
            }
            /******************************************/
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
