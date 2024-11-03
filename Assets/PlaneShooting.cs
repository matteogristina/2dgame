using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
	public GameObject bulletPrefab; 
	bool canShoot = true;
	
	void ResetCooldown() {
		canShoot = true;
	}
	
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
		
		if (Input.GetKey(KeyCode.LeftControl) && canShoot) {	
			var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler (180f, 0f, 0f));
			Debug.Log("rotation: " + transform.rotation * Quaternion.Euler (180f, 0f, 0f));
			//bullet.transform.position = transform.position;
			//bullet.transform.rotation = transform.rotation * Quaternion.Euler(90, 0, 0);
			canShoot = false;
			Invoke("ResetCooldown", 0.3f);
		}

    }
	
}
