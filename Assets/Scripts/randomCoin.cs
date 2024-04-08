using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomCoin : MonoBehaviour
{
    public List<GameObject> listCoin;
    public Transform player;
    Vector3 endPos;
    Vector3 nextPost;
    public float rangToDestroyCoin = 60f;
    public List<GameObject> listCoinOld;
    int coin;

     void Start()
    {
        endPos = new Vector3(0, 0, 0);
        genatateCoin();
    }
     void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangToDestroyCoin)
        {
            genatateCoin();
        }
        GameObject getOneGround = listCoinOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > + rangToDestroyCoin)
        {
            listCoinOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    } 
     void genatateCoin()
    {
        for (int i = 0; i < 5; i++)
        {
            float spaceJump = Random.Range(1f, 2f);// khoang cach ngau nhieu giua cac block
            nextPost = new Vector3(endPos.x + spaceJump, 1f, 0f);
            // tao so nguyen nhau nhien trong khoang tu a-b khong bao gom b
            int groundID = Random.Range(0, listCoin.Count);
            // tao ra block ban do ngau nhien
            GameObject newGround = Instantiate(listCoin[groundID], nextPost, Quaternion.identity, transform);
            listCoinOld.Add(newGround);
            switch (groundID)
            {
                case 0: coin = 1; break;
                case 1: coin = 1; break;
                case 2: coin = 1; break;
            }
            endPos = new Vector3(nextPost.x + coin, 2f, 0f);
        }
    }
}
