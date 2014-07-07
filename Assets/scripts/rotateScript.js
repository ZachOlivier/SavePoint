#pragma strict

// A variable to store the speed of rotation
var rotationSpeed							: int = 0;

function Start () {

}

function Update () {

	// Rotate this object acccording to its up direction by the rotation speed multiplied by Time.deltaTime to make it happen smoothly per frame
	this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
}