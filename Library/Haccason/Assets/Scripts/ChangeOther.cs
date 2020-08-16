using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeOther : MonoBehaviour
{

    public Image imageCircle;

    public Sprite[] imageCircles;
    // Start is called before the first frame update
    void Start()
    {
        imageCircle.sprite = imageCircles[ButtonScript.CuisineGenre];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
