using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_forward : MonoBehaviour
{
    public float speed;
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Destroy if it's too far
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            Debug.Log("Food Destroyer");
        }
        if (transform.position.z < lowerBound)
        {
            //Destroy if it already passed beyon the player movement
            Destroy(gameObject);
            Debug.Log("Die Animal");
        }

    }
}
