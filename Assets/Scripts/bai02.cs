using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bai02 : MonoBehaviour
{
    // gui giai quyet van de giao dien nguoi dung
    private void OnGUI()
    {
        GUI.Box(new Rect(30, 10, 200, 80), "Main Menu");
        //  GUI.Box(new Rect(10, 50, 300, 100), "Main Menu");
        if (GUI.Button(new Rect(40, 20, 80, 30), "Play Game"))
        {
            SceneManager.LoadScene(1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
