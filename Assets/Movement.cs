using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 direction;

    private void Start()
    {   
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = Vector2.left;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            direction = Vector2.right;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            direction = Vector2.down;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            direction = Vector2.up;
        }
    }


    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round( this.transform.position.x + direction.x),
            Mathf.Round(this.transform.position.y + direction.y),
            0
            );
    }


}






