using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinterScore : MonoBehaviour
{
    public Text score;
    public Text highScore;

    private int highScoreInt;
    private int scoreInt;

    // Start is called before the first frame update
    void Start()
    {
        highScoreInt = PlayerPrefs.GetInt("WinterHighScore");
        highScore.text = string.Format("Winter High Score: {0}", highScoreInt);
        scoreInt = PlayerPrefs.GetInt("Score");
        score.text = string.Format("Your Score: {0}", scoreInt);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
