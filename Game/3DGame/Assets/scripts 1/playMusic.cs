using UnityEngine;
using System.Collections;

public class playMusic : MonoBehaviour {

	private GameObject player;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag (tags.player);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
			if(Input.GetButton("Switch")){
				audio.Play();
				Debug.Log("sluts");
			}
		}
	}
}
