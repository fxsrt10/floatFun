using UnityEngine;
using System.Collections;
using Leap;
using Leap.Interact;

public class lockRotation : MonoBehaviour {

	private Controller controller;
	private LeapInteraction leapInteraction;
	// Use this for initialization
	void Start () {
		leapInteraction = this.GetComponent<LeapInteraction> ();
		controller = new Controller();
		controller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
		controller.Config.SetFloat("Gesture.ScreenTap.MinForwardVelocity", 30.0f);
		controller.Config.SetFloat("Gesture.ScreenTap.HistorySeconds", .5f);
		controller.Config.SetFloat("Gesture.ScreenTap.MinDistance", 1.0f);
		controller.Config.Save();
	}
	
	// Update is called once per frame
	void Update () {
		//Frame frame = controller.Frame(); // controller is a Controller object
		//GestureList gesturesInFrame = frame.Gestures();
		//Gesture gestureOfInterest = gesturesInFrame [0];
		//Debug.Log (gestureOfInterest.ToString());
		//if (gestureOfInterest != null)
			//this.GetComponent<Transform>().rotation = Quaternion.identity;
		/*HandList hands = frame.Hands;
		Hand firstHand = hands[0];
		if(firstHand.GrabStrength == 0.0f)*/
		if(!leapInteraction.isGrabbed)
			this.GetComponent<Transform>().rotation = Quaternion.identity;
	}
}
