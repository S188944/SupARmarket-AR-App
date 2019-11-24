using UnityEngine;
using Vuforia;
using System.Data.SQLite;

public class DBConnector : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour imageTracker;

    void Start()
    {
        //Create image tracker
        imageTracker = GetComponent<TrackableBehaviour>();
        if (imageTracker)
        {
            imageTracker.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED)
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=" + Application.dataPath + "/SQLite/Database.db;Version=3;"); //Locate SQLite Database

            connection.Open(); //Open connection to SQLite database

            Debug.Log("Database connection successful!");

            SQLiteCommand cmnd_read = connection.CreateCommand(); //Create command to read data
            SQLiteDataReader reader; //Create data reader

            //Query the database
            string query = "SELECT username, product_name FROM User NATURAL JOIN UserProduct NATURAL JOIN Product;";

            //Read database command
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            //Write results of query to debug console
            while (reader.Read())
            {
                Debug.Log(reader[0].ToString() + " has located " + reader[1].ToString() + ".");
            }

            connection.Close(); //Close connection to SQLite database
        }
        else
        {
        }
    }
}
