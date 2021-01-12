using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonEvent : MonoBehaviour
{
    public GameObject pet;
    public GameObject petball;
    public void ResetPetAndBall()
        {
        pet.transform.position = new Vector3(-0.2862205f, 0.9522928f, 18.99f);
        pet.transform.Rotate(0, 180f, 0f);
        petball.transform.position = new Vector3(-0.3145199f, 1.88f, 17.22f);
        }
}
