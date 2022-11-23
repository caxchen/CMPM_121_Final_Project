using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DetectPlayer : MonoBehaviour {

    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;

    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }
    void Update () {
        agent.destination = target.transform.position;
    }
    void OnTriggerEnter (Collider collision) {
        if (collision.tag == "Player")
            target = GameObject.FindGameObjectWithTag ("Player");
    }
}