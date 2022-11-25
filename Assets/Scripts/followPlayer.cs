using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class followPlayer : MonoBehaviour {

    public NavMeshAgent enemy;
    public Transform Player;

    void Start () {
    }
    void Update () {
        enemy.SetDestination(Player.position);
    }
}