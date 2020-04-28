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
    
    // Start is called before the first frame update
    void Start()
    {
        Selection = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
       if(Selection == 0)
       {
            SpawnZombie();
       }
       if(Selection == 1)
       {
            SpawnCultist();
       }
       if(Selection == 2)
       {
            SpawnBleemeay();
       }
    }

    public void SpawnBleemeay()
    {
        Instantiate(Bleemeay, transform.position, Quaternion.identity);
    }
    public void SpawnCultist()
    {
        Instantiate(Cultist, transform.position, Quaternion.identity);
    }
    public void SpawnZombie()
    {
        Instantiate(Zombie, transform.position, Quaternion.identity);
    }
}

