using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planemovement : MonoBehaviour
{
	public float speed = 10f;
	float cooldown = 0.7f;
	public bool isMain;
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
		if (isMain) {
			if (Input.GetKey("w")) {
				pos.y += speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90f), speed*Time.deltaTime );
			}
			if (Input.GetKey("s")) {
				pos.y -= speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f), speed*Time.deltaTime );
			}
			if (Input.GetKey("d")) {
				pos.x += speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f), speed*Time.deltaTime );
			}
			if (Input.GetKey("a")) {
				pos.x -= speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f), speed*Time.deltaTime );
			}
			
			transform.position = pos;
			
			if (Input.GetKey(KeyCode.LeftShift) && canShoot) {	
				var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler (0f, 0f, 90f));
				canShoot = false;
				Invoke("ResetCooldown", cooldown);
			}
			
			
			
		} else {
			if (Input.GetKey("i")) {
				pos.y += speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90f), speed*Time.deltaTime );
			}
			if (Input.GetKey("k")) {
				pos.y -= speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f), speed*Time.deltaTime );
			}
			if (Input.GetKey("l")) {
				pos.x += speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f), speed*Time.deltaTime );
			}
			if (Input.GetKey("j")) {
				pos.x -= speed * Time.deltaTime;
				//transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270f);
				transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f), speed*Time.deltaTime );
			}
			
			transform.position = pos;
			
			
			
			if (Input.GetKey(KeyCode.RightShift) && canShoot) {	
				var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler (0f, 0f, 90f));
				canShoot = false;
				Invoke("ResetCooldown", cooldown);
			}
			
		}
		
		
		//more space in update method
		
    }
	
}
