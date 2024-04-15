using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    private Target target;
    private NavMeshAgent _agent;
    private CapsuleCollider _coll;
    private AudioSource _audio;
    private Animator anim;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private GameObject[] drop;
    [SerializeField] private Transform[] poi;
    private int currentPOI = 0;

    private float elapsedTime;
    private float updateTick = 1f;


    [SerializeField] private GameObject audioObj;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip[] oof;



    private void Start() {
        target = GetComponent<Target>();
        _agent = GetComponent<NavMeshAgent>();
        _coll = GetComponent<CapsuleCollider>();
        _audio = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();

        if (_agent != null) {
            _agent?.SetDestination(poi[Random.Range(0,poi.Length)].position);
            anim.Play("Female Tough Walk");
        }
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
            var newAudio = Instantiate(audioObj, transform.position, Quaternion.identity);
            newAudio.GetComponent<AudioObject>().PlayRandomAudio(oof);
            _coll.enabled = false;
            target.isAlive = false;
            _audio.PlayOneShot(deathSFX);
            if (_agent != null) {
                _agent.isStopped = true;
            }
        } 
    }

    public void DropLoot() {
        if (target.isAlive == false) {  
            for (int i = 0; i < drop.Length; i++) {
                var newDrop = Instantiate(drop[i], transform.position, Quaternion.identity);
                newDrop.name = drop[i].name;
            }
            var newAudio = Instantiate(audioObj, transform.position, Quaternion.identity);
            newAudio.GetComponent<AudioObject>().PlayAudio(deathSFX);
            gameObject.SetActive(false);
        }

    }

}
