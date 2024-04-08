using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmCoin : MonoBehaviour
{
    public Transform player;// anh xa toi nhan vat
    public GameObject coin;
    public float nextPosX;
    public float nextPosY;
    private float distanceCoin;
    public float curvature;// do cong
    public float height;

    public float heightSin;
    public float wightSin;
    public float timer;

    public float cooldownSpawm;
    public int CountCoin;
    public float minHeight;

    public Vector3 _nextPos;

    void Start()
    {
        distanceCoin = 20f;
        curvature = Random.Range(.8f, 1.3f);
        height = Random.Range(1f, 3f) + height;
        nextPosX = player.position.x + distanceCoin;
        cooldownSpawm = 5f;
        CountCoin = 10;
        minHeight = 2f;
        drawCoin2();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldownSpawm )
        {
            timer = 0;
        }
    }
    public void drawCoin2()
    {
        float _a;
        float _b;
        _a = Random.Range(0.1f, 0.3f);
        _b = Random.Range(-0.5f, 1f);
        _nextPos = player.position + new Vector3(distanceCoin, 3f, 0);
        int _countCoin = (int)(CountCoin / 2);
        for(int i = -1 * _countCoin; i <= _countCoin; i++)
        {
            Vector3 _toado = _nextPos + new Vector3(i + _countCoin, -1 * _a * i * i + _a * _countCoin * CountCoin / 4 + _b, 0f);
            Instantiate(coin,_toado,Quaternion.identity,transform);
        }
    }
}
 