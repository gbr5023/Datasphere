using UnityEngine;
using System.Collections;

public class PinScript : MonoBehaviour {
	
	public Light light;
	public Material lighton;
	public Material lightoff;

	Renderer sphereRend;

	public FlashInterval[] flashes;

	int actualFlash;

	public void setLightSize(float lightSize) {
		light.range = lightSize;
	}

	// Use this for initialization
	void Start () {
		actualFlash = 0;
		sphereRend = transform.Find("Sphere").GetComponent<Renderer> ();
		StartCoroutine("flash");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator flash() {
		while (true) {
			light.enabled = true;
			sphereRend.material.color= flashes [actualFlash].FlashColor;
			light.color = flashes [actualFlash].FlashColor;
			yield return new WaitForSeconds(flashes[actualFlash].OnInterval);

			light.enabled = false;
			sphereRend.material = lightoff;
			yield return new WaitForSeconds(flashes[actualFlash].OffInterval);

			actualFlash = (actualFlash + 1) % flashes.Length;
		}
	}
}
