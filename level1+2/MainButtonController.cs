using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonController : MonoBehaviour
{
    public Sprite offButton; // sprite of off button
    public Sprite onButton; // sprite of on button
    public bool playerDie; // if player died
    public PlayerController gamePlayer; // the player
    private LevelManager gameLevelManager; // GameLevelMangaer
    public Button buttonMain; //Main Button
    
    // Start is called before the first frame update
    void Start()
    {

        gamePlayer = FindObjectOfType<PlayerController>(); //get the information of the player
        gameLevelManager = FindObjectOfType<LevelManager>(); //get the information of the levelManager

    }

    // Update is called once per frame
    void Update()
    {
        if(buttonMain.IfTriggerd())//if playerReached The Button
        { 
           ButtonReached(); //ACtive buttonReached
        }
    }
    public void ButtonReached() // if playerReached The Button
    {
        buttonMain.visualSprite.sprite = onButton;
        gameLevelManager.FinishGame(); // open the door and do finish game commands in game manager
    }
    public void restartGame() // if the player die and restart the level
    {
        buttonMain.visualSprite.sprite = offButton;// Restart Spirte of Mainbutton
        buttonMain.triggerd = false; // Restart triggerd of Mainbutton
        gameLevelManager.playerDie = false; // change player die status
    }
}
