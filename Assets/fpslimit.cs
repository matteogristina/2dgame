using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// limits the fps of the game for consistent frame times
public class fpslimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 144;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
