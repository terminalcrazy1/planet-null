// This script is meant to be attached to the Player. It handles the attack
// functionality of the players weapon.


using UnityEngine;

public class player_attack : MonoBehaviour
{
    // Declarations
    public GameObject weapon;
    public GameObject parent;
    public GameObject weapon_orig;
	public Vector3 par_pos;
	public Vector3 mos_pos;
	bool cooldown_active;
	bool weapon_timer_active;
	public int cooldown_timer_value;
	public int weapon_timer_value;
    Vector2 mouse_wp;
	GameObject inst;

	// Start is called before the first frame update
	void Start() {
		cooldown_active = false;
	}

    // Update is called once per frame
    void Update() {
		isAttacking();
    }

	// FixedUpdate is called at a fixed rate, useful for physics calculations.
	void FixedUpdate() {
		if (weapon_timer_value == 100) {
			GameObject.Destroy(inst);
			weapon_timer_active = false;
			weapon_timer_value = 0;
		} else if (weapon_timer_active == true) {
			weapon_timer_value += 1;
		}
		if (cooldown_timer_value == 200) {
			cooldown_active = false;
			cooldown_timer_value = 0;
		} else if (cooldown_active == true) {
			cooldown_timer_value += 1;
		}
	}

	void isAttacking() {
		// Definitions
		par_pos = parent.transform.position;
		mos_pos = Input.mousePosition;
		mouse_wp = (Camera.main.ScreenToWorldPoint(mos_pos) - par_pos);

		// Declarations and Definitions
		Ray2D ray = new Ray2D(parent.transform.position, mouse_wp.normalized);
		Vector2 weapon_position = ray.GetPoint(1);

		// Logic
		weapon_orig.transform.position = weapon_position;
		if (Input.GetButtonDown("Fire1") && cooldown_active != true) {
			inst = GameObject.Instantiate(weapon, weapon_orig.transform, false);
			cooldown_active = true;
			weapon_timer_active = true;
		}
	}
}
