using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Transform spawnPosition;
    public Rigidbody cannonBall;
    public float force = 5F;
    protected float health = 1F;
    protected float daño;


    public int hp;

    [Header("UI")]
    public Image barra;

    protected void FireBullet()
    {
        Rigidbody cannonBallClone =
            Instantiate<Rigidbody>(
                cannonBall, spawnPosition.position, spawnPosition.rotation);

        cannonBallClone.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    public void ApplyDamage(int damageValue)
    {
        hp -= damageValue;
        daño = 1F / hp;
        health -= daño * damageValue;
        barra.fillAmount = health;

        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("gameOver");
        }
    }    
}
