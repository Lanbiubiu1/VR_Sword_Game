using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    
    

    public int basedamage = 1; 
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Enemy")){
            EggEnemy enemy = other.GetComponent<EggEnemy>();
            if (enemy != null){
                int damage = total_damage();
                enemy.TakeDamage(damage);
            }
        }

        if (other.CompareTag("Player")) {
            player player = other.GetComponent<player>();
            if (player != null){
                int damage = basedamage;
                player.TakeDamage(damage);
            }

        }
       
    }

    private int total_damage(){
        float averagescale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3.0f;
        return Mathf.RoundToInt(basedamage * averagescale);
    }

    // Update is called once per frame
   
}
