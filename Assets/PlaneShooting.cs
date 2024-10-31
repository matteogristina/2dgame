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
			var bullet = Instantiate(bulletPrefab);
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			canShoot = false;
			Invoke("ResetCooldown", 0.3f);
		}

    }
	
}
