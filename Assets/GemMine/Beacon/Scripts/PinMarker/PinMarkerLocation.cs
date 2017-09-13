using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// this class takes the entries from the editor list
// and displays them on a sphere

public class PinMarkerLocation : MonoBehaviour {

	// the pin marker prefab
	public GameObject PinMarkerPrefab;
	// the marker's size
	public float pinMarkerSize;
	// the halo of the light
	public float lightSize;

	// the single markers
	public FlashIntervalArray[] pinMarkerPosition;

	// put them all in a list
	List<GameObject> pinMarkerList;

	Vector3 startSize;

	// Use this for initialization
	void Start () {
		// create a new list
		pinMarkerList = new List<GameObject> ();
		pinMarkerList.Clear ();

		// get each marker position
		foreach (FlashIntervalArray m in pinMarkerPosition) {
			// create a gameobject
			GameObject go = Instantiate (PinMarkerPrefab);
			// parent it to the sphere
			go.transform.SetParent (this.transform);
			// set the position
			go.transform.localPosition = Quaternion.AngleAxis(m.Longitude, -Vector3.up) * 
				Quaternion.AngleAxis(m.Latitude, -Vector3.right) * 
				new Vector3 (0f, 0, 0.5f);
			// set the rotation
			go.transform.localRotation = Quaternion.Euler (90f-m.Latitude, -m.Longitude, 0);
			// set the scale
			go.transform.localScale = go.transform.localScale * pinMarkerSize;
			// set the current flash pattern
			go.GetComponent<PinScript> ().flashes = m.flashes;
			// set the halo size
			go.GetComponent<PinScript> ().setLightSize (lightSize);
			// and add it to the list
			pinMarkerList.Add (go);
		}
		startSize = pinMarkerList [0].transform.localScale;
	}



	//
	// void update()
	//
	// Maybe the marker change their position over time
	// then change the position here
	//

	void Update () {
	
	}



	//
	// public void changeMarkerSize() 
	//
	// if the scene uses camera scale/zoom, 
	// it could be nice to scale the marker
	// so it does not get too big
	//

	public void changeMarkerSize() {
		foreach (GameObject markerGO in pinMarkerList) {
			// take the standard cameras standard fieldofview
			markerGO.transform.localScale = startSize * Camera.main.fieldOfView / 60f;
		}
	}
}
