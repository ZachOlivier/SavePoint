using UnityEngine;
using System.Collections;

public class rotateScript : MonoBehaviour {

	public int rotationSpeed	= 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// Rotate this object acccording to its up direction by the rotation speed multiplied by Time.deltaTime to make it happen smoothly per frame
		this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
}
