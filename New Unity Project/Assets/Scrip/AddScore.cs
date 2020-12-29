using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour
{
    private int ScoreVal=0;
    public Text RScoreBoard;
    public Text LScoreBoard;
    public AudioSource AudioScore2;
    public AudioSource AudioScore3;

    private void Start()
    {
        Scoredisplay();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Ball3")
        {
            Debug.Log("ScoreAdd3");
            ScoreVal +=3;
            AudioScore3.Play();
            Scoredisplay();
        }
        if (col.tag == "Ball2")
        {
            Debug.Log("ScoreAdd2");
            ScoreVal +=2;
            AudioScore2.Play();
            Scoredisplay();
        }
    }

    void Scoredisplay()
    {
        Debug.Log("UpdateScore");
        RScoreBoard.text = "Your score:\n" + ScoreVal;
        LScoreBoard.text = "Your score:\n" + ScoreVal;
    }
}
