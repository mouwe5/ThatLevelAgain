using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDetector : MonoBehaviour
{
    public bool playerDie;
    // Start is called before the first frame update
    void Start()
    {
        playerDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) // if you mark "trigger" in colider, it make that void works - Trigger when something (other) collide with that object
    {
        Debug.Log(playerDie +"1");
        if (other.tag == "Player")
        {
            playerDie = true;
            Debug.Log(playerDie + "2");

        }
    }
}
