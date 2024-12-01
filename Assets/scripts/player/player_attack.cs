using UnityEngine;

public class player_attack : MonoBehaviour
{
    // Declarations
    public GameObject weapon;
    public GameObject parent;
    public GameObject weapon_origin;
    Vector2 player_to_mouse;

    // Update is called once per frame
    void Update() {
        // Definitions
        player_to_mouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - parent.transform.position);
        Ray2D ray = new Ray2D(parent.transform.position, player_to_mouse.normalized);
        Vector2 weapon_position = ray.GetPoint(1);
        weapon_origin.transform.position = weapon_position;

        // Logic
        if (Input.GetButtonDown("Fire1")) {
          GameObject.Instantiate(weapon, weapon_origin.transform, false);
        }
    }
}
