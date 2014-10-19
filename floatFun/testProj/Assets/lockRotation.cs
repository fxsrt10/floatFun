using UnityEngine;
using System.Collections;
using Leap;
using Leap.Interact;

public class lockRotation : MonoBehaviour
{
		private LeapInteraction leapInteraction;
		private float rotateStart;
		private bool released = false;
		// Use this for initialization
		void Start ()
		{
				leapInteraction = this.GetComponent<LeapInteraction> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (released != leapInteraction.isGrabbed) {
						rotateStart = Time.time;
				}
				if (leapInteraction.isGrabbed == false && this.GetComponent<Transform> ().rotation != Quaternion.identity)
						this.GetComponent<Transform> ().rotation = Quaternion.Slerp (this.gameObject.transform.rotation, Quaternion.identity, (Time.time - rotateStart) / 5f);
				released = leapInteraction.isGrabbed;
		}
}
