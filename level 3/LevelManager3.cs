using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text option
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager3 : MonoBehaviour
{
    public float respawnDelay; // the amout of time the player can respawn
    public PlayerController gamePlayer;
    private MainButtonController3 mainButtonController;
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
        mainButtonController = FindObjectOfType<MainButtonController3>();
        playerDie = false;
        /////////////////////////////////// level text///////////////////////////
       scoreText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {

        if (player.IsTouchingLayers(badGuys))
        {
            playerDie = true;
            Respawn();

        }
    }
    public void Respawn()
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
            scoreText.text = " ";
        }

    }

    public void gamblingText() //when the player it the first button
    {
        scoreText.text = "Let's Gambling";
    }
    public void FinishGame()
    {
        door.SetActive(false); //make the door disappear
    }



}

