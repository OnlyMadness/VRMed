using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerRabbit : MonoBehaviour {
   
    public GameObject moleContainer;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnDuration = 0.5f;
    public float gameTimer = 15f;
    private bool gameStart = false;
    public bool IsGameStart {
        get { return gameStart; }
    }
    public static int Score;
    public GameObject TextScore;
    private Mole[] moles;   
    private float spawnTimer = 0f;
    private float defaultGameTime = 0f;
    private float hintTimer = 3f;
    private float gameplayCountdownTimer = 3f;

    // Use this for initialization
    void Start() {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        defaultGameTime = gameTimer;
       // StartGame();
    }

    // Update is called once per frame
    void Update() {
        if (!gameStart) {
            return;
        }
        TextScore.GetComponent<Text>().text = Score.ToString();
        gameplayCountdownTimer -= Time.deltaTime;
        if (gameplayCountdownTimer <= 0f) {
            gameTimer -= Time.deltaTime;
            if (gameTimer > 0f) {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0f) {
                    moles[Random.Range(0, moles.Length)].Rise();
                    spawnDuration -= spawnDecrement;
                    if (spawnDuration < minimumSpawnDuration) {
                        spawnDuration = minimumSpawnDuration;
                    }
                    spawnTimer = spawnDuration;
                }
            }
            else {              
                hintTimer -= Time.deltaTime;
                if (hintTimer <= 0f) {
                    gameStart = false;                
                }
            }
        }            
    }

    public void StartGame() {
        gameTimer = defaultGameTime;     
        gameplayCountdownTimer = 3f;
        gameStart = true;
        hintTimer = 3f;
    }
    public void Menu()
    {
        Application.LoadLevel(1);
    }
}