/*
    Script to define the Base Gadget class 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseGadget
{
    public BaseGadget(BasePlayer player_)
    {
        player = player_;
    }

    protected BasePlayer player;

    // Enter Key to activate gadget
    protected KeyCode keyBinded;


    //functions every gadget must have to reset in every level
    abstract public void ResetGadget();

    abstract public void UpdateGadget(float deltaTime);


    // functions that will work with the gadgets
    virtual public bool CanBeSeen(BaseEnemy enemy) 
    {
        return true;
    }    

    virtual public bool CanBeDamaged()
    {
        return true;
    }

    virtual public float DamageMultiplier()
    {
        return 1;
    }
}