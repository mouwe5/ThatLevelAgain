using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public bool triggerd; // if player touched the button
    public Collider2D buttonCollider;
    public MainButtonController mainButtonController; // mainButtonController
    public SpriteRenderer visualSprite;//we can use it the get the sprite renderer from the object
    // Start is called before the first frame update
    void Start()
    {
        visualSprite = GetComponent<SpriteRenderer>(); // get the information form the project
        triggerd = false;// reset the trigger
        buttonCollider = GetComponent<Collider2D>(); // get information from the project
    }
    // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D other) // if you mark "trigger" in colider, it make that void works - Trigger when something (other) collide with that object
        {

            if (other.tag == "Player") // if Player Collide witg that Button
            {
                triggerd = true;

            }
        }

    
    public bool IfTriggerd()
    {
        return triggerd;
    }
}
