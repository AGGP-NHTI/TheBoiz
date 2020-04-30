using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnSystem : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Zombie;
    public GameObject Cultist;
    public GameObject Bleemeay;
    int Selection;
    public GameObject[] spawners;
    public int maxMobs;
    public bool isactive;
    
    // Start is called before the first frame update
    void Start()
    {
        isactive = true;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponentInParent<PlayerStateMachine>())
        {
            if (isactive == true)
            {
                foreach (GameObject spawn in spawners)
                {
                    Selection = Random.Range(0, 2);

                    if (Selection == 0)
                    {
                        SpawnZombie(spawn.transform);
                    }
                    if (Selection == 1)
                    {
                        SpawnCultist(spawn.transform);
                    }
                    if (Selection == 2)
                    {
                        SpawnBleemeay(spawn.transform);
                    }
                }
                Debug.Log("I am here");
                isactive = false;

            }
        }
    }

    public void SpawnBleemeay(Transform spawnLoc)
    {
        Instantiate(Bleemeay, spawnLoc.position, Quaternion.identity);

    }
    public void SpawnCultist(Transform spawnLoc)
    {
        Instantiate(Cultist, spawnLoc.position, Quaternion.identity);

    }
    public void SpawnZombie(Transform spawnLoc)
    {
        Instantiate(Zombie, spawnLoc.position, Quaternion.identity);

    }
}

