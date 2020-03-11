using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI ScoreText; 
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + scoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
