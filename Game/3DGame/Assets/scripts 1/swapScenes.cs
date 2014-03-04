using UnityEngine;
using System.Collections;

public class swapScenes : MonoBehaviour {

	private GameObject player;
	public Camera camera;
	public Light light1;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (tags.player);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
						if (Input.GetButton ("Switch")) {
				        light1.intensity = 0;
				        camera.cullingMask = 0;
				        Application.LoadLevel("scary");
						}
				}
	}
}
