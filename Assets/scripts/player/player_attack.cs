using UnityEngine;

public class player_attack : MonoBehaviour
{
    public GameObject weapon;
    public GameObject parent;
    public GameObject weapon_origin;
    // Update is called once per frame
    void Update() {
      Debug.Log(parent.transform.position);
      Debug.Log(weapon_origin.transform.position);
      Ray2D ray = new Ray2D(parent.transform.position, parent.GetComponent<player_controller>().player_to_mouse.normalized);
      Vector2 weapon_position = ray.GetPoint(1);
      weapon_origin.transform.position = weapon_position;
      if (Input.GetButtonDown("Fire1")) {
        GameObject.Instantiate(weapon, weapon_origin.transform, false);
      }
    }
}
