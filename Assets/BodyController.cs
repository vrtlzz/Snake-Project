using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyController : MonoBehaviour
{
    public Text text;
    int score;
    public Transform Food;
    public Transform Body;
    public List<Transform> bodyList = new List<Transform>();
    Camera cam;

    private void Start()
    {
        bodyList.Add(this.transform);

         cam = Camera.main;
        score = 0;
    }



    private void FixedUpdate()
    {   
            for (int i = bodyList.Count - 1; i > 0; i--)
            {
                bodyList[i].transform.position = bodyList[i - 1].transform.position;
            }

        text.text = ("Score: " + score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {


            Vector3 randomViewportPoint = new Vector3( Random.value, Random.value, 0f);

            
            Vector3 randomWorldPoint = cam.ViewportToWorldPoint(randomViewportPoint);

            randomWorldPoint.z = 0f;

            Destroy(collision.gameObject);

            Instantiate(Food, randomWorldPoint, transform.rotation);

            Grow();
            score++;

        }
    }


    void Grow () 
    {
        Transform body = Instantiate(Body);
        body.position = bodyList[bodyList.Count - 1].position;

        bodyList.Add(body);
    }

}
