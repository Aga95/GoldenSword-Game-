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
        public int lvl, healthPotions, currentXP, xpRequired;
        public GameObject lvlText, xpText, xpMax, hpText, hpMax, deathPanel, healthPotionText;
        public Slider healthBar, xpBar;
        public bool playerDirection = true;
        public Sprite w1, w2, w3, w4;
        private SpriteRenderer spriteR;
        public GameObject sword;

        public AudioClip aAttack, aJump, aDeath, aDamage, aSpell, aHealthPotion;
        public AudioSource aSource;

        private float xAxis;
        private int turn;

        public bool canMove;
              
        public string startPoint;

        // Use this for initialization
        void Start()
        {
            maxHealth = 10;
            currentHealth = 10;
            currentXP = PlayerPrefs.GetInt("currentXP");
            xpText.GetComponent<Text>().text = currentXP.ToString();
            if (currentXP < 1)
            {
                currentXP = 0;
            }
            xpRequired = 5;
            canMove = true;
            lvl = PlayerPrefs.GetInt("playerLvl");
            if (lvl < 1)
            {
                lvl = 1;
            }
            updateHealthPotions();
            lvlUp();
            startWithCorrectWeapon();

        }

        // Update is called once per frame
        void Update()
        {
            healthBar.value = calculateCurrentHealth();
            xpBar.value = calculateCurrentXP();
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
                aSource.PlayOneShot(aJump);
                anim.SetFloat("jump", 1);
                rb.AddRelativeForce(new Vector2(0f, jumpForce));
                Debug.Log(rb.velocity.y);
            }
            if(rb.velocity.y < 0.0f)
            {
                anim.SetFloat("jump", 0);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("attack", true);
                aSource.PlayOneShot(aAttack);
            }
            else
            {
                anim.SetBool("attack", false);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetFloat("spell", 1);
                aSource.PlayOneShot(aSpell);
            }
            else
            {
                anim.SetFloat("spell", 0);
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                TakeDamage(1);
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                gainXP(5);
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                currentHealth = 9001;
            }
            {

            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (healthPotions > 0)
                {
                    healthPotion();
                    aSource.PlayOneShot(aHealthPotion);
                }
            }
            if (currentXP >= xpRequired)
            {
                currentXP = 0;
                lvl++;
                lvlUp();
            }
        }

        private void calculateNewReqKills()
        {
            if (lvl == 2)
            {
                xpRequired = 15;
                maxHealth = 12;
                currentHealth = maxHealth;
            }
            else if (lvl == 3)
            {
                xpRequired = 20;
                maxHealth = 14;
                currentHealth = maxHealth;
            }
            else if (lvl == 4)
            {
                xpRequired = 25;
                maxHealth = 16;
                currentHealth = maxHealth;
            }
            else if (lvl == 5)
            {
                xpRequired = 30;
                maxHealth = 18;
                currentHealth = maxHealth;
            }
            else if (lvl == 6)
            {
                xpRequired = 35;
                maxHealth = 20;
                currentHealth = maxHealth;
            }
            else if (lvl == 7)
            {
                xpRequired = 40;
                maxHealth = 22;
                currentHealth = maxHealth;
            }
            else if (lvl == 8)
            {
                xpRequired = 45;
                maxHealth = 24;
                currentHealth = maxHealth;
            }
            else if (lvl == 9)
            {
                xpRequired = 50;
                maxHealth = 26;
                currentHealth = maxHealth;
            }
            else if (lvl == 10)
            {
                xpRequired = 60;
                maxHealth = 28;
                currentHealth = maxHealth;
            }
            else if (lvl == 11)
            {
                xpRequired = 70;
                maxHealth = 30;
                currentHealth = maxHealth;
            }
            else if (lvl == 12)
            {
                xpRequired = 80;
                maxHealth = 31;
                currentHealth = maxHealth;
            }
            else if (lvl == 13)
            {
                xpRequired = 90;
                maxHealth = 32;
                currentHealth = maxHealth;
            }
            else if (lvl == 14)
            {
                xpRequired = 100;
                maxHealth = 33;
                currentHealth = maxHealth;
            }
            else if (lvl == 15)
            {
                xpRequired = 120;
                maxHealth = 34;
                currentHealth = maxHealth;
            }
            else if (lvl == 16)
            {
                xpRequired = 140;
                maxHealth = 35;
                currentHealth = maxHealth;
            }
            else if (lvl == 17)
            {
                xpRequired = 160;
                maxHealth = 36;
                currentHealth = maxHealth;
            }
            else if (lvl == 18)
            {
                xpRequired = 180;
                maxHealth = 37;
                currentHealth = maxHealth;
            }
            else if (lvl == 19)
            {
                xpRequired = 200;
                maxHealth = 38;
                currentHealth = maxHealth;
            }
            else if (lvl >= 20)
            {
                xpRequired = 9001;
                maxHealth = 40;
                currentHealth = maxHealth;
            }
            xpText.GetComponent<Text>().text = currentXP.ToString();
            xpMax.GetComponent<Text>().text = xpRequired.ToString();
        }
        private float calculateCurrentHealth()
        {
            hpMax.GetComponent<Text>().text = maxHealth.ToString();
            return currentHealth / maxHealth;
        }
        private float calculateCurrentXP()
        {
            return (float.Parse(currentXP.ToString()) / (float.Parse(xpRequired.ToString())));
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            aSource.PlayOneShot(aDamage);
            if (currentHealth <= 0)
            {
                aSource.PlayOneShot(aDeath);
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
            float healthHealed = maxHealth * 0.5f;
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
        public void gainXP(int xp)
        {
            currentXP += xp;
            xpText.GetComponent<Text>().text = currentXP.ToString();
            Debug.Log(currentXP + "/" + xpRequired);
            PlayerPrefs.SetInt("currentXP", currentXP);
        }
    }
}