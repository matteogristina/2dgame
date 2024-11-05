using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacktoMM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
	
	
	// coding the main menu button in restart menu
	void TaskOnClick(){
		SceneManager.LoadScene("mainmenu");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
