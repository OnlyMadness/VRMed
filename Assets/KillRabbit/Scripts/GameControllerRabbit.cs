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

    public GameObject TextTextScore;    // если сверхразум то можешь поменять эти гамеобджеки на один канвас
    public GameObject TextScore;        // мне было впадлу сорe 
    public GameObject InstructionText;  //
    public GameObject FinishText;       // поставлю баксы где это использовалось
    public GameObject FinishScoreText;  // upd: их все больше и больше, я уже сам задумываюсь все сделать по нормальному

    private Mole[] moles;   
    private float spawnTimer = 0f;
    private float defaultGameTime = 0f;
    private float hintTimer = 3f;
    private float gameplayCountdownTimer = 3f;
    public bool GamePlay;

    private void OnEnable()
    {
        FinishText.SetActive(false);                // $
        FinishScoreText.SetActive(false);           // $
        InstructionText.SetActive(true);            // $
        TextTextScore.SetActive(false);             // $
        TextScore.SetActive(false);                 // $
        TextScore.GetComponent<Text>().text = "0";  // $
        Score = 0;
    }

    // Use this for initialization
    void Start() {
       
            moles = moleContainer.GetComponentsInChildren<Mole>();
            defaultGameTime = gameTimer;
        
    }

    // Update is called once per frame
    void Update() {
        if (!gameStart) {
            return;
        }
        gameplayCountdownTimer -= Time.deltaTime;
        if (gameplayCountdownTimer <= 0f) {
        TextScore.GetComponent<Text>().text = Score.ToString();
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
                    for (int i = 0; i < moles.Length; i++)
                        moles[i].GetComponent<Mole>().Hide();
                    FinishText.SetActive(true);                                     // $   
                    FinishScoreText.GetComponent<Text>().text = Score.ToString();   // $
                    FinishScoreText.SetActive(true);                                // $
                    TextTextScore.SetActive(false);                                  // $
                    TextScore.SetActive(false);                                      // $
                    GamePlay = true;
                    gameStart = false;                
                }
            }
        }            
    }

    public void StartGame() {
        if (GamePlay)
        {
            Score = 0;
            TextScore.GetComponent<Text>().text = "0";
            FinishText.SetActive(false);        // $
            FinishScoreText.SetActive(false);   // $
            InstructionText.SetActive(false);   // $
            TextTextScore.SetActive(true);      // $
            TextScore.SetActive(true);          // $

            gameTimer = defaultGameTime;     
            gameplayCountdownTimer = 3f;
            gameStart = true;
            hintTimer = 3f;
            GamePlay = false;
        }
    }
    public void Menu()
    {
        //FinishText.SetActive(false);                // $
        //FinishScoreText.SetActive(false);           // $
        //InstructionText.SetActive(true);            // $
        //TextTextScore.SetActive(false);             // $
        //TextScore.SetActive(false);                 // $
        //TextScore.GetComponent<Text>().text = "0";  // $
        //Score = 0;

        Application.LoadLevel(1);
    }

}