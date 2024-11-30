using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Rendering;

public class player_controller : MonoBehaviour
{
    Vector2 wish_dir;
    public float speed;
    public float roll_speed;
    public Rigidbody2D rb;
    public Camera cam;
    public Vector2 player_to_mouse;
    bool is_rolling;
    float cur_speed;
    float roll_start_time;
    public float roll_duration;
    public float roll_cooldown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        handleRoll();
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        rb.linearVelocity = wish_dir.normalized * cur_speed;
    }

    void getInput()
    {
        if (is_rolling != true)
        {
            wish_dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        player_to_mouse = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(roll_start_time + roll_cooldown < Time.time && wish_dir != Vector2.zero){
                beginRoll();
            }
        }
    }

    void beginRoll()
    {
        roll_start_time = Time.time;

        is_rolling = true;
        Debug.Log("roll");
    }
    void handleRoll()
    {
        if (is_rolling == true)
        {
            cur_speed = roll_speed;

        }
        else
        {
            cur_speed = speed;
        }

        if(roll_start_time + roll_duration < Time.time)
        {
            is_rolling = false;
        }

    }
}
