using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            collision.transform.GetComponentInParent<PlayerStateMachine>().isAlive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
