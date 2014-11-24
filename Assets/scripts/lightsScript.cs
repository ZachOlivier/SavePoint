using UnityEngine;
using System.Collections;

public class lightsScript : MonoBehaviour {

	public float distance;

	public Transform player;

	// Use this for initialization
	void Start () {
	
		this.gameObject.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Vector3.Distance(transform.position, player.position) <= distance)
		{
			this.gameObject.light.enabled = true;
		}

		else 
		{
			this.gameObject.light.enabled = false;
		}
	}
}