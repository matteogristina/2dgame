using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// this script sets the text with multiple colors in the same text object, avoid needing to split into multiple game objects


public class Scores : MonoBehaviour
{
	[Header("Dynamic")]
	public int MAINscore = 0;
	public int MAIN2score = 0;
    public TextMeshProUGUI uiText;
	const string TEXT_BASE = "<color=#363636ff>{0}</color> - <color=#b8b8b8ff>{1}</color>";
	
	float cooldown = 1.5f;
	
	void Restart() {
		Debug.Log("restarting");
		SceneManager.LoadScene("flow");
		//Destroy(gameObject);
	}
	
	public void DelayRestart() {
		if ((MAINscore < 5) && (MAIN2score < 5)) {
			Invoke("Restart", cooldown);
		}
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
		uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
		// join the text with the correct color formatting
        string joined = string.Format(TEXT_BASE, MAINscore, MAIN2score);
		uiText.text = joined;
    }
}
