using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController3 : MonoBehaviour
{
    public Sprite offButton;
    public Sprite onButton;
    private SpriteRenderer buttonRenderer; //we can use it the get the sprite renderer from the object
    public bool playerDie;
    public PlayerController gamePlayer; // the player
    private LevelManager3 gameLevelManager;
    public bool first; // check if the button is first one
    public GameObject buttonFake1;
    public GameObject buttonFake2;
    public GameObject buttonFake3;
    public Button buttonReal;
    public Button buttonMain;
    public int checkPointCounter;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>(); //get the information of the player
        gameLevelManager = FindObjectOfType<LevelManager3>(); //get the information of the levelManager
        checkPointCounter = 0; //time player collect a checkpoint of buttons
     //   buttonReal.
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonReached() // if playerReached The Button
    {
 
        if(checkPointCounter == 0)//first time player collect the mainButton
        {
            buttonMain.gameObject.SetActive(false);//Inactive ButtonMain
            buttonFake1.SetActive(true);//Active buttonFake1
            buttonFake2.SetActive(true);//Active buttonFake2
            buttonFake3.SetActive(true);//Active buttonFake3
            buttonReal.gameObject.SetActive(true);//Active ButtonMain
        }
        if (checkPointCounter == 1)//player collect the ButtonReal
        {
            buttonReal.visualSprite.sprite = onButton;//make the buttonReal On Sprite
            gameLevelManager.FinishGame(); // open the door and do finish game commands in game manager
        }
        checkPointCounter++; // Increase counter the checkpoints 

      
    }
    public void restartGame() // if the player die and restart the level
    {
        Debug.Log("check1");
        buttonMain.gameObject.SetActive(true);
        Debug.Log("check2");
        buttonFake1.SetActive(false);//InActive buttonFake1
        buttonFake2.SetActive(false);//InActive buttonFake2
        buttonFake3.SetActive(false);//InActive buttonFake3
        buttonReal.gameObject.SetActive(false);//Active ButtonMain
        buttonReal.visualSprite.sprite = offButton;//make the buttonReal On Sprite
        checkPointCounter = 0; // Restart the counter
        gameLevelManager.playerDie = false; // change player die status
    }
}
