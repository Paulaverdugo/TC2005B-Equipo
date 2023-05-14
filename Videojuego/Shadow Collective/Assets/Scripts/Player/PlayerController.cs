/*
    This script unifies all player classes in a script, so that other gameobjects or scripts that need
    to interact with the player can do so without knowing it's class
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public BasePlayer playerScript;
    [SerializeField] public Animator animator;

    void Start()
    {
        // make the sprite used to see the gameobject invisible, since we have animations
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        ChooseCybergladiator();
        // ChooseCodebreaker();
        // ChooseGhostwalker();
    }

    public bool CheckVisibility(GameObject obj)
    {
        return playerScript.CheckVisibility(obj);
    }

    public void GetDamaged(float damage) 
    {
        playerScript.GetDamaged(damage);
    }

    // functions to choose a class 
    public void ChooseCodebreaker()
    {
        gameObject.GetComponent<Cybergladiator>().enabled = false;
        gameObject.GetComponent<Ghostwalker>().enabled = false;

        BasePlayer codebreakerScript = gameObject.GetComponent<Codebreaker>();
        codebreakerScript.enabled = true;
        codebreakerScript.animator = animator;
        playerScript = codebreakerScript;
    }

    public void ChooseCybergladiator()
    {
        gameObject.GetComponent<Codebreaker>().enabled = false;
        gameObject.GetComponent<Ghostwalker>().enabled = false;

        BasePlayer cybergladiatorScript = gameObject.GetComponent<Cybergladiator>();
        cybergladiatorScript.enabled = true;
        cybergladiatorScript.animator = animator;
        playerScript = cybergladiatorScript;
    }

    public void ChooseGhostwalker()
    {
        gameObject.GetComponent<Codebreaker>().enabled = false;
        gameObject.GetComponent<Cybergladiator>().enabled = false;

        BasePlayer ghostwalkerScript = gameObject.GetComponent<Ghostwalker>();
        ghostwalkerScript.enabled = true;
        ghostwalkerScript.animator = animator;
        playerScript = ghostwalkerScript;
    }

    
}
