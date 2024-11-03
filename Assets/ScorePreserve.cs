using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePreserve : MonoBehaviour
{
	
	public Scores scoreCounter;
	private static ScorePreserve instance;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoresText");
		scoreCounter = scoreGO.GetComponent<Scores>();
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

    // Update is called once per frame
    void Update()
    {
		if ((scoreCounter.MAINscore >= 5) || (scoreCounter.MAIN2score >= 5)) {
			Debug.Log("game should end");
		}
        
    }
}
