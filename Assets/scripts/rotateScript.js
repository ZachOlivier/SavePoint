#pragma strict

var rotationSpeed							: int = 0;

function Start () {

}

function Update () {
	this.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
}