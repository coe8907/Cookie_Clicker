
using UnityEngine;
using System;
//using System.Data;
using System.Text;

//using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.IO;

public struct userInfo{
    public List<int> score;// = new List<int>();
    public List<string> username;// = new List<string>();
};


public class Connect_to_SQL : MonoBehaviour
{
    public string host, database, user, password;
   
    private string connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;
    private string path_start = "Assets";
   
   // private MD5 _md5Hash;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            path_start = Application.persistentDataPath;
        }

        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling= True";
       
       
        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql state: " + con.State);

            string sql = "SELECT * FROM Users";
            cmd = new MySqlCommand(sql, con);
            //			string sql = "SELECT * FROM clothes";
            //			cmd = new MySqlCommand(sql, con);
            //			rdr = cmd.ExecuteReader();
            //
            //			while (rdr.Read())
            //			{
            //				Debug.Log("???");
            //				Debug.Log(rdr[0]+" -- "+rdr[1]);
            //			}
            //			rdr.Close();

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    void onApplicationQuit()
    {
        if (con != null)
        {
            if (con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("Mysql connection closed");
            }
            con.Dispose();
        }
    }
    // add new user to the data base
    public bool Add_User(string name, string password)
    {
        string command = string.Format("INSERT INTO Users(User_name,Password,Cookies,Muffins) VALUES (\"{0}\",\"{1}\",0,0)",name,password);
        Debug.Log(command);
        cmd = new MySqlCommand(command, con); ;
        cmd.ExecuteNonQuery();
        return true;
    }
    public bool Update_User(string id,string name, int cookies,int muffins,int[] levels)
    {

        /*update server side with number of cookies*/
        string command = string.Format("UPDATE `Users` SET `Cookies` = '{0}' WHERE `Users`.`ID` = {1}", cookies.ToString(), id.ToString());
        cmd = new MySqlCommand(command, con); ;
        cmd.ExecuteNonQuery();

        /*update server side with users muffins*/
         command = string.Format("UPDATE `Users` SET `Muffins` = '{0}' WHERE `Users`.`ID` = {1}", muffins.ToString(), id.ToString());
        cmd = new MySqlCommand(command, con); ;
        cmd.ExecuteNonQuery();

        /*Up date server side with the upgrades values*/
        for (int i = 0; i < 9; i++)
        {
            command = string.Format("UPDATE `Users` SET `upgrade{0}` = '{1}' WHERE `Users`.`ID` = {2}", i.ToString(), levels[i].ToString(), id.ToString());
            cmd = new MySqlCommand(command, con); ;
            cmd.ExecuteNonQuery();
        }
        Debug.Log("Push data to server");
        return false;
    }
    public userInfo Get_Scores()
    {
        userInfo temp = new userInfo();
        temp.score = new List<int>();
        temp.username = new List<string>();
        string sql = "SELECT * FROM Users";
        cmd = new MySqlCommand(sql, con);
        using (rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
               // Debug.Log(rdr[1]+  "  -  " + rdr[3]);
                temp.score.Add(int.Parse(rdr[3].ToString()));
                temp.username.Add(rdr[1].ToString());
            }
        }
        Debug.Log("time");
        return temp;
    }
    // test the users log its not sucure in any way but it will work for the pupose of the demo
    public bool Test_Login(string username,string password)
    {

        string sql = "SELECT * FROM Users";
        cmd = new MySqlCommand(sql, con);
        using (rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                if(rdr[1].ToString() == username)
                {
                    if(rdr[2].ToString() == password)
                    {
                        string path = path_start + "/Save_File.txt";
                        if (File.Exists(path))
                        {
                            File.WriteAllText(path, "");
                            File.Create(path).Close();
                        }

                        StreamWriter writer = new StreamWriter(path, true);
                        for(int i = 0; i < 15; i++)
                        {
                            if (i != 2)
                            {
                                writer.WriteLine(rdr[i].ToString());
                            }
                        }
                       
                        //writer.WriteLine(rdr[2]);
                        //writer.WriteLine(rdr[3].ToString());
                        //writer.WriteLine(rdr[4]);
                        writer.Close();




                        return true;
                    }
                }
               // names.Add(rdr[1].ToString());
               // passwords.Add(rdr[2].ToString());
            }
        }
        return false;
    }
    
    public string GetConnectionState()
    {
        return con.State.ToString();
    }
    public bool Con()
    {
        string r = con.State.ToString();
        return (r == "Open");
    }
}
