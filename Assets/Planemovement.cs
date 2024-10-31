using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planemovement : MonoBehaviour
{
	public float speed = 10f;
	
    // Start is called before the first frame update
    void Start()
    {
		

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
		
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
		
		
		
		//more space in update method
		
    }
	
}
