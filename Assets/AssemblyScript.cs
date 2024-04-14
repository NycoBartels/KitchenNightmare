using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyScript : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;

    [SerializeField] private List<GameObject> orders;
    private int random;
    private GameObject itsme;
    Animator animator;



    private void Start()
    {
        //Heeeheheheheee
        InvokeRepeating("Spawn", 0, 15f);
    }
    private void Spawn()
    {
        //generate a random number for spawny
        random = UnityEngine.Random.Range(0, orders.Count);
        itsme = orders[random];
        //spawn item
        Debug.Log("sup");
        var newSpawn = Instantiate(itsme, spawnpoint.position, Quaternion.identity);
        newSpawn.name = itsme.name;
    }
}

