using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5f,rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            Debug.Log(" cham player");
            Destroy(gameObject);

        }
    }
}
