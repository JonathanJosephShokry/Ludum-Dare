using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public GameObject food;
    public GameObject bad;
    public GameObject badBig;
    public GameObject badSmall;
    public GameObject badG;
    public GameObject goodPrefab;
    public GameObject shooter;

    public float ksafaFood = 100f;
    public float ksafaGood = 25f;

    private float secFood = 1f;
    private float secShooter = 120f;

    //bad
    private int numberOfEnemes = 1;
    private int countarFornumberToAccelerate = 20;//when it is zero Number encrease
    private int defaultCountarFornumberToAccelerate = 20;//default for above
    private float enemyCreationSpeed = 20;//Time to create one
    private int countarForTimToAccelerate = 10;//when it is zero Time encrease
    private int defaultCountarForTimToAccelerate  = 3;
    private int enemyCreationAcceleration = 3;//low = more enemies

    //Big
    private int numberOfBig = 1;
    private int countarFornumberToAccelerateb = 30;//when it is zero --> Number encrease
    private int defaultCountarFornumberToAccelerateb = 30;//default for above
    private float enemyCreationSpeedb = 40;//Time to create one
    private int countarForTimToAccelerateb = 40;//when it is zero Time encrease
    private int defaultCountarForTimToAccelerateb = 4;
    private int enemyCreationAccelerationb = 4;//low = more enemies

    //small
    private int numberOfSmall = 1;
    private int countarFornumberToAccelerates = 20;//when it is zero Number encrease
    private int defaultCountarFornumberToAccelerates = 20;//default for above
    private float enemyCreationSpeeds = 30;//Time to create one
    private int countarForTimToAccelerates = 30;//when it is zero Time encrease
    private int defaultCountarForTimToAccelerates = 3;
    private int enemyCreationAccelerations = 4;//low = more enemies

    //G
    private int numberOfG = 1;
    private int countarFornumberToAccelerateg = 80;//when it is zero Number encrease
    private int defaultCountarFornumberToAccelerateg = 60;//default for above
    private float enemyCreationSpeedg = 60;//Time to create one
    private int countarForTimToAccelerateg = 60;//when it is zero Time encrease
    private int defaultCountarForTimToAccelerateg = 6;
    private int enemyCreationAccelerationg = 8;//low = more enemies

    private float startposition = 117f;
    private void Start()
    {
        for (int i = 0; i < ksafaFood; i++)
        {
            float x = Random.Range(-startposition, startposition);
            float y = Random.Range(-startposition, startposition);
            Instantiate(food, new Vector3(x, y, 0f), Quaternion.identity);
        }

        for (int i = 0; i < ksafaGood; i++)
        {
            float x = Random.Range(-startposition, startposition);
            float y = Random.Range(-startposition, startposition);
            Instantiate(goodPrefab, new Vector3(x, y, 0f), Quaternion.identity);
        }

        StartCoroutine(Bad());
        StartCoroutine(Food());
        StartCoroutine(BadBig());
        StartCoroutine(BadSmall());
        StartCoroutine(BadShooter());
    }

    IEnumerator Bad()
    {
        yield return new WaitForSeconds(enemyCreationSpeed);

        for (int i = 0; i < numberOfEnemes; i++)
        {
            float x = Random.Range(-020, 100);
            float y = Random.Range(-100, 100);
            Instantiate(bad, new Vector3(x, y, 0f), Quaternion.identity);
            
        }
        countarForTimToAccelerate--;
        countarFornumberToAccelerate--;
        if (countarFornumberToAccelerate == 0)
        {
            countarFornumberToAccelerate = defaultCountarFornumberToAccelerate;
            numberOfEnemes++;
        }
        if (countarForTimToAccelerate == 0)
        {
            countarForTimToAccelerate = defaultCountarForTimToAccelerate;
            enemyCreationAcceleration--;
            enemyCreationSpeed--;
            
        }
        if(enemyCreationAcceleration == 0)
        {
            defaultCountarForTimToAccelerate-= 2;
            
        }
        StartCoroutine(Bad());
    }

    IEnumerator BadBig()
    {
        yield return new WaitForSeconds(enemyCreationSpeedb);

        for (int i = 0; i < numberOfBig; i++)
        {
            float x = Random.Range(-020, 100);
            float y = Random.Range(-100, 100);
            Instantiate(badBig, new Vector3(x, y, 0f), Quaternion.identity);

        }
        countarForTimToAccelerateb--;
        countarFornumberToAccelerateb--;
        if (countarFornumberToAccelerateb == 0)
        {
            countarFornumberToAccelerateb = defaultCountarFornumberToAccelerateb;
            numberOfBig++;
        }
        if (countarForTimToAccelerateb == 0)
        {
            countarForTimToAccelerateb = defaultCountarForTimToAccelerateb;
            enemyCreationAccelerationb--;
            enemyCreationSpeedb--;

        }
        if (enemyCreationAccelerationb == 0)
        {
            defaultCountarForTimToAccelerateb -= 2;

        }
        StartCoroutine(BadBig());
    }
    IEnumerator BadSmall()
    {
        yield return new WaitForSeconds(enemyCreationSpeeds);

        for (int i = 0; i < numberOfSmall; i++)
        {
            float x = Random.Range(-020, 100);
            float y = Random.Range(-100, 100);
            Instantiate(badSmall, new Vector3(x, y, 0f), Quaternion.identity);

        }
        countarForTimToAccelerates--;
        countarFornumberToAccelerates--;
        if (countarFornumberToAccelerates == 0)
        {
            countarFornumberToAccelerates = defaultCountarFornumberToAccelerates;
            numberOfSmall++;
        }
        if (countarForTimToAccelerates == 0)
        {
            countarForTimToAccelerates = defaultCountarForTimToAccelerates;
            enemyCreationAccelerations--;
            enemyCreationSpeeds--;

        }
        if (enemyCreationAccelerations == 0)
        {
            defaultCountarForTimToAccelerates -= 2;

        }
        StartCoroutine(BadSmall());
    }

    IEnumerator BadG()
    {
        yield return new WaitForSeconds(enemyCreationSpeedg);

        for (int i = 0; i < numberOfG; i++)
        {
            float x = Random.Range(-020, 100);
            float y = Random.Range(-100, 100);
            Instantiate(badG, new Vector3(x, y, 0f), Quaternion.identity);

        }
        countarForTimToAccelerateg--;
        countarFornumberToAccelerateg--;
        if (countarFornumberToAccelerateg == 0)
        {
            countarFornumberToAccelerateg = defaultCountarFornumberToAccelerateg;
            numberOfSmall++;
        }
        if (countarForTimToAccelerateg == 0)
        {
            countarForTimToAccelerateg = defaultCountarForTimToAccelerateg;
            enemyCreationAccelerationg--;
            enemyCreationSpeedg--;

        }
        if (enemyCreationAccelerationg == 0)
        {
            defaultCountarForTimToAccelerateg -= 2;

        }
        StartCoroutine(BadG());
    }

    IEnumerator BadShooter()
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(secShooter);


        float x = Random.Range(-020, 100);
        float y = Random.Range(-100, 100);
        Instantiate(shooter, new Vector3(x, y, 0f), Quaternion.identity);
        secShooter = 20f;
        StartCoroutine(BadShooter());
        Debug.Log("Made one");
    }



    IEnumerator Food()
    {
        yield return new WaitForSeconds(secFood);


        float x = Random.Range(-020, 100);
        float y = Random.Range(-100, 100);
        Instantiate(food, new Vector3(x, y, 0f), Quaternion.identity);
        StartCoroutine(Food());
    }

}
