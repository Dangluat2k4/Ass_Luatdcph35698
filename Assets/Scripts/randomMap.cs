using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
    public List<GameObject> listGround;
    public Transform player;
    Vector3 endPos;// vi tri cuoi cung
    Vector3 nextPost;
    public float rangeToDestroyObject = 60f;
    public List<GameObject> listGroundOld;
    public int groundLen;
    public Vector3 _nextPos;
    public int CountCoin;
    private float distanceCoin;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        distanceCoin = 10f;
        CountCoin = 10;
        endPos = new Vector3(0, 0, 0);
        GenatateBlock();

    }



    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position,endPos)< rangeToDestroyObject)
        {
            GenatateBlock();
            drawCoin2();
        }
        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }
    void GenatateBlock()
    {
        for (int i = 0; i < 5; i++)
        {
            float spaceJump = Random.Range(0f, 2f);// khoang cach ngau nhieu giua cac block
            float heightMap = Random.Range(0f, 3f);
            nextPost = new Vector3(endPos.x + spaceJump, heightMap, 0f);
            // tao so nguyen nhau nhien trong khoang tu a-b khong bao gom b
            int groundID = Random.Range(0, listGround.Count);
            // tao ra block ban do ngau nhien
            GameObject newGround = Instantiate(listGround[groundID], nextPost, Quaternion.identity, transform);
            listGroundOld.Add(newGround);
            switch (groundID)
            {
                case 0: groundLen = 10; break;
                case 1: groundLen = 10; break;
                case 2: groundLen = 10; break;
                case 3: groundLen = 3; break;
            }
            endPos = new Vector3(nextPost.x + groundLen, -2f, 0f);
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
        for (int i = -1 * _countCoin; i <= _countCoin; i++)
        {
            Vector3 _toado = _nextPos + new Vector3(i + _countCoin -3f, -1 * _a * i * i + _a * _countCoin * CountCoin / 4 + _b, 0f);
            Instantiate(coin, _toado, Quaternion.identity, transform);
        }
    }
}
