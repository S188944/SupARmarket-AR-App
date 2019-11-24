using UnityEngine;
using System.Data.SQLite;

public class DBConnector : MonoBehaviour
{
    void Start()
    {
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Users\Owner\Documents\Github\SupARmarket-AR-App\Product\Unity Project\SupARmarket\Assets\SQLite\Database.db;Version=3;"); //Locate SQLite Database

        connection.Open(); //Open connection to SQLite database

        Debug.Log("Database connection successful!");

        SQLiteCommand cmnd_read = connection.CreateCommand(); //Create command to read data
        SQLiteDataReader reader; //Create data reader

        //Query the database
        string query = "SELECT username FROM User;";

        //Read database command
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("username: " + reader[0].ToString());
        }

        connection.Close(); //Close connection to SQLite database
    }
}