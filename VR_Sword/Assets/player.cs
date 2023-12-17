using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] int health = 7;
   
    public void TakeDamage(int damage){
   
        health -=damage;
        print(health);
        if (health <= 0){

            SceneManager.LoadScene(0);
    }
    }
    // Start is called before the first frame update
    void Start()
    {   
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
