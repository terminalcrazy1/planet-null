using UnityEngine;

public class player_attack : MonoBehaviour
{
    public GameObject weapon;
    public GameObject parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject.Instantiate(weapon, parent.transform, false);
        }
    }
}
