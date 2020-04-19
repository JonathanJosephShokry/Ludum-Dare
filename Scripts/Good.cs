using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good : MonoBehaviour
{
    public float mass = 5;
    private bool good = false;
    private bool bad = false;
    public SpriteRenderer rend;
    public GameObject foodPrefab;
    public LineRenderer line;
    public Transform give;
    public mainGood main;
    private bool making = false;
    private bool Max = false;

    private void Start()
    {
        main = GameObject.Find("Creature]").GetComponent<mainGood>();
    }

    public void TakeMass(float _mass)
    {
        if (mass >= 15f)
        {
            Max = true;
            good = false;
            rend.color = Color.yellow;
        }
        if (Max)
        {
            return;
        }
         mass += _mass;
        
        
    }

    private void Update()
    {
        if(bad)
        {
            transform.localScale = new Vector3(-mass, -mass, -mass);
        }else
        {
            transform.localScale = new Vector3(mass, mass, mass);
        }
        
        if(mass < 0)
        {
            bad = true;
        }
        else if (mass > 8f )
        {   
            if (!making)
            {
                making = true;
                MakeFood();
            }
            if(mass<15)
            {
                good = true;
            }
            
        }




        if (good)
        {
            rend.color = Color.green;
        }
        else if (Max)
        {
            rend.color = Color.yellow;
        }
        else if (bad)
        {
            rend.color = Color.red;
        }
        else
        {
            rend.color = Color.white;
        }
    }

    void MakeFood()
    {
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(0, transform.position);
        Debug.DrawLine(transform.position, Vector3.zero, Color.green);
        StartCoroutine(Feed());
    }

    IEnumerator Feed()
    {
        yield return new WaitForSeconds(10f);

        main.TakeMass(mass/40);
        StartCoroutine(Feed());
    }
}
