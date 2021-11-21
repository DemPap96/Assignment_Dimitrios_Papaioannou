using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetTopScore : MonoBehaviour
{
    public TMP_Text topscore;

    //Show the top score in the Main Screen
    void Start()
    {
        topscore.text = PlayerPrefs.GetInt("TopScore").ToString();
    }
}
