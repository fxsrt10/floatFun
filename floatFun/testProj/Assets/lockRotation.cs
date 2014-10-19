using UnityEngine;
using System.Collections;

public class lockRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Transform>().rotation = Quaternion.identity;
	}
}
