/*
    Script for defining the ghostwalker's phantom step gadget

    phantom step allows the player to dash when they are invisible
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomStep : BaseGadget
{
    public PhantomStep(BasePlayer player_) : base(player_)
    {
        keyBinded = KeyCode.LeftShift;
        
        dashCooldown = 1f;
        dashDuration = 0.1f;
        dashSpeed = 30f;
        cooldownTimer = dashCooldown;
        regularSpeed = player.maxSpeed;
        dashing = false;
    }

    private float dashCooldown; // how much time the player has to wait between dashes
    private float dashDuration; // how long the dash lasts
    private float dashSpeed; // how fast does the player go when dashing
    private float regularSpeed; // player's usual speed
    private float cooldownTimer; // time elapsed since dashing
    private bool dashing;

    public override void ResetGadget()
    {
        
    }

    public override void UpdateGadget(float deltaTime)
    {
        // if cooldown is over and player is moving
        if (!dashing && cooldownTimer >= dashCooldown && player.currentSpeed != 0 && !player.isVisible)
        {
            if (Input.GetKey(keyBinded))
            {
                cooldownTimer = 0f;
                player.maxSpeed = dashSpeed;
                player.currentSpeed = dashSpeed;
                dashing = true;
            }
        } 
        else 
        {
            cooldownTimer += deltaTime;

            if (dashing && cooldownTimer > dashDuration)
            {
                dashing = false;
                player.maxSpeed = regularSpeed;
                player.currentSpeed = regularSpeed;
            }
        }
    }
}
