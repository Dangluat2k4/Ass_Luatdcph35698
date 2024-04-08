using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Các biến cần lưu trữ
    private const string COIN_COUNT_KEY = "coinCount";

    // Start is called before the first frame update
    public float speed = 10f;
    [SerializeField] private float moveLeft = 2;
    private Rigidbody2D rb;
    private bool isRight = true;
    private Animator anim;
    [SerializeField] TextMeshProUGUI coinText;

    public GameObject gameOver;
    private int countCoin = 0; // Không cần SerializeField vì sẽ lưu vào PlayerPrefs

    [Header("Collistion info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    [Header("bullet ")]
    public GameObject bulletCoin;
    public Transform bulletPos;

    [Header("Health Manager")]
    public Image healthBar;
    public float heathAmount = 100f;

    [Header("Top run")]
    [SerializeField] private int top1Score;
    [SerializeField] private int top2Score;
    [SerializeField] private int top3Score;
    [SerializeField] private int HightC;

    int currentCoin;

    [SerializeField] TextMeshProUGUI top1Run;
    [SerializeField] TextMeshProUGUI top2Run;
    [SerializeField] TextMeshProUGUI top3Run;
    [SerializeField] TextMeshProUGUI HightCoin;

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }

    public void AddCoin(int coin)
    {
        countCoin += coin;
        currentCoin = countCoin;
        coinText.text = countCoin.ToString();
        // Lưu số tiền vào PlayerPrefs mỗi khi thay đổi
        PlayerPrefs.SetInt(COIN_COUNT_KEY, countCoin);

        // Kiểm tra và cập nhật điểm số cao nhất
        if (countCoin > top1Score)
        {
            top3Score = top2Score;
            top2Score = top1Score;
            top1Score = countCoin;
        }
        else if (countCoin > top2Score)
        {
            top3Score = top2Score;
            top2Score = countCoin;
        }
        else if (countCoin > top3Score)
        {
            top3Score = countCoin;
        }


        // Lưu điểm số cao nhất vào PlayerPrefs
        PlayerPrefs.SetInt("Top1Score", top1Score);
        PlayerPrefs.SetInt("Top2Score", top2Score);
        PlayerPrefs.SetInt("Top3Score", top3Score);
        PlayerPrefs.SetInt("HightC", currentCoin);
    }

    void Start()
    {
        // Khôi phục số tiền từ PlayerPrefs khi bắt đầu game
        countCoin = PlayerPrefs.GetInt(COIN_COUNT_KEY, 0);
        coinText.text = countCoin.ToString();


        // Khôi phục điểm số cao nhất từ PlayerPrefs
        top1Score = PlayerPrefs.GetInt("Top1Score", 0);
        top2Score = PlayerPrefs.GetInt("Top2Score", 0);
        top3Score = PlayerPrefs.GetInt("Top3Score", 0);
        // Hiển thị điểm số cao nhất trên UI
        top1Run.text = top1Score.ToString();
        top2Run.text = top2Score.ToString();
        top3Run.text = top3Score.ToString();

      //  HightCoin.text = currentCoin.ToString();
        Debug.Log(currentCoin);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        BulletCoin();
        if (heathAmount <= 0)
        {
            SceneManager.LoadScene(1);
        }
     //   Debug.Log(currentCoin);

    }

    public void PlayerMove()
    {
        moveLeft = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveLeft * speed, rb.velocity.y);
        bool playerHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("running", playerHorizontalSpeed);
        flip();
    }

    public void PlayerJump()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (IsGroundDetected())
            {
                rb.velocity += new Vector2(rb.velocity.x, 12f);
                Debug.Log("click");
            }
        }
    }

    // bullet coin
    public void BulletCoin()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (countCoin <= 0)
            {
                countCoin = 0;
                return;
            }
            else
            {
                AddCoin(-1);
                Instantiate(bulletCoin, bulletPos.position, Quaternion.identity);
            }
        }
    }

    void flip()
    {
        if (isRight && moveLeft < 0 || !isRight && moveLeft > 0)
        {
            isRight = !isRight;
            Vector3 playerDirection = transform.localScale;
            playerDirection.x = playerDirection.x * -1;
            transform.localScale = playerDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            Debug.Log("va cham");
            collision.gameObject.SetActive(false);
            AddCoin(1);
        }
        if (collision.CompareTag("footer") || collision.tag == "Boar")
        {
            Debug.Log("die");
            die();
        }
        if (collision.tag == "bulletPlant")
        {
            Debug.Log("bulletPlant");
            TakeDame(20);
            if (heathAmount < 0)
            {
                die();
            }

        }
        if(collision.tag == "Plant")
        {
            die();
        }
    }

    // Ghi đè hàm OnDestroy để đảm bảo lưu số tiền khi thoát game
    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
    public void die()
    {
        // Đặt điểm số về 0
        countCoin = 0;
        coinText.text = countCoin.ToString();
        gameOver.SetActive(true);
        Time.timeScale = 0;
        HightC = PlayerPrefs.GetInt("HightC", currentCoin);
        HightCoin.text = "Hight Coin :" + HightC.ToString();
        Debug.Log("zzzzzzzzzzz" + currentCoin);
        // Cập nhật điểm số cao nhất 
        AddCoin(0);

        // Load lại scene

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
