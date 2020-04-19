using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainGood : MonoBehaviour
{
    public float mass = 20f;

    private bool Alive = true;
    //
    private float TimeLoose = 10f;
    private float massLoose = 1;
    private float DisiredToNextSec = 4f;
    private float DisiredToNextMassLoose = 7f;
    private float timeToNextSec = 4f;
    private float timeToNextMassLoose = 7;
    private float AT = 4f;
    private float AM = 4f;
    private float DAT = 4f;
    private float DAM = 4f;
    private Transform player;
    //
    public GameManager gameManager;


    public void TakeMass(float _mass)
    {   if(!Alive)
        {
            return;
        }
        mass += _mass;
        gameManager.SetHealth(mass);
    }

    public void TakeDamage(float _mass)
    {
        if (!Alive)
        {
            return;
        }
        
        mass -= _mass;
        gameManager.SetHealth(mass);
        if (mass <= 0)
        {
            Alive = false;
            GameEnded();

        }
    }

    private void Start()
    {
        gameManager.SetHealth(mass);
        StartCoroutine(looseMass());
    }

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").transform;
        }
        if (!Alive)
        {
            return;
        }
        transform.localScale = new Vector3(mass, mass, mass);

        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator looseMass()
    {
        if (Alive)
        {
            yield return new WaitForSeconds(TimeLoose);
            timeToNextSec--;
            timeToNextMassLoose--;
            mass -= massLoose;

            if (mass <= 0)
            {
                GameEnded();

            }
            else
            {
                gameManager.SetHealth(mass);
            }

            if (timeToNextSec == 0f)
            {
                timeToNextSec = DisiredToNextSec;
                massLoose++;
                AT--;
            }
            if (timeToNextMassLoose == 0f)
            {
                timeToNextMassLoose = DisiredToNextMassLoose;

                massLoose += 0.8f;
                AM--;
            }
            if (AT == 0f)
            {
                AT = DAT;
                DisiredToNextSec--;
            }
            if (AM == 0f)
            {
                AM = DAM;
                DisiredToNextMassLoose--;
            }
            StartCoroutine(looseMass());
        }
        
    }

    void GameEnded()
    {
        Alive = false;
        gameManager.GameEnded();

    }

}
