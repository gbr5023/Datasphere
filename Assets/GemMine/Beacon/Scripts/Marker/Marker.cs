using UnityEngine;
using System;

// this class represents the model class
// for a blip marker. It consists of
// - latitude
// - longitude
// - the marker's color

[Serializable]
public class Marker : MonoBehaviour
{
    public string description;
	public float latitude;
	public float longitude;
	public Color markerColor;
    
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    
	public float Latitude
    {
		get { return  latitude; }
		set { latitude = value; }
	}

	public float Longitude
    {
		get { return  longitude; }
		set { longitude = value; }
	}

	public Color MarkerColor
    {
		get { return markerColor;  }
		set { markerColor = value; }
	}
		
}
