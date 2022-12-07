using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour {

    public NavMeshAgent enemy;
    public Transform Player;
    private bool hit = false;
    private float startSpeed;
    private float startAngularSpeed;
    private float speed;

    void Start () {
        startSpeed = enemy.speed;
        startAngularSpeed = enemy.angularSpeed;
        speed = startSpeed;
    }
    void Update () {
        //Debug.Log(enemy.speed.ToString()+"            ignore this number: "+UnityEngine.Random.Range(0f, 100f).ToString());
        enemy.SetDestination(Player.position);
    }

    public void Hit() {
        if (!hit) {
            //Debug.Log("got hit"+"            ignore this number: "+UnityEngine.Random.Range(0f, 100f).ToString());
            StartCoroutine(hitCoroutine());
        }
    }

    IEnumerator hitCoroutine()
    {
        hit = true;
        float slowdown = 0.1f;
        enemy.speed *= slowdown;
        enemy.angularSpeed /= slowdown;
        yield return new WaitForSeconds(3);
        enemy.speed = startSpeed;
        enemy.angularSpeed = startAngularSpeed;
        hit = false;
    }
}