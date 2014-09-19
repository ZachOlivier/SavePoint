using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class soundScript : MonoBehaviour {

	public AudioClip music1;
	public AudioClip music2;
	public AudioClip music3;
	public AudioClip music4;

	// Use this for initialization
	void Start () {
	
		audio.clip = music1;
		audio.loop = true;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
}
