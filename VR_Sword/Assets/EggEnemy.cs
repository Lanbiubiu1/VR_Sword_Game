using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EggEnemy : MonoBehaviour
{
    [SerializeField] int health = 3;

    [SerializeField] int attackCD = 3;
    [SerializeField] int attackrange = 2;
    [SerializeField] int aggrorange = 4;

    GameObject player;
    Animator animator;

    NavMeshAgent agent;

    float timepass;
    float newDisCD = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update(){
        animator.SetFloat("Movespeed", agent.velocity.magnitude/agent.speed);

        if(timepass >= attackCD){
            if (Vector3.Distance(player.transform.position, transform.position) <= attackrange){
                animator.SetTrigger("attack");
                timepass = 0;

            }
        }
        timepass += Time.deltaTime;

        if (newDisCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggrorange){
            newDisCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDisCD -= Time.deltaTime;
        
    }

    public void TakeDamage(int damage){
   
        health -=damage;
        
        animator.SetTrigger("damage");
        
        if (health <= 0){

            animator.SetTrigger("Dealth");
            
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
       
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }


    

    // Update is called once per frame
    
}
