﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float xRange = 20.0f;
    public GameObject projectile;

    public int health; //Player's health
    public bool isGameOver = false;

    public bool restart = false;

    private SpriteRenderer hp1;
    private SpriteRenderer hp2;
    private SpriteRenderer hp3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        hp1 = canvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
        hp2 = canvas.transform.GetChild(1).GetComponent<SpriteRenderer>();
        hp3 = canvas.transform.GetChild(2).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectile, transform.position, projectile.transform.rotation);
            }

            // Move left/right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

            // if/else if the player goes beyond the camera's view
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            else if (isGameOver && Input.GetKeyDown(KeyCode.Space))
            {
                isGameOver = false;
                health = 4;
                LoseHP();
                restart = true;
            }
        }
        
    }
    public void LoseHP()
    {
        if (health >= 0)
        {
            health--;
            switch (health)
            {
                case 2:
                    hp3.gameObject.SetActive(false);
                    break;
                case 1:
                    hp2.gameObject.SetActive(false);
                    break;
                case 0:
                    hp1.gameObject.SetActive(false);
                    isGameOver = true;

                    break;
                default:
                    hp3.gameObject.SetActive(true);
                    hp2.gameObject.SetActive(true);
                    hp1.gameObject.SetActive(true);
                    break;

            }
        }
    }
}
