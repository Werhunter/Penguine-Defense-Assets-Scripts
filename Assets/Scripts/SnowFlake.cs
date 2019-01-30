using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{
    public float SnowFlakeMovementSpeed = 0f;

    private void Update()
    {
        //get the current position of the star
        Vector2 position = transform.position;

        //compute the star's new position
        position = new Vector2(position.x, position.y + SnowFlakeMovementSpeed * Time.deltaTime);

        //Update the star's position
        transform.position = position;

        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if the star goes outside the screen on the bottom,
        //then position the star on the top of the edge of the screen
        //and randomly between the left and right side of the screen
        if (transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}