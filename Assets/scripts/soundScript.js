#pragma strict

var music1												: AudioClip;
var music2												: AudioClip;
var music3												: AudioClip;
var music4												: AudioClip;

function Start () {
	audio.clip = music4;
	audio.loop = true;
	audio.Play();
}

function Update () {
	if (!audio.isPlaying) {
		audio.Play();
	}
}

@script RequireComponent(AudioSource)