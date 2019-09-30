using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Collider myCollider;

    public ParticleSystem particles;
    public AudioSource impact; 

    public int damage = 1;

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        if (myRigidbody != null)
        {
            GameObject impactFXGO = GameObject.FindGameObjectWithTag("Impact");
            Invoke("AutoDestroy", 10F);

            myCollider = GetComponent<Collider>();

            if (myCollider != null)
            {
                myCollider.isTrigger = false;
            }
        }
        else
        {
            AutoDestroy();
        }
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" 
            || col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Character>().ApplyDamage(damage);
        }

        //if (col.gameObject.tag == "Player")
        //{
        //    col.gameObject.GetComponent<Player>().ApplyDamage(damage);
        //}
        //else if (col.gameObject.tag == "Enemy")
        //{
        //    col.gameObject.GetComponent<Enemy>().ApplyDamage(damage);
        //}

        if (particles != null)
        {
            Instantiate<ParticleSystem>(particles, transform.position, particles.transform.rotation).Play();
        }

        AutoDestroy();
    }
}