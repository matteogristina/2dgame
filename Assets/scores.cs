using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
	}
	
	public void DelayRestart() {
		Invoke("Restart", cooldown);
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
		uiText = GetComponent<TextMeshProUGUI>();
		//string joined = string.Format(TEXT_BASE, MAINscore, MAIN2score);
		//uiText.text = joined;
        //uiText.text = "Some text";
    }

    // Update is called once per frame
    void Update()
    {
        string joined = string.Format(TEXT_BASE, MAINscore, MAIN2score);
		uiText.text = joined;
    }
}
