using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Interaction : MonoBehaviour {

    public GameObject _cam;
    public Transform interactRoot;
    public LayerMask layermask = 3;
    public float pushForce = 50;
    public float hitForce = 2000;
    private Rigidbody holdingObj;
    public Transform handRoot;
    [SerializeField] private float playerInteractDistance = 3f;
    private bool isActive = false;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private ParticleSystem hitVFX;

    private AudioSource _audio;
    private AudioClip knifeSFX;

    public Transform grabObj;
    private float previousDrag;
    private float previousMass;
    [SerializeField] private float holdingMassModifier = 100;

    private void Awake() {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _audio = GetComponent<AudioSource>();
    }

    private void Update() {
        if (holdingObj != null) {
            DragObject();
        }
    }

    public void StartInteraction() {
        if (holdingObj != null) {
            DropObject();
            return;
        }
        Interact();
    }
    private void DragObject() {
        holdingObj.transform.position = handRoot.position;
    }
    private void DropObject() {
        holdingObj.mass = previousMass;
        holdingObj.drag = previousDrag;
        holdingObj.AddForce(_cam.transform.forward * pushForce);
        holdingObj = null;
    }
    private void Interact() {

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, playerInteractDistance, ~layermask)) {
            // Check for Target script and invoke unity event. used to KILL rn
            if (hit.transform.TryGetComponent<Target>(out Target target)) {

                target.interact.Invoke();
                return;
            }

            // Pick up body
            if (hit.transform.GetComponent<Rigidbody>() != null && hit.collider.gameObject.isStatic == false) {
                print("Hit smth");
                holdingObj = hit.transform.GetComponent<Rigidbody>();
                previousMass = holdingObj.mass;
                previousDrag = holdingObj.drag;
                holdingObj.mass = holdingMassModifier;
                holdingObj.drag = holdingMassModifier;
            }
        }
        else print("didnt hit");
    }

    public void Shank() {
        if (holdingObj != null) {
            DropObject();
        }
        _audio.Play();
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, playerInteractDistance, ~layermask)) {
            if (hit.transform.root.TryGetComponent<Target>(out Target target)) {
                Instantiate(hitVFX, hit.point, Quaternion.identity);
                if (target.isAlive) {
                    print("HIT ");
                    target.getGutted.Invoke();
                } else {
                    target.getGutted.Invoke();
                    Instantiate(deathVFX, hit.point, Quaternion.identity);
                }
            } else {
                if (hit.collider.gameObject.CompareTag("food")) {
                    Instantiate(hitVFX, hit.point, Quaternion.identity);
                    hit.rigidbody.AddForce(_cam.transform.forward * hitForce);
                }
            }
        }
    }
}
