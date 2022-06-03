using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    public Text state;
    public Animator animator;
    int isWin;
    void Start()
    {
        isWin = PlayerPrefs.GetInt("win");

        if( isWin == 0)
        {
            state.text = "Has Perdido!";
            animator.SetBool("isLose", true);
        }
        else
        {
            state.text = "Has Ganado!";
            animator.SetBool("isWin", true);
        }
    }

}
