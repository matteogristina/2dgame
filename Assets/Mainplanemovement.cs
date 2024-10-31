using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainplanemovement : MonoBehaviour
{
	
	Renderer m_ObjectRenderer;
	Renderer[] renderers;
	bool isWrappingX = false;
	bool isWrappingY = false;
	Transform[] ghosts = new Transform[8];
	Vector3 initialposition;
	Quaternion rotation;
	Vector3 screenBottomLeft;
	Vector3 screenTopRight;
	float screenWidth;
	float screenHeight;
	public GameObject ghostPrefab; 

	
	
    // Start is called before the first frame update
    void Start() {
		
		transform.localRotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(0f, 360f)), 0.5f );
		
		
		renderers = GetComponentsInChildren<Renderer>();
		var cam = Camera.main;
		screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
		screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
		screenWidth = screenTopRight.x - screenBottomLeft.x;
		screenHeight = screenTopRight.y - screenBottomLeft.y;
		
		initialposition = GameObject.Find("MAIN").transform.position;
		rotation = GameObject.Find("MAIN").transform.rotation;
		
		CreateGhostShips();

	}
		
		
	void CreateGhostShips() {

		for (int i = 0; i < 8; i++) {
			ghosts[i] = Instantiate(ghostPrefab).transform;
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
		ghosts[0].position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[1].position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[2].position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[3].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[4].position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[5].position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[6].position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[7].position = ghostPosition;

		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++) {
			ghosts[i].rotation = transform.rotation;
		}

	}


	bool CheckRenderers() {
		foreach(var renderer in renderers) {
			// If at least one render is visible, return true
			if(renderer.isVisible) {
				return true;
			}
		}
		// Otherwise, the object is invisible
		return false;
	}
	
	void ScreenWrap() {

		var isVisible = CheckRenderers();
		if(isVisible) {
			isWrappingX = false;
			isWrappingY = false;
			return;
		}

		if(isWrappingX && isWrappingY) {
			return;
		}

		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;
		if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0)) {
			newPosition.x = -newPosition.x;
			isWrappingX = true;
		}

		if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0)) {
			newPosition.y = -newPosition.y;
			isWrappingY = true;
		}

		transform.position = newPosition;

	}
	
	void SwapShips() {

		foreach(var ghost in ghosts) {
			if (ghost.position.x < screenWidth && ghost.position.x > -screenWidth && ghost.position.y < screenHeight && ghost.position.y > -screenHeight) {
				transform.position = ghost.position;
				break;
			}
		}

		PositionGhostShips();
	}

	


    // Update is called once per frame
    void Update()
    {
        //ScreenWrap();
    }
}
