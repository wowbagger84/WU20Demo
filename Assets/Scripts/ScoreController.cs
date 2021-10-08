using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
