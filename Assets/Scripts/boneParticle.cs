using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            particleSystem.Play();
        }
    }

    private void OnParticleCollision(GameObject other){
        int events = particleSystem.GetCollisionEvents(other, colEvents);
        if (other.name == "DogKnight") {
            other.GetComponent<followPlayer>().Hit();
        }
        for(int i = 0; i < events; i++)
        {

        }
    }
    }
