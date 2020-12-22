using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private int ScoreVal=0;
    public Text RScoreBoard;
    public Text LScoreBoard;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Ball3")
        {
            ScoreVal =ScoreVal+3;
        }
        if (col.tag == "Ball2")
        {
            ScoreVal = ScoreVal + 2;
        }
    }

    void Start()
    {
        RScoreBoard.text = "Your score:/n" + ScoreVal;
        RScoreBoard.text = LScoreBoard.text;
    }
}
