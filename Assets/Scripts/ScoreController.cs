using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    Text textComponent;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GameObject.Find("sctext").GetComponent<Text>();
        this.textComponent.text = "score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int point)
    {
        score += point;
        this.textComponent.text = "score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
