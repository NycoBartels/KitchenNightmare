using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    private Animator _anim;
    public FirstPersonController player;
    private bool isRunning = false;
    private bool isAttacking = false;


    private void Start() {
        _anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform.root.GetComponent<FirstPersonController>();
    }

    private void Update() { // Only on change of state: change animation

        if (player.attacked) {
            _anim.Play("Knife_Attack", 0, 0);
            player.attacked = false;
            isAttacking = true;
        }

        /*
        if (player.attacked) {
            _anim.Play("Knife_Attack");
            if (isAttacking == false) {
                player.attacked = false;
                isAttacking = true;
                _anim.SetBool("attack", true);
            }
        }*/
        if (isAttacking) return;

        var speed = player._speed;
        if (Mathf.Abs(speed) < .5f) {
            if (isRunning == true) {
                isRunning = false;
                _anim.Play("Knife_Idle");
            }
        }
        if (Mathf.Abs(speed) > .5f) {
            if (isRunning == false) {
                isRunning = true;
                _anim.Play("Knife_Run");
            }
        }
    }

    public void SetAttackFalse() {
        _anim.Play("Knife_Idle");
        isAttacking = false;
    }
}
