using UnityEngine;

public class MouseClick : MonoBehaviour
{

	void OnMouseDown()
    {
        //string description = this.gameObject.GetComponent<MarkerScript()>.description;
        Debug.Log(this.gameObject.GetComponent<MarkerScript>().description);
        //Marker currentMarker = this.gameObject.typ;
        //currentMarker.GetComponent<MarkerScript>
        /*
         * String currentTweet = currentMarker.description;
         * Debug.Log(currentTweet);
         */
    }
}
