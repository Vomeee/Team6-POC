using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;

    void Start()
    {
        Invoke("ActiveEnemy", 0.2f);
    }

    void ActiveEnemy()
    {
        EnemyToSpawn.SetActive(true);
    }
}
