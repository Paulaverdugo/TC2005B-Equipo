/*
    Script to define an abstract class that will be used by enemy classes

    Using abstract classes normalizes behavior so that all enemies have certain attributes or methods
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseEnemy : MonoBehaviour
{
    [SerializeField] GameObject player; 
    
    // radius that defines the max distance to alert another enemy when the player is seen
    [SerializeField] float alertingRadius = 10f; 

    [SerializeField] float alertedTimeLimit = 10f; 
    [SerializeField] float hackedTimeLimit = 5f; 

    [SerializeField] ContactFilter2D enemyFilter = new ContactFilter2D();
    
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float sightDistance = 3f;


    // attributes related to the state of the enemy being alerted of the enemies position
    private bool isAlerted = false;
    private float alertedTime = 0f;

    // attributes related to the state of the enemy being hacked 
    private bool isHacked = false;
    private float hackedTime = 0f;


    virtual protected void Start() 
    {

    }

    virtual protected void Update() 
    {
        if (isAlerted) 
        {
            alertedTime += Time.deltaTime;

            if (alertedTime > alertedTimeLimit) isAlerted = false;            
        }

        if (isHacked) 
        {
            hackedTime += Time.deltaTime;

            if (hackedTime > hackedTimeLimit) isHacked = false;
        }
    }

    /* 
        function that checks if the gameobject that entered the vision cone is the player
        if it is, then it asks through the playercontroller if it can be seen 
        if it can be seen, we alert ourselves, aswell as other enemies within the radius

        consider adding the same procedure but for OnTriggerStay2D to avoid any potential bugs,
        but this might be performance heavy. 
    */ 
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (GameObject.ReferenceEquals(player, collision.gameObject)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, sightDistance, playerLayer);
            
            if (hit.collider != null)
            {
                print("I can see the player!");
                // if (player.GetComponent<PlayerController>().playerScript.CanBeSeen(gameObject)) 
                // {
                //     AlertOthers();
                // } TO DO -> uncomment when PlayerController exists
            }
        }
    }

    // function to be alerted that the player has been seen
    public void Alert() 
    {
        isAlerted = true;
        alertedTime = 0f;
    }

    public void AlertOthers() 
    {
        // overlap circle returns a list of colliders within a radius
        List<Collider2D> colsInRadius = new List<Collider2D>();

        int results = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), alertingRadius, enemyFilter, colsInRadius);

        foreach (var col in colsInRadius)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.gameObject.GetComponent<EnemyController>().enemyScript.Alert();
            }
        }
    }

    // function to be hacked by the player or by a gadget
    public void Hack()
    {
        isHacked = true;
        hackedTime = 0f;
    }
}
