using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup_leaders : MonoBehaviour {
    userInfo user_data;
    // Use this for initialization
    public GameObject Leader;
    public GameObject perent_t;
	void Start () {
        Debug.Log("mine ");
        user_data = gameObject.GetComponent<Connect_to_SQL>().Get_Scores();
        
        userInfo sorted_data;
        sorted_data.username = new List<string>();
        sorted_data.score = new List<int>();
        for (int i = 0; i < user_data.username.Count; i++)
        {
            int best = 0;
            for(int x = 0; x < user_data.username.Count; x++)
            {
                if(user_data.score[x] > user_data.score[best])
                {
                    best = x;
                }
            }
           


            sorted_data.username.Add(user_data.username[best]);
            sorted_data.score.Add(user_data.score[best]);
            user_data.username.RemoveAt(best);
            user_data.score.RemoveAt(best);
            i = -1;
        }


        for (int i = 0; i < sorted_data.username.Count;i++)
        {
            setup(sorted_data.username[i], sorted_data.score[i]);
        }
    }
    
    void setup(string name, int score)
    {
        
        GameObject leader = (GameObject)Instantiate(Leader);
        leader.transform.SetParent(perent_t.transform);
        leader.GetComponent<Leaders_script>().set_up(name, score);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
