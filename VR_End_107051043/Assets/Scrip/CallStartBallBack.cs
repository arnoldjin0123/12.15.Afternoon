using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallStartBallBack : MonoBehaviour
{
    public GameObject StartBall;

    public void CallBallBack()
    {
        StartBall.transform.position = new Vector3(6f,63.2f,11f);
    }
}
