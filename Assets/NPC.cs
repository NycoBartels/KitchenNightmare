using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    private Target target;
    private NavMeshAgent _agent;
    private CapsuleCollider _coll;
    [SerializeField] private GameObject drop;
    [SerializeField] private Transform[] poi;
    private int currentPOI = 0;

    private float elapsedTime;
    private float updateTick = 1f;

    private void Start() {
        target = GetComponent<Target>();
        _agent = GetComponent<NavMeshAgent>();
        _coll = GetComponent<CapsuleCollider>();
        
        _agent?.SetDestination(poi[Random.Range(0,poi.Length)].position);
    }


    private void Update() {
        if (_agent == null) return;
        elapsedTime += Time.deltaTime;

        if (elapsedTime > updateTick && target.isAlive) {
            elapsedTime = 0f;
            CheckDestination();
        }

    }
    private void CheckDestination() {
        if (Vector3.Distance(_agent.destination, transform.position) < 2f) {
            currentPOI = Random.Range(0, poi.Length);
            _agent.SetDestination(poi[currentPOI].position);

        }
    }

    public void Die() {
        if (target.isAlive) {
            _coll.enabled = false;
            target.isAlive = false;
            if (_agent != null) {
                _agent.isStopped = true;
            }
        } else {
            DropLoot();
        }


    }

    public void DropLoot() {
        Instantiate(drop, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

}
