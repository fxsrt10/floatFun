using UnityEngine;
using System.Collections;
using Leap;
using Leap.Interact;

public class lockRotation : MonoBehaviour
{
		private LeapInteraction leapInteraction;
		private float rotateStart;
		private bool released = false;
		public Vector3 homePlane;
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
						homePlane.x = this.gameObject.transform.position.x;
						homePlane.y = this.gameObject.transform.position.y;

				}
				if (leapInteraction.isGrabbed == false && (this.GetComponent<Transform> ().rotation != Quaternion.identity || this.GetComponent<Transform> ().position != homePlane)) {
						this.GetComponent<Transform> ().rotation = Quaternion.Slerp (this.gameObject.transform.rotation, Quaternion.identity, (Time.time - rotateStart) / 1f);
						this.GetComponent<Transform> ().position = Vector3.Slerp (this.gameObject.transform.position, homePlane, (Time.time - rotateStart) / 3f);
						if (homePlane.x - this.gameObject.transform.position.x < 1)
								this.gameObject.transform.position = new Vector3 (homePlane.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
						if (homePlane.y - this.gameObject.transform.position.y < 1)
								this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, homePlane.y, this.gameObject.transform.position.z);
				}
				released = leapInteraction.isGrabbed;
		}
}
