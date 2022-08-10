using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Text pointText;
    public 
    int pointValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Point: " + pointValue;
    }
    // Update is called once per frame
    public void AddPoint()
    {
        pointValue++;
        pointText.text = "Point: " + pointValue;
    } 
}
