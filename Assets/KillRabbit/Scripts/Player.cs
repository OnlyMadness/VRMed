﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera mainCamera;
    public Hammer hammer;
    public int score = 0;

    private GameControllerRabbit gameController;

    // Use this for initialization
    void Start() {
        gameController = FindObjectOfType<GameControllerRabbit>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, mainCamera.transform.forward, out raycastHit)) {
                Debug.Log("ray hit something: " + raycastHit.transform.name);
                bool gameStart = gameController.IsGameStart;
                if (raycastHit.transform.GetComponent<Mole>() != null && gameStart) {
                    Mole mole = raycastHit.transform.GetComponent<Mole>();
                    //bool isMoleAttackable = mole.OnHit();
                    //if (isMoleAttackable)
                    //{
                    //    score++;

                    //}
                }

                if (raycastHit.transform.name.Equals("machine") && !gameStart) {
                    gameController.StartGame();
                }
            }
        }
    }
}