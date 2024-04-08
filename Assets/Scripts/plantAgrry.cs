using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAgrry : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float timer;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();  
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            animator.SetTrigger("attack");
            timer = 0.0f;
        }
    }
    private void PlantShoot()
    {
        Instantiate(bullet,bulletPos.position, Quaternion.identity);
    }
}
