using UnityEngine;
using System.Collections;
using System;

// we want the pin Marker to have a nice light house appearance
// so it can have more than one interval with more than one color
//
// this model class consists of the different intervals and
// - latitude
// - longitude

[Serializable]
public class FlashIntervalArray {

	public FlashInterval[] flashes;

	public float latitude;
	public float longitude;

	public float Latitude {
		get { return  latitude; }
		set { latitude = value; }
	}

	public float Longitude {
		get { return  longitude; }
		set { longitude = value; }
	}

}
