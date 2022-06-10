using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel , Board;
    public void Continue()
    {
        Board.SetActive(true);
        Panel.SetActive(false);
    }
}
