using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainplanemovement : MonoBehaviour
{
	
	GameObject[] ghosts = new GameObject[8];
	Vector3 initialposition;
	Quaternion rotation;
	Vector3 screenBottomLeft;
	Vector3 screenTopRight;
	float screenWidth;
	float screenHeight;
	public GameObject ghostPrefab; 
	public GameObject enemyBullet; 
	Renderer someObject;
	
	
	public GameObject exp1;
	public GameObject exp2;
	public GameObject exp3;

	
	
    // Start is called before the first frame update
    void Start() {
		
		someObject = GetComponent<Renderer>();
		
		transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(0f, 360f)), 0.5f );
		
		var cam = Camera.main;
		screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		screenHeight = screenTopRight.y - screenBottomLeft.y;
		
		initialposition = gameObject.transform.position;
		rotation = gameObject.transform.rotation;
		
		CreateGhostShips();

	}
		
		
	void CreateGhostShips() {

		for (int i = 0; i < 8; i++) {
			ghosts[i] = Instantiate(ghostPrefab);
		}
		
		PositionGhostShips();

	}
	
	void PositionGhostShips() {

		// All ghost positions will be relative to the ships (this) transform,
		var ghostPosition = transform.position;

		// We're positioning the ghosts clockwise behind the edges of the screen.
		// Let's start with the far right.

		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[0].transform.position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[1].transform.position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[2].transform.position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[3].transform.position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[4].transform.position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[5].transform.position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[6].transform.position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[7].transform.position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++) {
			ghosts[i].transform.rotation = transform.rotation;
		}

	}
	
	
	bool isOnScreen(GameObject obj) {
		
		Frustum f = Camera.main.GetFrustum();
		if (f.TestBounds(someObject.bounds) == EFrustumIntersection.Inside) {
			return true;
		} else {
			return false;
		}

	}
	
	bool isMainOnScreen() {
		Frustum f = Camera.main.GetFrustum();
		if (f.TestBounds(someObject.bounds) == EFrustumIntersection.Inside) {
			return true;
		} else {
			return false;
			
		}
	}
	
	void SwapShips() {

		foreach(var ghost in ghosts) {
			
			someObject = ghost.GetComponent<Renderer>();

			if (isOnScreen(ghost)) {
				transform.position = ghost.transform.position;
				PositionGhostShips();
				someObject = GetComponent<Renderer>();
				Debug.Log("swapped");
				break;
			}

		}

	}
	

    // Update is called once per frame
    void Update() {
        if (!isMainOnScreen()) {
			SwapShips();
		}
    }
}
