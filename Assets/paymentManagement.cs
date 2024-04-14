using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paymentManagement : MonoBehaviour
{
    [SerializeField] private GameObject order;
    [SerializeField] private GameObject dish;
    private int random;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject goldenpipe;
    [SerializeField] private GameObject reward;


    void OnTriggerEnter(Collider other)
    {
        //check dish &or order
        if (other.gameObject.tag == "dish")
        {
            dish = other.gameObject;
        }
        if (other.gameObject.tag == "order")
        {
            order = other.gameObject;
        }
        else
        {
            //EERRRROOOOORRRR
        }

    }

    void OnTriggerExit(Collider other)
    {
        //check if dish or order is removed
    }

    private void ordercheck()
    {
        //if we have both a dish and an order, check if they are the right ones
        if (dish.name == order.name)
        {

            //if they are the right ones, remove them and send a spawner command with the right money
            if (true)
            {
                //goldenpipe go, spout money.
                for (var i = 0; i < 50; i++)
                {
                    InvokeRepeating("Spawn", 0, i/5);

                }
                
            }
            //if they arent the right ones, error feedback!
            //EERRROORRR
            return;
        }

    }

    private void Spawn()
    {
        Instantiate(reward, goldenpipe.transform.position, Quaternion.identity);
    }
}
