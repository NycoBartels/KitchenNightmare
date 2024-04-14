using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
    public UnityEvent ApplyUpgrade;
    private GameObject player;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player = other.gameObject;
            ApplyUpgrade.Invoke();

            Destroy(this.gameObject);
        }
    }


    public void UpgradeForce() {
        player.GetComponent<Interaction>().hitForce *= 2;
        player.GetComponent<Interaction>().pushForce *= 2;
    }
    public void UpgradeSpeed() {
        player.GetComponent<FirstPersonController>().MoveSpeed *= 1.5f;
        player.GetComponent<FirstPersonController>().SprintSpeed *= 2;
    }
}
