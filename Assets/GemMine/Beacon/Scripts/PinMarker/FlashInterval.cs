using UnityEngine;
using System.Collections;
using System;

// this class represents the model class
// for a pin marker. It consists of
// - on interval (how long does the pin marker shine)
// - off interval (how long is the pin marker dark)
// - the pin marker's color

[Serializable]
public class FlashInterval {

	public float onInterval;
	public float offInterval;
	public Color flashColor;

	public float OnInterval {
		get { return  onInterval; }
		set { onInterval = value; }
	}

	public float OffInterval {
		get { return  offInterval; }
		set { offInterval = value; }
	}

	public Color FlashColor{
		get { return  flashColor; }
		set { flashColor = value; }
	}
		
}
