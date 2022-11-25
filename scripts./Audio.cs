using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    void Update() {
        if (GameObject.Find("Manager").GetComponent<GameController>().gameHasEnded == true){
            Destroy(gameObject);
        }
    
        if (GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().GameIsPaused == true){
            GetComponent<AudioSource>().volume = 0.02f;
            
        }
        else {
            GetComponent<AudioSource>().volume = 0.1f;
        }
        
    }
}
