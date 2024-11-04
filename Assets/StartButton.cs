using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
	
	void TaskOnClick(){
		SceneManager.LoadScene("flow");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
