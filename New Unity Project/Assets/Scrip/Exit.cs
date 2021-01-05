﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ExitBall")
        {
            Application.Quit();
        }
    }
}