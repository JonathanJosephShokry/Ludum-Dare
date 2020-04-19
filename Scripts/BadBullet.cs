using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
{
    public float speed = 20f;
    public float mass = 2;

    public Rigidbody2D rb;
    private Transform player;
    private Vector2 target;
    public GameObject BadImpactEffect;

    void Start()
    {
        Debug.Log("Spawned");
        if (GameObject.Find("Player")== null)
        {
            Debug.Log("didn't find plr");
            Destroy(gameObject);
        }
        else
        {
            player = GameObject.Find("Player").transform;
            target = new Vector2(player.position.x, player.position.y);
        }
        transform.localScale = new Vector3(mass, mass, mass);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Good"))
        {
            Good good = collider.GetComponent<Good>();
            mainGood mainGood = collider.GetComponent<mainGood>();
            player plr = collider.GetComponent<player>();
            if (plr == true)
            {
                plr.TakeDamage(mass);
                Instantiate(BadImpactEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
