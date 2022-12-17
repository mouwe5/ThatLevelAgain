using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Attach object from the project
    public float offset; // little bit in ofset
    private Vector3 playerPosition; // player position
    public float offsetSmoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); // same x like the player but not in y & z 
        //make the player stand not in the center of the camera, just little bit offset
      //  playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);// same x like the player but not in y & z 
        //if(player.transform.localScale.x>0f) // when the player go right, the camera go little bit more offset
      //  {
       //     playerPosition = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
     //   }
       // else// when the player go left, the camera go little bit more offset
       // {
      //      playerPosition = new Vector3(player.transform.position.x - offset, transform.position.y, transform.position.z);
     //   }
     //   transform.position = Vector3.Lerp(transform.position,playerPosition,offsetSmoothing*Time.deltaTime); // Update Camera line - put new position buy Playpoisition and do it with "Lerp" - make it smooth changing
    }
}
