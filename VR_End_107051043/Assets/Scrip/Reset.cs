using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag=="ResetBall")
        {
            SceneManager.LoadScene("BaseLevel");
        }
    }

}
