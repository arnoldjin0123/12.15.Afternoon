using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Penguin : MonoBehaviour
{
    //追蹤可調參數
    [Header("MovingSpeed"), Range(0, 50)]
    public float speed = 3f;
    [Header("StopDistance"), Range(0, 3)]
    public float StopDistance = 2.5f;
    //指定欄位
    private Transform ball;
    private Transform player;
    private NavMeshAgent nav;
    private Animator PenAni;
    //切換目標所需元件
    public GameObject PetBall;
    public GameObject Bitball;
    public GameObject PlayerPositive;
    private bool PetballDissplay=true;  //True=Petball can see, False=Petball can't see
    private int TargetSwitch = 0;
    //計時器元件
    float Timer_f = 0f;


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
        timer();
        Track();
        PetballEvent();
        TargetChange();
    }

    private void Track()
    {
        Debug.Log("Penguin and Targit distance" + nav.remainingDistance);
        PenAni.SetBool("Walk", nav.remainingDistance > StopDistance);
    }//Debug企鵝和目標距離, 依距離判斷走路動畫

    private void PetballEvent()
    {
        if (PetballDissplay == true) 
        {
            Bitball.SetActive(false);
            PetBall.SetActive(true);
            nav.SetDestination(ball.position);
            Debug.Log("Ball is the targit");
        }//嘴上的球不顯示, 可丟的球顯示, 追蹤目標為可丟的球

        if (PetballDissplay == false) 
        {
            Bitball.SetActive(true);
            PetBall.SetActive(false);
            nav.SetDestination(player.position);
            Debug.Log("player is the targit");
        }//嘴上的球顯示, 可丟的球不顯示,追蹤目標為可丟的球
    } //可丟的球顯示與不顯示各自的事件

    private void timer()
    {
            Timer_f += Time.deltaTime;
            Debug.Log("Time" + Timer_f);
    }

    private void TargetChange()
    {
        if (nav.remainingDistance>2 && TargetSwitch == 0)
        {
            TargetSwitch++;
            Debug.Log("TargetSwitch:"+ TargetSwitch);
        }
        if (nav.remainingDistance<2 && TargetSwitch==1)
        {
            PetballDissplay = false;
            TargetSwitch++;
            Debug.Log("TargetSwitch:" + TargetSwitch);
            Timer_f = 0f;
        }
        if (nav.remainingDistance < 2 && TargetSwitch == 2 &&Timer_f>2f)
        {
            TargetSwitch = 0;
            PetballDissplay = true;
            Vector3 move = PlayerPositive.transform.position;
            move = new Vector3(move.x, move.y, move.z + 0.5f);
            PetBall.transform.position = move;
            PetballDissplay = true;
            Debug.Log("TargetSwitch:" + TargetSwitch);
        }
    }

    public void PetReset()
    {
        TargetSwitch = 0;
        Timer_f = 0f;
        PetballDissplay = true;
        Debug.Log("ResetPet");
    }

}
