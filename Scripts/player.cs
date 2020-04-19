using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public GameObject bullet;
    public GameObject hitEffect;
    public Transform shootOrigin;
    public SpriteRenderer rend;
    public float mass = 10f;
    public Camera cam;
    public GameManager gameManager;

    Vector2 mousePosition;
    Vector2 mouvement;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main.GetComponent<Camera>(); //GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }

    private void Update()
    {
        mousePosition =  cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetButtonDown("Fire1") && mass > 6f)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            mass -= 2f;
            Shoot();
        }

        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        transform.localScale = new Vector3(mass, mass, mass);

        if(mass<= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.deltaTime);

        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject fofo =  Instantiate(bullet, shootOrigin.position, shootOrigin.rotation);
        Destroy(fofo, 6f);
    }

    public void TakeMass(float _mass)
    {
        mass += _mass;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Bad"))
        {
            rend.color = Color.red;
            StartCoroutine(Damage());
            TakeDamage(4f);
            if(collider.GetComponent<Bad2>() != null)
            {
                collider.GetComponent<Bad2>().TakeDamage(2f);
            }
            else if(collider.GetComponent<BadShooter>() != null)
            {
                collider.GetComponent<BadShooter>().TakeDamage(2f);
            }
            
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.5f);
        rend.color = Color.green;
    }

    public void TakeDamage(float _damage)
    {
        mass -= _damage;
    }

    public void Die()
    {
        if(gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        gameManager.PlayerDead();
        Destroy(gameObject);
    }

}
