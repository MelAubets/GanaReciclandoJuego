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
        int numUsers = PlayerPrefs.GetInt("NumUSers");
        List<string> usernames = new List<string>();
        List<int> scores = new List<int>();
        //string[] usernames = new string[numUsers + 1];
        //int[] scores = new int[numUsers + 1];
        for (int i = 1; i <= numUsers; i++)
        {
            usernames[i] = PlayerPrefs.GetString("User" + i, "");
            scores[i] = PlayerPrefs.GetInt(usernames[i] + ".Score", 0);
        }

        for (int i = 1; i <= numUsers + 1; i++)
        {
            int n = 0;
            int max = 0;
            string maxUser = "";
            for (int j = 1; j <= scores.Count; j++)
            {
                if (scores[j] > max)
                {
                    max = scores[j];
                    maxUser = usernames[j];
                    n = j;
                }
            }
            ranking.text = maxUser + ":\t" + max + "\n";

            scores.RemoveAt(n);
            usernames.RemoveAt(n);
        }

    }
}
