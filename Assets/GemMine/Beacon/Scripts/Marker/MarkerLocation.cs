using UnityEngine;
using System.Collections.Generic;

// this class takes the entries from the editor list
// and displays them on a sphere

public class MarkerLocation : MonoBehaviour
{
    public TextAsset tweetsCSV;
    public TextAsset coordinatesCSV;

    string[] Temp = new string[1400];

    char newLine = '\n';
    char comma = ',';

    // the blip marker prefab
    public GameObject MarkerPrefab;
	// the display size
	float markerSize = 5;
	// altitude above zero is 20 b/c globe was scaled larger
	float altitude = 20;
    // the single markers
    Marker[] markerPosition = new Marker[1400];

    Vector3 startSize;

    // put them all in a list
    List<GameObject> markerList;

    // Use this for initialization
    void Start()
    {
        DataImport theDataImport = new DataImport();
        markerPosition = theDataImport.begin(tweetsCSV, coordinatesCSV);
        /*
        Temp = csvFile.text.Split(newLine);

        for (int j = 0; j < Temp.Length; j++)
        {
            string[] TempStringDetail = Temp[j].Split(comma);

            string tempStringTweet = "";
            float tempStringLatitude = 0;
            float tempStringLongitude = 0;

            for (int i = 0; i < TempStringDetail.Length; i++)
            {
                if (i == 0)
                {
                    tempStringLatitude = float.Parse(TempStringDetail[i]);
                }
                /*else if(i == 2)
                {
                    tempStringTweet = TempStringDetail[i];
                }
                
                else
                {       
                    tempStringLongitude = float.Parse(TempStringDetail[i]);
                }
                
            }

            markerPosition[j] = new Marker
            {
                description = tempStringTweet,
                latitude = tempStringLatitude,
                longitude = tempStringLongitude,
                markerColor = Color.cyan
            };
        }
        */

        // create a new list
        markerList = new List<GameObject>();
        markerList.Clear();

        // get each marker position
        foreach (Marker m in markerPosition)
        {
            // create a gameobject
            GameObject go = Instantiate(MarkerPrefab);
            // parent it to the sphere
            go.transform.SetParent(this.transform);
            // set the scale
            go.transform.localScale = go.transform.localScale * markerSize;
            // set the position
            go.transform.localPosition = Quaternion.AngleAxis(m.Longitude, -Vector3.up) *
                Quaternion.AngleAxis(m.Latitude, -Vector3.right) *
                new Vector3(0, 0, altitude);
            // set the color
            go.GetComponent<MarkerScript>().markerColor = m.MarkerColor;
            // rotate it according to the position
            go.transform.localRotation = Quaternion.Euler(90f - m.Latitude, -m.Longitude, 0);
            // put the element in the list
            markerList.Add(go);
        }
        startSize = markerList[0].transform.localScale;

        /*
        // create new tweet list
        tweetList = new List<GameObject>();
        tweetList.Clear();

        this.initiateTweetTransfer = new DataImport();
        this.tweetPosition = initiateTweetTransfer.sendTwitterMarkers();

        // get each marker position
        foreach (Marker m in tweetPosition)
        {
            // create a gameobject
            GameObject go = Instantiate(MarkerPrefab);
            // parent it to the sphere
            go.transform.SetParent(this.transform);
            // set the scale
            go.transform.localScale = go.transform.localScale * markerSize;
            // set the position
            go.transform.localPosition = Quaternion.AngleAxis(m.Longitude, -Vector3.up) *
                Quaternion.AngleAxis(m.Latitude, -Vector3.right) *
                new Vector3(0, 0, altitude);
            // set the color
            go.GetComponent<MarkerScript>().markerColor = m.MarkerColor;
            // rotate it according to the position
            go.transform.localRotation = Quaternion.Euler(90f - m.Latitude, -m.Longitude, 0);
            // put the element in the list
            tweetList.Add(go);
        }
        startSize = tweetList[0].transform.localScale;
        */
    }

    //
    // void update()
    //
    // Maybe the marker change their position over time
    // then change the position here
    //

    void Update ()
    {
		
	}

    //
    // public void changeMarkerSize() 
    //
    // if the scene uses camera scale/zoom, 
    // it could be nice to scale the marker
    // so it does not get too big
    //

    public void changeMarkerSize()
    {
		foreach (GameObject markerGO in markerList)
        {
			// take the standard cameras standard fieldofview
			markerGO.transform.localScale = startSize * Camera.main.fieldOfView / 60f;
		}
	}
}
