using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGenarater : MonoBehaviour
{
    [SerializeField] private Transform leverPart_Start;
    [SerializeField] private Transform leverPart_1;
    private void Awake()
    {
        Transform lastLeverPartTransfrom;
        lastLeverPartTransfrom = SpawnLeverPart(leverPart_Start.Find("EndPositon").position);
        lastLeverPartTransfrom = SpawnLeverPart(lastLeverPartTransfrom.Find("EndPositon").position);
        lastLeverPartTransfrom = SpawnLeverPart(lastLeverPartTransfrom.Find("EndPositon").position);
        lastLeverPartTransfrom = SpawnLeverPart(lastLeverPartTransfrom.Find("EndPositon").position);
        lastLeverPartTransfrom = SpawnLeverPart(lastLeverPartTransfrom.Find("EndPositon").position);
    }
    private Transform SpawnLeverPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(leverPart_1, spawnPosition, Quaternion.Euler(0f, 360f, 0f));
        return levelPartTransform;
    }

}
