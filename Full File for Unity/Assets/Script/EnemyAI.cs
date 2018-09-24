using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{

    public class EnemyAI : MonoBehaviour {

        public float health;

        public string enemyQuestName;
        private QuestManager theQM;

        public Transform[] patrolPoints;
        public int xpValue;
        public float speed;
        Transform currentPatrolPoint;
        int currentPatrolIndex;

        public Transform target;
        public float chaseRange;
        public bool patroling;
        private float distanceToTarget;

        public float attackRange;
        public float damage;
        private float lastAttackTime;
        public float attackDelay;

        public GameObject projectile;
        public float arrowForce;

        public AudioClip onHit;
        public AudioSource aSource;

	    void Start ()
        {            
            
            if (patrolPoints.Length > 0){
                currentPatrolIndex = 0;
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
            }
	    }
	
	
	    void Update () {
            
            if(patrolPoints.Length > 0)
            {
                //Check to see if we have reached the patrol point
                if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 2f)
                {
                    //We have reached the patrol point - get the next one
                    //Check to see uf we have anymore patrol points - if not go back to the beginning
                    if (currentPatrolIndex + 1 < patrolPoints.Length)
                    {
                        currentPatrolIndex++;
                    }
                    else
                    {
                        currentPatrolIndex = 0;
                    }
                    currentPatrolPoint = patrolPoints[currentPatrolIndex];
                }

                if (patroling)
                {
                    // Turn to face the current patrol point
                    //Finding the direction Vector that points to the patrolpoint
                    Vector3 patrolPointDirection = currentPatrolPoint.position - transform.position;
                    Vector3 newScale;
                    //Get the distance to the raget and check to see if its is close enough to chase
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    // Figure out if the patrol point is left or right of the enemy
                    if (patrolPointDirection.x < 0f)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * speed);
                        newScale = new Vector3(1, 1, 1);
                        transform.localScale = newScale;
                    }
                    if (patrolPointDirection.x > 0f)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
                        newScale = new Vector3(-1, 1, 1);
                        transform.localScale = newScale;
                    }
                    if (distanceToTarget < chaseRange)
                    {
                        patroling = false;
                    }
                }
                else
                {
                    //Chasing Player AI
                    //Get the distance to the raget and check to see if its is close enough to chase
                    distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (distanceToTarget < chaseRange)
                    {

                        //Start chasing the target - turn and move towards the target
                        Vector3 targetDir = target.position - transform.position;
                        Vector3 newScale;
                        if (targetDir.x < 0f)
                        {
                            transform.Translate(Vector3.left * Time.deltaTime * speed);
                            newScale = new Vector3(1, 1, 1);
                            transform.localScale = newScale;
                        }
                        if (targetDir.x > 0f)
                        {
                            transform.Translate(Vector3.right * Time.deltaTime * speed);
                            newScale = new Vector3(-1, 1, 1);
                            transform.localScale = newScale;
                        }

                    }
                    else
                    {
                        patroling = true;
                    }
                }

                //Attacking AI - Melee

                //Check the distance between enemy and player to see if the player is close enough to attack
                float distanceToPlayer = Vector3.Distance(transform.position, target.position);
                if (distanceToPlayer < attackRange)
                {
                    //Check to see if enough time has passed since we last attacked
                    if (Time.time > lastAttackTime + attackDelay)
                    {
                        target.SendMessage("TakeDamage", damage);
                        //Record the time we attacked
                        lastAttackTime = Time.time;
                    }
                }

            }
            else
            {
                Debug.Log("No patrol points");
            }
            

            
                
        

             
        
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("sword"))
            {
                other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
            if (other.CompareTag("spell"))
            {
                other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            aSource.PlayOneShot(onHit);
            if (health <= 0)
            {
                //theQM.enemyKilled = enemyQuestName;
                Debug.Log("Dead");
                gainxp();
                Destroy(gameObject);
            }
        }
        private void gainxp()
        {
           GameObject player = GameObject.Find("Player");
           player.GetComponent<Movement>().gainXP(xpValue);
        }
    }
}