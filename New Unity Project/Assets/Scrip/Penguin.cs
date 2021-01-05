using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Penguin : MonoBehaviour
{
    [Header("MovingSpeed"), Range(0, 50)]
    public float speed = 3f;
    [Header("StopDistance"), Range(0, 3)]
    public float StopDistance = 2.5f;

    private Transform ball;
    private Transform player;
    private NavMeshAgent nav;
    private Animator PenAni;

    public GameObject PetBall;
    public GameObject Bitball;
    private bool ballDissplay=false; //True=ball can see, False=ball can't see
    private bool target=false; //False=target is ball, true=target is player

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        PenAni = GetComponent<Animator>();

        ball = GameObject.Find("PetBall").transform;
        player = GameObject.Find("Player").transform;
        nav.speed = speed;
        nav.stoppingDistance = StopDistance;
    }

    void Update()
    {
        Track();
    }

    private void Track()
    {
        nav.SetDestination(ball.position);
        Debug.Log("Penguin and ball's distance" + nav.remainingDistance);
        if (nav.remainingDistance<=StopDistance && ballDissplay==true)
        {
            PetBall.SetActive(false);
            ballDissplay = false;
            Bitball.SetActive(true);
            nav.SetDestination(player.position);
        }
        if (nav.remainingDistance <= StopDistance && ballDissplay == false)
        {
            PetBall.SetActive(true);//將球的位子更改到企鵝前方並顯示出來
            ballDissplay = true;
        }
        PenAni.SetBool("Walk", nav.remainingDistance > StopDistance);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

}
