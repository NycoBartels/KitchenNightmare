using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    private Animator _anim;
    public FirstPersonController player;
    private bool isRunning = false;

    private void Start() {
        _anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform.root.GetComponent<FirstPersonController>();
    }

    private void Update() { // Only on change of state: change animation
        var speed = player._speed;
        if (Mathf.Abs(speed) < .5f) {
            if (isRunning == true) {
                print("TOO FAST");
                isRunning = false;
                _anim.SetBool("isRunning", false);
            }
        }
        if (Mathf.Abs(speed) > .5f) {
            if (isRunning == false) {
                print("TOO SLOW");
                isRunning = true;
                _anim.SetBool("isRunning", true);
            }
        }
    }


}
