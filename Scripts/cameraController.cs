using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    private float y;
    private float x;
    Camera cam;
    private float orto;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }


    void Update()
    {
        if(player != null)
        {
            y = player.position.y;
            x = player.position.x;

            transform.position = new Vector3(x, y, -10);
            cam.orthographicSize = (player.localScale.x * 0.1f + 10f) + orto;
        }
        else
        {
            transform.position = new Vector3(0, 0, -10);
        }
        
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (cam.orthographicSize > 10)
                orto--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            
            if (cam.orthographicSize < 100)
                orto++;
        }
    }

    public void FindPlayer()
    {
        player = GameObject.Find("Player").transform;
    }
}
