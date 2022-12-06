 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 public class endGame : MonoBehaviour {
 
     void OnTriggerEnter(Collider Player)
     {
        Debug.Log("end");
        SceneManager.LoadScene("endScene");
        //Application.Quit();
     }
 }