using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed =  20f;
    public Rigidbody2D rb;
    public float mass = 2;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
        transform.localScale = new Vector3(mass*2, mass*2, mass*2);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bad2 bad = collider.GetComponent<Bad2>();
        BadShooter shooter = collider.GetComponent<BadShooter>();

        if (bad != null)
        {
            bad.TakeDamage(mass*3);
            GameObject imp = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(imp, 2f);
            Destroy(gameObject);
        }

        if (shooter != null)
        {
            shooter.TakeDamage(mass * 3);
            GameObject imp = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(imp, 2f);
            Destroy(gameObject);
        }


        if (collider.CompareTag("Good"))
        {
            Good good = collider.GetComponent<Good>();
            mainGood mainGood = collider.GetComponent<mainGood>();
            if(good == true)
            {
                good.TakeMass(mass);
                GameObject lol = Instantiate(impactEffect, transform.position, Quaternion.identity);
                Destroy(lol, 2f);
                Destroy(gameObject);
            }
            if (mainGood == true)
            {
                mainGood.TakeMass(mass/2);
                GameObject lol = Instantiate(impactEffect, transform.position, Quaternion.identity);
                Destroy(lol, 2f);
                Destroy(gameObject);
            }
        }
    }
}
