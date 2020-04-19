using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadShooter : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float mass = -10f;

    private float timeBtwShoots;
    private float startTimBtwShoots =2f;

    public Transform player;
    public GameObject deathEffect;
    public GameObject food;
    public GameObject bull;

    private void Start()
    {
        timeBtwShoots = startTimBtwShoots;

        if(GameObject.Find("Player") == null)
        {
            Debug.Log("Not Found");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Found!");
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
        if (Vector2.Distance(transform.position, player.position ) > stoppingDistance)
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

        transform.localScale = new Vector3(-mass*2, -mass * 2, -mass * 2);

        if(timeBtwShoots <= 0)
        {
            GameObject lol = Instantiate(bull, transform.position, Quaternion.identity);
            timeBtwShoots = startTimBtwShoots;
            Destroy(lol, 3f);
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
