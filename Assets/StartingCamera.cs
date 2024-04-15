using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingCamera : MonoBehaviour
{

    public Image ui;
    private FirstPersonController player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        ui.enabled = false;
    }

    public void DestroySelf() {
        player.isFree = true;
        ui.enabled = true;
        Destroy(this.gameObject);
    }
}
