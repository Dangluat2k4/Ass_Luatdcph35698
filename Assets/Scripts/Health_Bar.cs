using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_UI : MonoBehaviour
{
    private Boar boar;
    private RectTransform myTransfrom;
    private Image image;

    private void Start()
    {
        boar = GetComponentInParent<Boar>();
        image = GetComponentInChildren<Image>();
        myTransfrom = GetComponent<RectTransform>();

        boar.OnFlipped += FlipUI;
    }


    private void FlipUI()
    {
        myTransfrom.Rotate(0, 180, 0);
     //   Debug.Log("Flip");
    }
    private void OnDisable()
    {
        boar.OnFlipped -= FlipUI;

    }
}

