using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start() {
        scoreText.text ="$" + score.ToString();
    }

    public void IncrementScore() {
        score = score + 1;
        scoreText.text = "$" + score.ToString();
    }
}
