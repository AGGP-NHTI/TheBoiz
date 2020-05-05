using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossspawnscript : MonoBehaviour
{
    public Transform SpawnPos;

    public GameObject Bossman;
    int Selection;
    public GameObject[] spawners;
    public int maxMobs;
    public bool isactive;

    // Start is called before the first frame update
    void Start()
    {
        isactive = true;
    }

    private void Update()
    {

    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<ProjectileScript>())
        {

        }
        else if (collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            if (isactive == true)
            {
                foreach (GameObject spawn in spawners)
                {



                  Spawnbossman(spawn.transform);
                  

                }
                Debug.Log("I am here");
                isactive = false;

            }
        }
    }

    public void Spawnbossman(Transform spawnLoc)
    {
        Instantiate(Bossman, spawnLoc.position, Quaternion.identity);

    }
}
