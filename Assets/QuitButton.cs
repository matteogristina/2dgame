using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
	
	void TaskOnClick(){
		doExitGame();
	}
	
	void doExitGame() {
		Application.Quit();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
