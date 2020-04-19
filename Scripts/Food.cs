using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float mass = 1;

    void Start()
    {
        transform.localScale = new Vector3(mass*2, mass * 2, mass * 2);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Good"))
        {
            Good good = collider.GetComponent<Good>();
            mainGood mainGood = collider.GetComponent<mainGood>();
            player plr = collider.GetComponent<player>();
            if (good == true)
            {
                good.TakeMass(mass);
                Destroy(gameObject);
            }
            if (mainGood == true)
            {
                mainGood.TakeMass(mass);
                Destroy(gameObject);
            }
            if (plr == true)
            {
                plr.TakeMass(mass);
                Destroy(gameObject);
            }
        }
    }
}
