/*
    
Author : Andres Mrad
Date : Tuesday 02/March/2021 @ 08:23:21 
Description : Defines the behavior for the main character
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : GameActorController
{

    #region Private Properties



    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    new void Update()
    {

        //3. Movernos
        base.Update();

        // Implimenet Character movement
        //1. obtener el input en X 
        _vx = Input.GetAxisRaw("Horizontal");

        //2. obtener el input en y
        // Si presione la tecla de saltar
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isJumping = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            // only do this if the jump force is still making the player gain speed
            // if (_isJumping && _vy > 0)
            if (_vy > 0)
                _vy = 0;
            _isJumping = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        // if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            GameManager.Instance.UpdateLives(-1);
        }
    }

    


}