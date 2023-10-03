using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //vehicle location
    [SerializeField] Vector3 objectPosition = new Vector3(0, 0, 0);

    //speed in units per second
    [SerializeField] float speed = 4f;

    //direction the vehicle is facing, MUST BE NORMALIZED
    [SerializeField] Vector3 direction = new Vector3(1, 0, 0);  //or Vector3.right

    //the change in position for a single frame
    [SerializeField] Vector3 velocity = new Vector3(0, 0, 0);

    //all possible sprites: 0/F, 1/L, 2/R, 3/B
    [SerializeField] List<Sprite> possibleSprites;

    //the spriteinfo we're editing
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] Camera mainCam;
    [SerializeField] float height;
    [SerializeField] float width;

    public void Start()
    {
        height = mainCam.orthographicSize;
        width = height * mainCam.aspect;
    }

    public void SetDirection(Vector3 newDirection)
    {
        if (newDirection != null)
        {
            direction = newDirection.normalized;

            //Change the direction the sprite is facing:
            if (direction == Vector3.down)
            {
                spriteRenderer.sprite = possibleSprites[0];
            }
            if (direction.y > 0)
            {
                spriteRenderer.sprite = possibleSprites[3];
            }
            if (direction == Vector3.left)
            {
                spriteRenderer.sprite = possibleSprites[1];
            }
            if (direction == Vector3.right)
            {
                spriteRenderer.sprite = possibleSprites[2];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        //Add the velocity to current position
        objectPosition += velocity;

        // TODO: Add vertical scrolling

        //car is hitting the left bound
        if (objectPosition.x < -width)
        {
            objectPosition.x = -width;
        }
        //car is hitting the right bound
        else if (objectPosition.x > width)
        {
            objectPosition.x = width;
        }
        //car is hitting the bottom bound
        else if (objectPosition.y < -height)
        {
            objectPosition.y = -height;
        }
        //car is hitting the top bound
        else if (objectPosition.y > height)
        {
            objectPosition.y = height;
        }


        //Draw vehicle at that positon
        transform.position = objectPosition;
    }
}
