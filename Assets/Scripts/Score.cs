using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    public Text yourScore;
    public Text highScore;

    private int hScore;
    private int yScore;

    public BallRoller player;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        yScore = player.FinalCount();
        yourScore.text = string.Format("{0}", yScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
