using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HP.value++;
            Debug.Log("click");
        }   
    }
}
