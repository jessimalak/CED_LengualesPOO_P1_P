using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public float movementSpeed = 5F;  

    private float movementValue = 0F;

    public Text vida;
    

    //private void Start()
    //{
    //    InvokeRepeating("FireBullet", 0F, 3F);
    //}    

    // Update is called once per frame
    private void Update()
    {
        vida.text = hp.ToString();

        if (hp == 0)
        {
            SceneManager.LoadScene("gameOver");
        }

        if (Input.GetMouseButtonUp(0))
        {
            FireBullet();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(
                transform.right * Input.GetAxis("Horizontal")
                * movementSpeed * Time.deltaTime);
        }
    }    
}