using UnityEngine;
using System.Collections;
using Leap;
using Leap.Interact;

public class playMusic : MonoBehaviour {

	private LeapInteraction leapInteraction;
	public AudioClip ironMan;
	private bool isPlaying = false;
	// Use this for initialization
	void Start () {
		leapInteraction = this.GetComponent<LeapInteraction> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (leapInteraction.isGrabbed && !isPlaying) {

			AudioSource.PlayClipAtPoint(ironMan, this.GetComponent<Transform>().position);
			isPlaying = true;
		}
	}
}
