using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCoin : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag ==("Plant"))
        {
            Debug.Log("va cham");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == ("tileMap"))
        {
            Destroy(gameObject);
            Debug.Log("va cham");
        }
    }
}
