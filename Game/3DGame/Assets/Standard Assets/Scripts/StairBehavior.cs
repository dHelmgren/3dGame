using UnityEngine;
using System.Collections;

public class StairBehavior : MonoBehaviour {

	public float cameraOffSet = 0.5583928f;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "MainCamera")
		{
			float moveVertical = Input.GetAxis ("Vertical");
			if ((moveVertical > 0.0f))
			{
				PlayerController.cameraYPos = PlayerController.cameraYPos + 1.67f;
			}
			else if ((moveVertical < 0.0f))
			{
				PlayerController.cameraYPos = PlayerController.cameraYPos - 1.67f;
			}
		}
	}
	
}
