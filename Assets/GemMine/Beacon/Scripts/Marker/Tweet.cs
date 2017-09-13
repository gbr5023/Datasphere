using System.Collections;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
using UnityEngine;
using System;

[Serializable]
public class Tweet: MonoBehaviour
{
    public string tweetString;
    public float tweetLatitude;
    public float tweetLongitude;
    public Color tweetColor;

    public string TweetString
    {
        get { return this.tweetString; }
        set { this.tweetString = value; }
    }

    public float TweetLatitude
    {
        get { return this.tweetLatitude; }
        set { this.tweetLatitude = value; }
    }

    public float TweetLongitude
    {
        get { return this.tweetLongitude; }
        set { this.tweetLongitude = value; }
    }

    public Color TweetColor
    {
        get { return this.tweetColor; }
        set { this.tweetColor = Color.black; }
    }
}
