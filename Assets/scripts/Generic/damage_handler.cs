using UnityEngine;

public class damage_handler : MonoBehaviour
{
    public int health;
    public int max_health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void takeDamage(int damage) {
    	
    }
}
