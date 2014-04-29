#pragma strict

var rotationSpeed					: int = 200;

function Start () {

}

function Update () {
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