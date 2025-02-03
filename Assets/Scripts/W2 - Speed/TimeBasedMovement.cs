using UnityEngine;
using System;
using TMPro;

public class TimeBasedMovement : MonoBehaviour
{
    public float speed = 2;
    public float time;
    public TextMeshProUGUI displayText;

    public float GameTime = 3;
    void Start()
    {
        // displayText.text = "Hello World";
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        // Move the object
        Vector3 newPos = transform.position;
        newPos.x += speed * Time.deltaTime;
        transform.position = newPos;

        // Update the display text
        displayText.text = "Time: " + (GameTime - (int)time);

        // Check if the game is over
        if (time > GameTime)
        {
            displayText.text = "Game Over";
        }
    }
}
