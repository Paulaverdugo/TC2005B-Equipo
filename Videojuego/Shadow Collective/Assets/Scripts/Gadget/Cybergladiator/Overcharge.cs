/*
    Class for the cybergladiator gadget overcharge

    Overcharge makes it so you deal double damage for some specified duration
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcharge : BaseGadget
{
    // TO DO -> CONSIDER ALSO SHORTENING THE PLAYER'S FIRE RATE
    public Overcharge(BasePlayer player_) : base(player_)
    {
        keyBinded = KeyCode.E;

        damageMultiplier = 2f;
        overchargeCooldown = 15f;
        overchargeDuration = 5f;
        cooldownTimer = overchargeCooldown;
        isActive = false; 
    }

    private float damageMultiplier;
    private float overchargeCooldown;
    private float overchargeDuration;
    private float cooldownTimer;
    private bool isActive;

    override public void ResetGadget()
    {
        
    }

    override public void UpdateGadget(float deltaTime)
    {
        if (!isActive && cooldownTimer >= overchargeCooldown)
        {
            if (Input.GetKey(keyBinded))
            {
                isActive = true;
                cooldownTimer = 0f;
            }
        } else
        {
            cooldownTimer += deltaTime;

            if (isActive && cooldownTimer >= overchargeDuration)
            {
                isActive = false;
            }
        }
    }

    override public float DamageMultiplier()
    {
        return (isActive) ? damageMultiplier : 1f;
    } 
}
