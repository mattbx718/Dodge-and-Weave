using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //variables
    private Vector2 direction; //control direction of movement

    List<Transform> segments;    // variable to store all the parts if the body of the snake
    public Transform bodyPrefab;   //variable to store the body 


    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>();      //create a new list
        segments.Add(transform);               // add the head of the snake to th list 
    }

    // Update is called once per frame
    void Update()
    {
        // change direction of the snake
        if (Input.GetKeyDown(KeyCode.W)) //when W key is pressed
        {
            direction = Vector2.up; // go up
        }
        else if (Input.GetKeyDown(KeyCode.S)) //when S key is pressed
        {
            direction = Vector2.down; // go down
        }
        else if (Input.GetKeyDown(KeyCode.A)) //when A key is pressed
        {
            direction = Vector2.left; // go left
        }
        else if (Input.GetKeyDown(KeyCode.D)) // when D key is pressed
        {
            direction = Vector2.right; // go right 
        }
    }

    // FixedUpdate is called at a fix interval
    void FixedUpdate()
    {

        //move the body of the snake 
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        //move the snake                                                    
        this.transform.position = new Vector2(                    //get the position   
            Mathf.Round(this.transform.position.x) + direction.x, //round the number add value to x
            Mathf.Round(this.transform.position.y) + direction.y  // round the number add value to y
            );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")   // So the player dies when hitting the walls
        {
            Debug.Log("Hit");
            SceneManager.LoadScene("EndScene"); //change to end scene
          
        }
        else if (other.tag == "Obstacle")   // So the player dies when hitting the walls
        {
            Debug.Log("Hit");
            SceneManager.LoadScene("EndScene"); //change to end scene

        }

    }


}