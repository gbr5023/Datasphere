using UnityEngine;

// read in the csv file
//http://www.theappguruz.com/blog/unity-csv-parsing-unity

public class DataImport : MonoBehaviour
{
    public TextAsset tweetsFile;
    public TextAsset coordinatesFile;
    string[] tweetsTemp = new string[1400];
    float[] latitudesTemp = new float[1400];
    float[] longitudesTemp = new float[1400];
    string[] coordinatesTemp = new string[1400];

    char newLine = '\n';
    char comma = ',';

    Marker[] markerPosition = new Marker[1400];

    // Use this for initialization
    // call methods in order, returns respective objects
    public Marker[] begin(TextAsset tempTweetsFile, TextAsset tempCoordinatesFile)
    {
        this.tweetsFile = tempTweetsFile;
        this.coordinatesFile = tempCoordinatesFile;

        tweetsTemp = ImportTweets(tweetsFile);
        latitudesTemp = ImportLatitude(tempCoordinatesFile);
        longitudesTemp = ImportLongitude(tempCoordinatesFile);
        //coordinatesTemp = ImportCoordinates(coordinatesFile);
        markerPosition = CreateMarkerPositions(tweetsTemp, latitudesTemp, longitudesTemp);

        return markerPosition;
    }

    // returns string array of tweets
    string[] ImportTweets(TextAsset tweetsFile)
    {
        string[] importedTweets = new string[1400];

        importedTweets = tweetsFile.text.Split(newLine);

        for (int j = 0; j < importedTweets.Length; j++)
        {
            string[] TempStringDetail = importedTweets[j].Split(comma);

            string tempStringTweet = "";
        }

        return importedTweets;
    }

    float[] ImportLatitude(TextAsset coordinatesFile)
    {
        //string[] tempLatitude = new string[1400];
        float[] importedLatitude = new float[1400];

        coordinatesTemp = coordinatesFile.text.Split(newLine);

        for (int j = 0; j < coordinatesTemp.Length; j++)
        {
            string[] TempStringDetail = coordinatesTemp[j].Split(comma);

            float tempStringLatitude = 0;

            for (int i = 0; i < TempStringDetail.Length; i++)
            {
                if (i == 0)
                {
                    tempStringLatitude = float.Parse(TempStringDetail[i]);
                }
            }
            importedLatitude[j] = tempStringLatitude;
        }

        return importedLatitude;
    }

    float[] ImportLongitude(TextAsset coordinatesFile)
    {
        //string[] tempLongitude = new string[1400];
        float[] importedLongitude = new float[1400];

        coordinatesTemp = coordinatesFile.text.Split(newLine);

        for (int j = 0; j < coordinatesTemp.Length; j++)
        {
            string[] TempStringDetail = coordinatesTemp[j].Split(comma);

            float tempStringLongitude = 0;

            for (int i = 0; i < TempStringDetail.Length; i++)
            {
                if (i == 1)
                {
                    tempStringLongitude = float.Parse(TempStringDetail[i]);
                }
            }
            importedLongitude[j] = tempStringLongitude;
        }

        return importedLongitude;
    }
    /*
    // returns string array of coordinates
    string[] ImportCoordinates(TextAsset coordinatesFile)
    {
        string[] importedCoordinates = new string[1400];

        coordinatesTemp = coordinatesFile.text.Split(newLine);

        for (int j = 0; j < coordinatesTemp.Length; j++)
        {
            string[] TempStringDetail = coordinatesTemp[j].Split(comma);

            float tempStringLatitude = 0;
            float tempStringLongitude = 0;

            for (int i = 0; i < TempStringDetail.Length; i++)
            {
                if (i == 0)
                {
                    tempStringLatitude = float.Parse(TempStringDetail[i]);
                }
                else
                {
                    tempStringLongitude = float.Parse(TempStringDetail[i]);
                }
            }
        }

        return importedCoordinates;
    }
    */

    Marker[] CreateMarkerPositions(string[] tweetsTemp, float[] latitudesTemp, float[] longitudesTemp)
    {
        for(int i = 0; i < markerPosition.Length; i++)
        {
            markerPosition[i] = new Marker
            {
                description = tweetsTemp[i],
                latitude = latitudesTemp[i],
                longitude = longitudesTemp[i],
                markerColor = Color.cyan
            };
        }

        return markerPosition;
    }
}
