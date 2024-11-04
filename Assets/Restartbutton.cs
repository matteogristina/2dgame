using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restartbutton : MonoBehaviour
{
	
	public Scores scoreCounter;
	public ScorePreserve scorePres;
	
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		
		GameObject scoreGO = GameObject.Find("ScoresText");
		if (scoreGO != null) {
			scoreCounter = scoreGO.GetComponent<Scores>();
		}
		
		GameObject scorepresGO = GameObject.Find("ScorePreserve");
		if (scorepresGO != null) {
			scorePres = scorepresGO.GetComponent<ScorePreserve>();
		}
        
    }
	
	void TaskOnClick(){
		Debug.Log ("clicked");
		Debug.Log("restarting");
		scoreCounter.MAINscore = 0;
		scoreCounter.MAIN2score = 0;
		
		GameObject mm = GameObject.Find("MainMenu(Clone)");
		GameObject q = GameObject.Find("Quit(Clone)");
		
		Destroy(mm);
		Destroy(q);
		
		scorePres.gameOver = false;
		scorePres.restartpressed = true;
		SceneManager.LoadScene("flow");
		Destroy(gameObject);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
