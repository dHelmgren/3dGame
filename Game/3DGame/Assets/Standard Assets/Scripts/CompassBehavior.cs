using UnityEngine;
using System.Collections;

public class CompassBehavior : MonoBehaviour {

	public GUITexture compass;
	public Texture compassW;
	public Texture compassE;
	public Texture compassN;
	public Texture compassS;

	// Use this for initialization
	void Start () {
		compass.guiTexture.texture = compassN;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (moveHorizontal > 0) 
		{
			compass.guiTexture.texture = compassW;
		} 
		else if (moveHorizontal < 0) 
		{
			compass.guiTexture.texture = compassE;
		}
		else if (moveVertical > 0) 
		{
			compass.guiTexture.texture = compassN;
		} 
		else if (moveVertical < 0) 
		{
			compass.guiTexture.texture = compassS;
		}


	}

}
