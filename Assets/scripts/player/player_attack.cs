using UnityEngine;

public class player_attack : MonoBehaviour
{
    public GameObject weapon;
    public GameObject parent;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameObject.Instantiate(weapon, parent.transform, false);
        }
    }
}
