using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> orders;
    private int random;
    [SerializeField] Animator animator;
    private GameObject itsme;
    [SerializeField] private GameObject spawnpoint;


    private void Start()
    {
        //Heeeheheheheee
        InvokeRepeating("Spawn", 0, 1f);
    }
    private void Spawn()
    {
        //generate a random number for spawny
        random = UnityEngine.Random.Range(0, orders.Count);
        itsme = orders[random];
        //spawn item
        Debug.Log("sup");
        Instantiate(itsme, spawnpoint.transform);

    }
}
