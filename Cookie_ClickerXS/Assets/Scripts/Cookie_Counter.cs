using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Cookie_Counter : MonoBehaviour {
    public int num_cookies = 0;
    public Text text_box;
    int[] level = new int[20];
    string id = "";
    string name = "";
    
	// Use this for initialization
	void Start () {
        string path = "Assets/Save_File.txt";
        StreamReader reader;
        reader = new StreamReader(path);
         id = reader.ReadLine().ToString();
        name = reader.ReadLine().ToString();
        num_cookies = int.Parse(reader.ReadLine());
        reader.Close();

    }
    public void update_data(int level_id, int level_d)
    {
        level[level_id] = level_d;
    }
    void OnApplicationQuit()
    {
        Debug.Log("end game");
        save_data();
    }
    void OnDestroy()
    {
        Debug.Log("switch scene");
        save_data();
    }
    public void save_data()
    {
        Debug.Log("end game2");
        string path = "Assets/Save_File.txt";
        if (File.Exists(path))
        {
           File.WriteAllText(path, "");
            File.Create(path).Close();
        }
        Debug.Log("end game3"   );
        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(id);
        writer.WriteLine(name);
        writer.WriteLine(num_cookies.ToString());
        for (int i = 0; i < 20; i++)
        {
            writer.WriteLine(level[i].ToString());
            Debug.Log("saveed file" + level[i].ToString());
        }
        writer.Close();
        gameObject.GetComponent<Connect_to_SQL>().Update_User(id, name, num_cookies, level);
    }
    
	public void Add_Cookies(int num)
    {
        num_cookies += num;
        text_box.text = string.Format("Cookies: {0}",num_cookies);
    }
    public bool Can_buy(int cost)
    {
        if(num_cookies >= cost)
        {
            num_cookies -= cost;
            text_box.text = string.Format("Cookies: {0}", num_cookies);
           
            return true;
        }
        return false;
    }

}
