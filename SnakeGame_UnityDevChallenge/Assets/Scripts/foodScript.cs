/*
 * This is the script that is responsible to give which each food that is created its stats
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    public string color;
    public int points;
    private GameObject LoadGame;

    void Start()
    {
        LoadGame = GameObject.Find("LoadGame");

        LoadDataConfiguration data = LoadGame.GetComponent<LoadDataConfiguration>();

        /*
        Debug.Log("Count:"+ data.points.Count);
        */

        //Choose a random type of food
        int pos = Random.Range(0, data.points.Count);

        //Assign the color and points to this food
        color = data.colors[pos];
        points = data.points[pos];

        /*
        Debug.Log(color + points.ToString());
        */


        //We detect what color was written in the text file.
        if (color.Equals("red"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (color.Equals("green"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (color.Equals("blue"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (color.Equals("black"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }
        else if (color.Equals("cyan"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        }
        else if (color.Equals("gray"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else if (color.Equals("grey"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
        }
        else if (color.Equals("magenta"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        }
        else if (color.Equals("white"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
        else if (color.Equals("yellow"))
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
    }

    private void Update()
    {
        //Rotate the food so there is some extra motion in the game
        transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }
}
