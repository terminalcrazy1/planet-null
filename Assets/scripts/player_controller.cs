using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    Vector2 wishDir;
    public float speed;
    public float roll_speed;
    public Rigidbody2D rb;
    public Camera cam;
    Collider2D attack_hit_box;
    Vector2 player_to_mouse;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        Debug.DrawRay(transform.position, player_to_mouse.normalized);
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        rb.linearVelocity = wishDir.normalized * speed;
    }

    void getInput()
    {
        wishDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player_to_mouse = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            roll();
        }
    }

    void roll()
    {
        transform.Translate(player_to_mouse * roll_speed);
        Debug.Log("roll");
    }
    void attack()
    {

    }
}
