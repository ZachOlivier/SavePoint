using UnityEngine;
using System.Collections;

public class cullingScript : MonoBehaviour {

	public float distance;

	public Transform player;

	// Use this for initialization
	void Start () {

		this.gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance(transform.position, player.position) <= distance)
		{
			this.gameObject.renderer.enabled = true;
		}

		else 
		{
			this.gameObject.renderer.enabled = false;
		}
	}
}