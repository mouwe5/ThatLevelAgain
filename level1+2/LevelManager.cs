using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text option
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay; // the amout of time the player can respawn
    public PlayerController gamePlayer;
    public MainButtonController mainButtonController;
    public LayerMask badGuys; //Layer OF Threath
    public Collider2D player; // playerCollider
    public bool playerDie; //If playerDie
    public GameObject door; // the ending door
    public Text scoreText; // score text
    public bool firstTimeInLevel; // check you first time in level - for run setting in the first time



    // Start is called before the first frame update
    void Start()
    {
        

        gamePlayer = FindObjectOfType<PlayerController>(); // Load Object
        mainButtonController = FindObjectOfType<MainButtonController>(); // Load Object
        playerDie = false;

        /////////////////////////////////// level text///////////////////////////
        if (SceneManager.GetActiveScene().buildIndex == 0) // set up level 1 settings - put the number of the level in counter by scene number
        {
            Level1();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)// set up level 2 settings- put the number of the level in counter by scene number
        {
            
            Level2();
        }
    }

    // Update is called once per frame
    void Update() // Running All the time
    {

        if (player.IsTouchingLayers(badGuys)) // if player touch killing spots
        {
            playerDie = true;
            Respawn();

        }

    }
    public void Respawn() // smarter Way to make delay
    {
        StartCoroutine("RespawnCoroutine"); // smarter to make delay
    }

    public IEnumerator RespawnCoroutine() // make delay class
    {
        gamePlayer.gameObject.SetActive(false); // Dissable the player temporary
        yield return new WaitForSeconds(respawnDelay); //that makes a delay in the game 
        gamePlayer.transform.position = gamePlayer.respawnPoint; // put the player on respawn position from Playercontroller class
        gamePlayer.gameObject.SetActive(true); // enable player after placing him back
        if (playerDie) // check if the player die and restart the whole level
        {
            mainButtonController.restartGame(); // restart whole level buttons
            playerDie = false;// if respawn not because player died.
            door.SetActive(true); //back the door
        }

    }
    public void Level1()// set up level 1 settings
    {
        scoreText.text = "I'ts Obvious...";

    }
    public void Level2()// set up level 2 settings
    {
        scoreText.text = "All Illusion";


    }

    public void FinishGame()
    {
        door.SetActive(false); //make the door disappear
    }
}



