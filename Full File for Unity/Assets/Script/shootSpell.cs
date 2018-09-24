using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootSpell : MonoBehaviour {

    public GameObject projectile;
    private Vector2 velocity = new Vector2(10, 0);
    public Vector2 offset = new Vector2(1f, 0.5f);
    public Vector2 offset2 = new Vector2(1f, -0.5f);
    private float cooldown = 5.0f;
    public float cooldownTimer;
    public GameObject displayTimer;
    public Animator anim;

    private int turn;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            displayTimer.GetComponent<Text>().text = System.Math.Round(cooldownTimer,2).ToString();
        }
        if (cooldownTimer < 0)
        {
            cooldownTimer = 0;
            displayTimer.GetComponent<Text>().text = "RDY";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            turn = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            turn = 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && cooldownTimer == 0)
        {
            if (turn == 1)
            {
                GameObject go = Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.Euler(180f, 0f, 180f));
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
                Debug.Log("x: " + projectile.transform.position.x + " y:" + projectile.transform.position.y);
            }
            if(turn == -1)
            {
                GameObject go = Instantiate(projectile, (Vector2)transform.position + offset2 * transform.localScale.x, Quaternion.Euler(0f, 0f, 0f));
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
                Debug.Log("x: " + projectile.transform.position.x + " y:" + projectile.transform.position.y);
            }

            cooldownTimer = cooldown;
        }

	}
}
