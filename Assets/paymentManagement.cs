using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class paymentManagement : MonoBehaviour
{
    [SerializeField] private GameObject order;
    [SerializeField] private GameObject dish;
    private int random;
    [SerializeField] private TextMeshPro label;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject goldenpipe;
    [SerializeField] private GameObject reward;
    [SerializeField] private float coinForce = 1000;

    private float elapsedTime;

    private void Start() {
        label.text = "place new order";
    }

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
            label.text = "order:\n" + order.GetComponent<MeshRenderer>().material.name.Replace("(Instance)",""); ;
        }
        

        if (order != null && dish != null) {
            ordercheck();
        }

    }

    // DEBUG for spawning lotsa money
    /*
    private void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= .3f) {
            Spawn();
        }
    }
    */
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
            label.text = "place new order";
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
        var newCoin = Instantiate(reward, goldenpipe.transform.position + Vector3.up, Quaternion.identity);
        newCoin.GetComponent<Rigidbody>().AddForce(coinForce * Vector3.down + Vector3.forward * UnityEngine.Random.Range(-10, 10) / 10f + Vector3.right * UnityEngine.Random.Range(-10, 10) / 10f);
        MoneyCounter.MoneyAdded();
    }
}
