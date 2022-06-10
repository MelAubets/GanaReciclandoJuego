using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ranking;

    private void Start()
    {
        ranking.text = "";
        int numUsers = PlayerPrefs.GetInt("NumUsers");
        List<string> usernames = new List<string>();
        List<int> scores = new List<int>();

        for (int i = 1; i <= numUsers - 1; i++)
        {
            usernames.Add(PlayerPrefs.GetString("User" + i, ""));
            scores.Add(PlayerPrefs.GetInt(usernames[i - 1] + ".Score", 0));
        }

        for (int i = 1; i <= numUsers - 1; i++)
        {
            int n = 0;
            int max = 0;
            string maxUser = "";

            if(scores.Count != 0)
            {
                for (int j = 0; j <= scores.Count - 1; j++)
                {
                    if (scores[j] >= max)
                    {
                        max = scores[j];
                        maxUser = usernames[j];
                        n = j;
                    }
                }

                if(maxUser.Length <= 5)
                    ranking.text += maxUser + ": \t \t" + max.ToString() + "\n";
                else
                    ranking.text += maxUser + ": \t" + max.ToString() + "\n";

                scores.RemoveAt(n);
                usernames.RemoveAt(n);
            }


        }

    }
}
