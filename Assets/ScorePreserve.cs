using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePreserve : MonoBehaviour
{
	
	public Scores scoreCounter;
	private static ScorePreserve instance;
	GameObject scoreGO;
	public GameObject restartButton;
	public GameObject quitButton;
	public GameObject mmButton;
	public GameObject scoresText;
	public bool gameOver;
	public bool restartpressed;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		// assign main camera as the canvas
		GameObject camera = GameObject.Find("Main Camera");
		Canvas canvas = this.GetComponent<Canvas>();
		canvas.worldCamera = camera.GetComponent<Camera>(); 
		
		
		gameOver = false;
		restartpressed = false;
        scoreGO = GameObject.Find("ScoresText");
		if (scoreGO != null) {
			scoreCounter = scoreGO.GetComponent<Scores>();
		} else {
			Instantiate(scoresText, this.transform);
		}
    }
	
	void Awake()
    {
        DontDestroyOnLoad(this);		// we want the scores to preserve instead of resetting to 0 - 0 every time
		
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
    }
	
	// method that creates restart, main menu, and quit buttons when a bullet hits a plane
	void CreateRestart() {
		if(!GameObject.Find ("Restart Game")) {
			Debug.Log("in create restart");
			Instantiate(restartButton, this.transform);
			Instantiate(mmButton, this.transform);
			Instantiate(quitButton, this.transform);
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (!gameOver) {
			// if the score is equal to or over 5, start the sequence to end the game
			// create buttons that can navigate to the main menu, restart game, quit
			if ((scoreCounter.MAINscore >= 5) || (scoreCounter.MAIN2score >= 5)) {
				Debug.Log("game should end");
				gameOver = true;
				CreateRestart();
				//Destroy(scoreGO);
			}
		}
		
		if (restartpressed) {
			restartpressed = false;
			
		}
    }
}
