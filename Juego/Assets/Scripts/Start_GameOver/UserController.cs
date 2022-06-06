using UnityEngine;
using TMPro;

public class UserController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text welcome;
    private bool exist = false;
    private int n;
    public void SetUsername(string username)
    {
        int numUsers = PlayerPrefs.GetInt("NumUsers", 0);
        string[] usernames = new string[numUsers + 1];

        for (int i = 1; i <= numUsers; i++)
        {
            usernames[i] = PlayerPrefs.GetString("User" + i, "");
            if (usernames[i] == username)
                exist = true;

            n = i;
        }

        if (!exist)
        {
            PlayerPrefs.SetString("User" + n, username);
            PlayerPrefs.SetInt("NumUsers", numUsers + 1);
        }

        PlayerPrefs.SetString("Username", username);

        welcome.text = "Bienvenido " + username + ", escoge el juego!";
    }
}
