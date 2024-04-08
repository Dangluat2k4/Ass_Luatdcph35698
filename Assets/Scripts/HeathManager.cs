using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathManager : MonoBehaviour
{
    public Image healthBar;
    public float heathAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            TakeDame(20);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Heal(5);
        }

    }
    public void TakeDame(float dame)
    {
        heathAmount -= dame;
        healthBar.fillAmount = heathAmount / 100f;

    }
    public void Heal( float healingAmount)
    {
        heathAmount += healingAmount;
        heathAmount  = Mathf.Clamp(heathAmount, 0, 100);
        healthBar.fillAmount = heathAmount/100f; 
    }
}
