using UnityEngine;

public class Enemy : Character
{
    public float movementSpeed = 5F;
    public float timeToShoot = 3F;   

    private float movementValue = 0F;
    private float elapsedTime;
    private bool returning = false;    

    private void Start()
    {
        InvokeRepeating("FireBullet", 0F, timeToShoot);
    }

    // Update is called once per frame
    private void Update()
    {
        spawnPosition.LookAt(
            GameObject.FindGameObjectWithTag("Player").transform);

        movementValue = Mathf.Lerp(-1F, 1F, elapsedTime);

        if (movementValue != 0)
        {
            transform.Translate(transform.right * movementValue * movementSpeed * Time.deltaTime);
        }

        if (movementValue <= -1F)
        {
            returning = false;
        }
        else if (movementValue >= 1F)
        {
            returning = true;
        }

        elapsedTime += Time.deltaTime * (returning ? -1 : 1);
    }
}