using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boar : MonoBehaviour
{

    Rigidbody2D rb;
    public System.Action OnFlipped;
    public float attackCkeckRadius;
    [SerializeField]  Transform groundCheck;
    // groundCheck pham vi duoi chan
    [SerializeField]  float groundCheckDistance;
    // groundCheckDistance khoang cach kiem tra mat dat
    [SerializeField]  Transform wallCheck;
    // wallCheck kiem tra tuong truoc mat
    [SerializeField]  float wallCheckDistance;
    // wallCheckDistance khoang cach giua tuong
    [SerializeField]  LayerMask whatIsGround;
    [SerializeField] float moveSpeed;
    Animator anim;

    [Header("Health Manager")]
    public Image healthBar;
    public float heathAmount = 100f;

    // trai thai lat mat
    public int facingDir { get; private set; } = 1;
    // facingDir huong cua entity hien tai 
    protected bool facingRight = true;
    public  bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public  bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    protected  void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    public  void Flip() 
    {
        // dao nguoc trang thai 
        facingDir = facingDir * -1;
        // cap nhat trang thai cua facingRight true=> fasle and false=> true
        facingRight = !facingRight;
        // doi h??ng
        transform.Rotate(0, 180, 0);
        if (OnFlipped != null)
        {
            OnFlipped();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
        if(IsWallDetected() || !IsGroundDetected())
        {
            Flip();
        }
        anim.SetBool("IsRuning", true);
        if (heathAmount <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "builletCoin")
        {
            Debug.Log("va cham coin");
            TakeDame(50);
            Destroy(collision.gameObject);
        }
    }
    public void die()
    {
        SceneManager.LoadScene(1);
    }

    public void TakeDame(float dame)
    {
        heathAmount -= dame;
        healthBar.fillAmount = heathAmount / 100f;

    }
    public void Heal(float healingAmount)
    {
        heathAmount += healingAmount;
        heathAmount = Mathf.Clamp(heathAmount, 0, 100);
        healthBar.fillAmount = heathAmount / 100f;
    }
}
