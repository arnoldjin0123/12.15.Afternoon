using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntoBaseStage : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ball")
        {
            SceneManager.LoadScene("BaseLevel");
            Debug.Log("GameStart");
        }
    }

}
