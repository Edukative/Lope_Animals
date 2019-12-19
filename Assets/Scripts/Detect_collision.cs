using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_collision : MonoBehaviour
{
    public Playercontroller player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.tag == "Player" && this.tag == "Animal")
        {
            Playercontroller player = other.GetComponent<Playercontroller>();
            player.LoseHP();
            Debug.Log(player.health);
            Destroy(gameObject);
        }
        else if (this.tag != "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
