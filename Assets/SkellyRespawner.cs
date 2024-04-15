using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkellyRespawner : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Vector3 kitchenPos;
    [SerializeField] private float kitchenDis = 20f;

    [SerializeField] private GameObject walkingSkelly;
    [SerializeField] private Transform[] pois;

    private int skellyCounter = 0;
    private int respawnLimit = 4;

    private bool playerInKitchen = false;
    private float elapsedTime;
    private float updateTick = 1f;

    public static event Action SkellyDied;
    public static void ReportSkellyDied() {
        SkellyDied?.Invoke();
    }

    private void Start() {
        SkellyDied += CountSkelly;
    }
    private void CountSkelly() {
        skellyCounter++;
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < updateTick) return; // Only update every 1s

        if (!playerInKitchen) {
            if (Vector3.Distance(kitchenPos, player.transform.position) < kitchenDis) {
                playerInKitchen = true;
                RespawnSkellies();
            }
        }
        if (playerInKitchen) {
            if (Vector3.Distance(kitchenPos, player.transform.position) > kitchenDis * 1.5f) {
                playerInKitchen = false;
            }
        }
        elapsedTime = 0f;
    }

    private void RespawnSkellies() {
        while (skellyCounter >= respawnLimit) {
            for (int i = 0; i < 4; i++) { // NEEDS 4 spawn points
                var newSkelly = Instantiate(walkingSkelly, spawnPositions[i].position, Quaternion.identity);
                newSkelly.GetComponent<NPC>().poi = pois;
                print("Spawned new skelly");
            }
            skellyCounter -= respawnLimit;
        }
    }

    private void OnDestroy() {
        SkellyDied -= CountSkelly;
    }
}
