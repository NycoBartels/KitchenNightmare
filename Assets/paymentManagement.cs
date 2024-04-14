using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (other.gameObject.tag == "food")
        {
            dish = other.gameObject;
        }
        if (other.gameObject.tag == "order")
        {
            order = other.gameObject;
        }
        

        if (order != null && dish != null) {
            ordercheck();
        }

    }

    void OnTriggerExit(Collider other)
    {
        //check if dish or order is removed
        if (other.CompareTag("food")) {
            if (dish.gameObject == other.gameObject) {
                dish = null;
            }
        }
        if (other.CompareTag("order")) {
            if (order.gameObject == other.gameObject) {
                order = null;
            }
        }
    }

    private void ordercheck()
    {
        //if we have both a dish and an order, check if they are the right ones
        if (dish.name == order.name && dish != null)
        {
            Destroy(dish.gameObject);
            Destroy(order.gameObject);
            dish = null;
            order = null;
            //goldenpipe go, spout money.

            StartCoroutine(SpawnMoney());


            //if they arent the right ones, error feedback!
            //EERRROORRR
            return;
        } else {
            print("WRONG ");
        }
    }

    private IEnumerator SpawnMoney() {
        for (var i = 0;i < 50;i++) {
            Spawn();
            yield return new WaitForSeconds(.05f);
        }
    }

    private void Spawn()
    {
        Instantiate(reward, goldenpipe.transform.position, Quaternion.identity);
    }
}
