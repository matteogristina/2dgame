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
        DontDestroyOnLoad(this);
		
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
    }
	
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
		
		GameObject rstbtn = GameObject.Find("Restart Game");
		
		
		if (!gameOver) {
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
