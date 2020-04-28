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
            Debug.Log("player hit lava");
            PlayerStateMachine temp = collision.transform.GetComponentInParent<PlayerStateMachine>();
            temp.isAlive = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
