using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private Transform Player;
    private float dist;
    public float moveSpeed;
    public float howClose;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.position, transform.position);
        if(dist <= howClose)
        {
            transform.LookAt(Player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }
    }
}
