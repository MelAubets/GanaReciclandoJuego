using UnityEngine;
using System.Runtime.InteropServices;

public class GameController : MonoBehaviour
{
    public Container container;
    public Board board;

    [DllImport("__Internal")]
    private static extern void GameOver(int score);

    public void SomeMethod()
    {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
    GameOver(200);
#endif
    }
}