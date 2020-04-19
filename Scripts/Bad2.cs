using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad2 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float mass = -10f;

    public Transform player;
    public GameObject deathEffect;
    public GameObject food;

    private void Start()
    {
        if(GameObject.Find("Player") == null)
        {
            Destroy(gameObject);
        }
        else
        {
            player = GameObject.Find("Player").transform;
        }
    }

    public void TakeDamage(float amount)
    {
        mass += amount;
        if (mass >= 0)
        {
            Die();
        }
    }

    public void TakeMass(float amount)
    {
        mass -= amount;
    }

    private void Die()
    {
        GameObject eff = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(eff, 3f);
        Instantiate(food, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }
        if(Vector2.Distance(transform.position, player.position ) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        transform.localScale = new Vector3(-mass*2, -mass*2, -mass*2);
    }
}
