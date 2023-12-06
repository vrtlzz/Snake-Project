using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    
    public Transform Food;
    public Transform Body;
    public List<Transform> bodyList = new List<Transform>();

    private void Start()
    {
        bodyList.Add(this.transform);
    }



    private void FixedUpdate()
    {   
            for (int i = bodyList.Count - 1; i > 0; i--)
            {
                bodyList[i].transform.position = bodyList[i - 1].transform.position;
            } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Vector3 randomPosition = new Vector3(
                                     Random.Range(-40, 40),
                                     Random.Range(-19, 19), 0);

            Destroy(collision.gameObject);
            Instantiate(Food, randomPosition, transform.rotation);
            Grow();

        }
    }


    void Grow () 
    {
        Transform body = Instantiate(Body);
        body.position = bodyList[bodyList.Count - 1].position;

        bodyList.Add(body);
    }

}
