using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Cookie_Counter : MonoBehaviour {
    public int num_cookies = 0;
    public Text text_box;
    int[] level;
    string id = "";
    string name = "";
    bool localsave = false;
    string path_start = "Assets";
    public GameObject muffin_counter;
	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.Android)
        {
            path_start = Application.persistentDataPath;
        }
        string path = path_start + "/Save_File.txt";
        level = new int[20];
        if (File.Exists(path))
        {
            localsave = true;
        }
        if (localsave)
        {
            StreamReader reader;
            reader = new StreamReader(path);
            id = reader.ReadLine().ToString();
            name = reader.ReadLine().ToString();
            num_cookies = int.Parse(reader.ReadLine());
            muffin_counter.GetComponent<Muffin_Counter>().muffin_count = int.Parse(reader.ReadLine());
            reader.Close();
            
        }
        else
        {
            id = "no save";
            name = "no save";
            save_data();
        }

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
        Debug.Log("Save 1");
        string path = path_start + "/Save_File.txt";
        if (File.Exists(path))
        {
            File.WriteAllText(path, "");
            File.Create(path).Close();
        }
        Debug.Log("Save 2");
        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(id);
        writer.WriteLine(name);
        writer.WriteLine(num_cookies.ToString());
        writer.WriteLine(muffin_counter.GetComponent<Muffin_Counter>().muffin_count.ToString());
        for (int i = 0; i < 20; i++)
        {
            writer.WriteLine(level[i].ToString());
            Debug.Log("Saved file" + level[i].ToString());
        }
        writer.Close();
        if (localsave && gameObject.GetComponent<Connect_to_SQL>().Con())
        {
            gameObject.GetComponent<Connect_to_SQL>().Update_User(id, name, num_cookies, muffin_counter.GetComponent<Muffin_Counter>().muffin_count, level);
        }
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
