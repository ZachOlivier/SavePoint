using UnityEngine;
using System.Collections;

public class coreSpin : MonoBehaviour {

	public int rotationSpeed	= 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.gameObject.name == "InnerCore")
		{
			this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
		}
		
		else if (this.gameObject.name == "OuterCore")
		{
			this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
		}
		
		else if (this.gameObject.name == "OuterCore2")
		{
			this.transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
		}
	}
}
