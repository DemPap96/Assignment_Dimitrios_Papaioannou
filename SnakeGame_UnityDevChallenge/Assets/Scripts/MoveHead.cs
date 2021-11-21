/*
 * This script is the brains of the game. It controls the head of the snake, when will foods been spawn and when parts of the tail will be added  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoveHead : MonoBehaviour
{
    public float speed = 5;         // The speed which the snake will travel
    public float rotateSpeed = 180; // The speed which the snake will turn/rotate its head
    public int gap = 30;            // The spacing between the tail parts
    public GameObject gameOverMenu; // The popup that appears when the player loses
    public TMP_Text score;          // The score that will be displayed
    public TMP_Text streak;         // The streak that will be displayed
    public GameObject food;         // The prefab food
    public GameObject tail;         // The prefab tail part

    int currentStreak;              // The current streak of the player (How many of the same food does they collected in a row)
    string previousColor;           // What color was the previous food that was eaten
        
    private List<GameObject> TailParts = new List<GameObject>(); //A list of all the tail parts
    private List<Vector3> trip = new List<Vector3>();           // A list of the trip of the snake (the positions that the tail will follow)

    private void Start()
    {

        gameOverMenu.SetActive(false);
        score.text = "0";
        streak.text = "0";
        previousColor = "";
        currentStreak = 0;

        spawnFood();

    }

    void Update()
    {
        //The snake moves constanly forward
        transform.position += transform.forward * speed * Time.deltaTime;
    
        //if we give the left or right arrow keys as input the snake turns
        float direction = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * direction * rotateSpeed * Time.deltaTime);

        //Save the position of the head of the snake
        trip.Insert(0, transform.position);

        //Move each tail part to the next position
        int i = 0;
        foreach (var part in TailParts)
        {
            Vector3 point = trip[Mathf.Min(i * gap, trip.Count - 1)];
            Vector3 move = point - part.transform.position;
            part.transform.position += move * speed * Time.deltaTime;
            i++;
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        //When the snake collides with anything the tag is checked. 
        //If it hit a wall or its tail the the game over screen pops up
        if (col.GetComponent<Collider>().tag == "Wall")
        {
            Debug.Log("Wall Hit");
            Debug.Log("Game Over");
            gameOverMenu.SetActive(true);
            speed = 0;
        }

        if (col.GetComponent<Collider>().tag == "Tail")
        {
            Debug.Log("Tail Hit");
            Debug.Log("Game Over");
            gameOverMenu.SetActive(true);
            speed = 0;
        }

        //If it hit a food then the food is checked
        if (col.GetComponent<Collider>().tag == "Food")
        {
            /*
            Debug.Log("Food Hit");
            */

            //Compare the color of the hitted food with the previous food that was hit
            //If its the same then increase the streak 
            if (col.GetComponent<Collider>().GetComponent<foodScript>().color.Equals(previousColor))
            {
                currentStreak++;
            }
            //If its not the same then set the streak to 1 and change the previousColor virable 
            else
            {
                currentStreak = 1;
                previousColor = col.GetComponent<Collider>().GetComponent<foodScript>().color;
            }

            //Increase the score appropriately using the previous score, the points that the food was worth and the current streak

            score.text = (Int32.Parse(score.text) + (col.GetComponent<Collider>().GetComponent<foodScript>().points * currentStreak)).ToString();
            streak.text = currentStreak.ToString();

            //Destroy the food object
            Destroy(col.gameObject);

            //Grow the tail
            spawnTail();

            //Spawn a new food object
            spawnFood();
        }

    }


    private void spawnFood()
    {
        //select a random position in the map and spawn a food
        int randomX = UnityEngine.Random.Range(-18, 18);
        int randomZ = UnityEngine.Random.Range(-12, 12);

        Instantiate(food, new Vector3(randomX,1,randomZ), transform.rotation);
    }

    private void spawnTail()
    {

        int distance = 2;
        Vector3 spawnPosition;
        //if it is the first tail part then spawn it near the head of the snake
        if (TailParts.Count == 0)
        {
            spawnPosition = transform.position - transform.forward * distance;
        }
        //if it is not the first tail part then spawn it near the last tail part of the snake
        else
        {
            spawnPosition = TailParts[TailParts.Count - 1].transform.position - transform.forward * distance;

        }

        GameObject part = Instantiate(tail, spawnPosition, transform.rotation);
        //Add the tail part to a list so we can move it in the update function
        TailParts.Add(part);

    }

}