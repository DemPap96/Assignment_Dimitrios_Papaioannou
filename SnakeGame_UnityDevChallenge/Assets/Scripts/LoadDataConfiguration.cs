using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadDataConfiguration : MonoBehaviour
{
    //The text file frin which we will collect data
    public TextAsset dataconfig;

    //The two list that will hold the different types of foods
    public List<int> points = new List<int>();
    public List<string> colors = new List<string>();

    void Start()
    {
        /*
        Debug.Log(dataconfig.text);
        */


        //Spliting the context of the .txt file into words by detecting the space and change line characters
        string[] words = dataconfig.text.Split(' ', '\n', '\t');
        int i = 0;

        foreach (var word in words)
        {
            /*
            Debug.Log(word);
            */
            if (i % 2 == 0)
            {
                //Check that the file is in the correct format (lowercase check)
                if (char.IsUpper(word[0]))
                {
                    Debug.LogError(".txt File has not the correct format. Format (color(lowercase) integer)Example Format: red 50");
#if UNITY_EDITOR
                    // Application.Quit() does not work in the editor
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                }
                else
                {
                    colors.Add(word);
                }

            }
            else
            {
                //Check that the file is in the correct format (integer check)
                try
                {
                    points.Add(Int32.Parse(word));
                }
                catch(FormatException e)
                {
                    Debug.LogError(".txt File has not the correct format. Format (color(lowercase) integer)Example Format: red 50");
                    Debug.LogError(e);
#if UNITY_EDITOR
                    // Application.Quit() does not work in the editor
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
                }
            }

            i++;
        }
        /*
        for(int j = 0; j < points.Count; j++)
        {
            Debug.Log(points[j]);
        }
        for (int j = 0; j < colors.Count; j++)
        {
            Debug.Log(colors[j]);
        }
        */
    }
}
