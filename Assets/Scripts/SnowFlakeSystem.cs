using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeSystem : MonoBehaviour
{
    [SerializeField] private bool WantColor;

    public GameObject Prefab_SnowFlake; //this is our star prefab
    public int MaxSnowflakes = 10; //the maximum number of stars
    //public Transform Star_Spawn_Location;

    private Color[] SnowFlakeColors =
   {
        new Color (0.5f, 0.5f, 1f),  //blue
        new Color (0, 1f, 1f),       //green
        new Color (1f, 1f, 0),       //yellow
        new Color (1f, 0, 0),        //red
        new Color (255f, 0, 51)      //crimson red/purple
    };

    private void Start()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //loop to create the stars
        for (int i = 0; i < MaxSnowflakes; ++i)
        {
            GameObject SnowFlake = (GameObject)Instantiate(Prefab_SnowFlake);

            if (WantColor == true)
            {
                //set the star color
                SnowFlake.GetComponent<SpriteRenderer>().color = SnowFlakeColors[i % SnowFlakeColors.Length];
            }

            //set the position of the star (random x and random y)
            SnowFlake.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed for the star
            SnowFlake.GetComponent<SnowFlake>().SnowFlakeMovementSpeed = -(1f * Random.value + 0.5f);

            //make the star a child of the Star_Generator
            SnowFlake.transform.parent = transform;
        }
    }
}