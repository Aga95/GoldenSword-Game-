using System;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject { 

    public class Movement : MonoBehaviour
    {

        public float currentHealth, maxHealth;
        public float speed;
        public float jumpForce;
        public Rigidbody2D rb;
        public Animator anim;
        public int lvl, healthPotions, killCounter, reqKillsToLvl;
        public GameObject lvlText, hpText, deathPanel, healthPotionText;
        public Slider healthBar;
        public bool playerDirection = true;
        public Sprite w1, w2, w3, w4;
        private SpriteRenderer spriteR;
        public GameObject sword;

        private float xAxis;
        private int turn;

        public bool canMove;
              
        public string startPoint;

        // Use this for initialization
        void Start()
        {
            maxHealth = 10;
            currentHealth = 10;
            lvl = 1;
            killCounter = 0;
            reqKillsToLvl = 5;
            canMove = true;
            lvl = PlayerPrefs.GetInt("playerLvl");
            updateHealthPotions();
            lvlUp();
            startWithCorrectWeapon();
            //DontDestroyOnLoad(transform.gameObject);

        }

        // Update is called once per frame
        void Update()
        {
            healthBar.value = calculateCurrentHealth();
            hpText.GetComponent<Text>().text = currentHealth.ToString();
            float horizontal = Input.GetAxis("Horizontal");

         
            if(horizontal > 0)
            {
                anim.SetFloat("speed", 1);
                xAxis = 1;
            }

            else if (horizontal < 0)
            {
                anim.SetFloat("speed", 1);
                xAxis = -1;
            }
            else
            {
                anim.SetFloat("speed", 0);
                xAxis = 0;
            }

            // TURNING
            if (xAxis > 0)
            {
                turn = 1;   // Turns right
            }
            else if (xAxis < 0)
            {
                turn = -1; // Turns left
            }
            if (turn == -1)
            {
                gameObject.transform.localScale = new Vector3(-1.65f , transform.localScale.y, transform.localScale.z);
            }
            else if (turn == 1 && gameObject.transform.localScale.x < 1)
            {
                gameObject.transform.localScale = new Vector3(1.65f , transform.localScale.y, transform.localScale.z);
            }

            if (!canMove)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            transform.Translate(horizontal * Time.deltaTime * speed, 0f, 0f);

            if (Input.GetButtonDown("Jump") && rb.velocity.y < .01f && rb.velocity.y > -.01f)
            {
                anim.SetFloat("jump", 1);
                rb.AddRelativeForce(new Vector2(0f, jumpForce));
                Debug.Log(rb.velocity.y);
            }
            if(rb.velocity.y < 0.0f)
            {
                anim.SetFloat("jump", 0);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();            
            }
            else
            {
                anim.SetBool("attack", false);
            }

                  
        

            if (Input.GetKeyDown(KeyCode.P))
            {
                TakeDamage(1);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                killCounter++;
                Debug.Log(killCounter);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (healthPotions > 0)
                {
                    healthPotion();
                }
            }
            if (killCounter >= reqKillsToLvl)
            {
                killCounter = 0;
                lvl++;
                lvlUp();
            }
        }

        void Attack()
        {
            anim.SetBool("attack", true);
        }

        private void calculateNewReqKills()
        {
            if (lvl == 2)
            {
                reqKillsToLvl = 15;
                maxHealth = 12;
                currentHealth = maxHealth;
            }
            else if (lvl == 3)
            {
                reqKillsToLvl = 20;
                maxHealth = 14;
                currentHealth = maxHealth;
            }
            else if (lvl == 4)
            {
                reqKillsToLvl = 25;
                maxHealth = 16;
                currentHealth = maxHealth;
            }
            else if (lvl == 5)
            {
                reqKillsToLvl = 30;
                maxHealth = 18;
                currentHealth = maxHealth;
            }
            else if (lvl == 6)
            {
                reqKillsToLvl = 35;
                maxHealth = 20;
                currentHealth = maxHealth;
            }
            else if (lvl == 7)
            {
                reqKillsToLvl = 40;
                maxHealth = 22;
                currentHealth = maxHealth;
            }
            else if (lvl == 8)
            {
                reqKillsToLvl = 45;
                maxHealth = 24;
                currentHealth = maxHealth;
            }
            else if (lvl == 9)
            {
                reqKillsToLvl = 50;
                maxHealth = 26;
                currentHealth = maxHealth;
            }
            else if (lvl == 10)
            {
                reqKillsToLvl = 60;
                maxHealth = 28;
                currentHealth = maxHealth;
            }
            else if (lvl == 11)
            {
                reqKillsToLvl = 70;
                maxHealth = 30;
                currentHealth = maxHealth;
            }
            else if (lvl == 12)
            {
                reqKillsToLvl = 80;
                maxHealth = 31;
                currentHealth = maxHealth;
            }
            else if (lvl == 13)
            {
                reqKillsToLvl = 90;
                maxHealth = 32;
                currentHealth = maxHealth;
            }
            else if (lvl == 14)
            {
                reqKillsToLvl = 100;
                maxHealth = 33;
                currentHealth = maxHealth;
            }
            else if (lvl == 15)
            {
                reqKillsToLvl = 120;
                maxHealth = 34;
                currentHealth = maxHealth;
            }
            else if (lvl == 16)
            {
                reqKillsToLvl = 140;
                maxHealth = 35;
                currentHealth = maxHealth;
            }
            else if (lvl == 17)
            {
                reqKillsToLvl = 160;
                maxHealth = 36;
                currentHealth = maxHealth;
            }
            else if (lvl == 18)
            {
                reqKillsToLvl = 180;
                maxHealth = 37;
                currentHealth = maxHealth;
            }
            else if (lvl == 19)
            {
                reqKillsToLvl = 200;
                maxHealth = 38;
                currentHealth = maxHealth;
            }
            else if (lvl >= 20)
            {
                reqKillsToLvl = 9001;
                maxHealth = 40;
                currentHealth = maxHealth;
            }
            Debug.Log(reqKillsToLvl);
        }

        private float calculateCurrentHealth()
        {
            return currentHealth / maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                deathPanel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Dead");
            }
        }
        public void lvlUp()
        {
            lvlText.GetComponentInChildren<Text>().text = "LVL: " + lvl;
            PlayerPrefs.SetInt("playerLvl", lvl);
            calculateNewReqKills();
        }

        
        public void healthPotion()
        {
            int healthHealed = 5;
            if(currentHealth <= (maxHealth - healthHealed))
            {
                currentHealth += healthHealed;
                healthPotions--;
                PlayerPrefs.SetInt("healthPotions", healthPotions);
                updateHealthPotions();
            }
            else if (currentHealth < maxHealth)
            {
                currentHealth = maxHealth;
                healthPotions--;
                PlayerPrefs.SetInt("healthPotions", healthPotions);
                updateHealthPotions();
            }
        }
        public void updateHealthPotions()
        {
            healthPotions = PlayerPrefs.GetInt("healthPotions");
            healthPotionText.GetComponent<Text>().text = healthPotions + " x";
        }
        public void startWithCorrectWeapon()
        {
            Sprite swd;
            string w = PlayerPrefs.GetString("Wep");
            if (w == "W4")
            {
                swd = w4;
                sword.GetComponent<swordScript>().damage = 20;
            }
            else if (w == "W3")
            {

                swd = w3;
                sword.GetComponent<swordScript>().damage = 10;
            }
            else if (w == "W2")
            {

                swd = w2;
                sword.GetComponent<swordScript>().damage = 5;
            }
            else
            {
                swd = w1;
                sword.GetComponent<swordScript>().damage = 2;
            }
            spriteR = sword.GetComponent<SpriteRenderer>();
            spriteR.sprite = swd;

        }
    }
}