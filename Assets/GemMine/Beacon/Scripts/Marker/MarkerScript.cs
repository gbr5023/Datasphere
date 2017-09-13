using UnityEngine;

// this script controls the circle blip shader

public class MarkerScript : MonoBehaviour
{
    // tweet description
    public string description;
	// a color for the blip
	public Color markerColor;
	// the nice blip sphere
	public GameObject Pin;
	// a plane with the circleshader attached to it
	public GameObject Circle;

	// max radius of the circle is 0.7 (1/2 sqrt 2)
	float maxRadius = 0.7f;
	// current radius
	float Radius = 0f;
	// circle fades out over time
	float Alpha = 1f;
	float timer;

	// Use this for initialization
	void Start ()
    {
		timer = 0;
		// start centered
		Radius = 0;
		Pin.GetComponent<Renderer> ().material.color = markerColor;
		// by default, Unity sets this value to 2000
		// but this interferes with skybox rendering
		// setting the renderqueue to 3000 remedies this issue
		Circle.GetComponent<Renderer> ().material.renderQueue = 3000;
		// set the desired color
		Circle.GetComponent<Renderer> ().material.SetColor("_Tint",markerColor);
		// set the start radius
		Circle.GetComponent<Renderer> ().material.SetFloat("_Radius",0f);
		// set the start alpha
		Circle.GetComponent<Renderer> ().material.SetFloat("_Alpha",1f);
	}
	
	// Update is called once per frame
	void Update ()
    {
		// increase timer
		timer += Time.deltaTime;

		// effect lasts one second, then restart
		if (timer > 1)
        {
			timer -= 1;
			Radius = 0f;
			Alpha = 1f;
		}

		// set the radius
		Radius = timer * 0.7f;
		// set the alpha value
		Alpha = 1f - timer;

		// put the values into the shader
		Circle.GetComponent<Renderer> ().material.SetFloat("_Radius",Radius);
		Circle.GetComponent<Renderer> ().material.SetFloat("_Alpha",Alpha);

	}
}
