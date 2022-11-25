using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
public class playAnim: MonoBehaviour {  

    [SerializeField] private Animator controller;
    private void OnTriggerEnter(Collider dk) {
        if(dk.CompareTag("Player")) 
        {
            print("colliding");
            controller.SetBool("isColliding", true);
        }
    }  

    private void OnTriggerExit(Collider dk) {
        if(dk.CompareTag("Player")) 
        {
            controller.SetBool("isColliding", false);
            print("not colliding");

        }
    }  
}