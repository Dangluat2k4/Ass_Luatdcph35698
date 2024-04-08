using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEnemy : MonoBehaviour
{
    public GameObject EnemyClone;

    public Transform EnemyPso;

    private void Start()
    {
        SpawnLeverPart();
    }
    public void SpawnLeverPart()
    {
        Instantiate(EnemyClone, EnemyPso.position, Quaternion.Euler(0,180,0));
    }
}
