using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Interaction : MonoBehaviour {

    public GameObject _cam;
    public Transform interactRoot;
    public LayerMask layermask = 3;
    private Rigidbody holdingObj;
    public Transform handRoot;
    [SerializeField] private float playerInteractDistance = 3f;
    private bool isActive = false;

    public Transform grabObj;
    private float previousDrag;
    private float previousMass;
    [SerializeField] private float holdingMassModifier = 100;

    private void Awake() {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
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
        holdingObj = null;
    }
    private void Interact() {

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, playerInteractDistance, ~layermask)) {
            // Check for Target script and invoke unity event. used to KILL rn
            print(hit.collider.gameObject);
            if (hit.transform.TryGetComponent<Target>(out Target target)) {

                target.interact.Invoke();
                return;
            }

            // Pick up body
            if (hit.transform.GetComponent<Rigidbody>() != null) {
                print("Hit smth");
                holdingObj = hit.transform.GetComponent<Rigidbody>();
                previousMass = holdingObj.mass;
                previousDrag = holdingObj.drag;
                holdingObj.mass = holdingMassModifier;
                holdingObj.drag = holdingMassModifier;
            }
        }
        else print("didnt hit");
        /*
        Ray r = new Ray(interactRoot.position, interactRoot.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, playerInteractDistance)) {

            // Check for Target script and invoke unity event. used to KILL rn
            if (hitInfo.transform.TryGetComponent<Target>(out Target target)) {

                target.interact.Invoke();
                return;
            }

            // Pick up body
            if (hitInfo.transform.GetComponent<Rigidbody>() != null) {
                print("Hit smth");
                holdingObj = hitInfo.transform.GetComponent<Rigidbody>();
                previousMass = holdingObj.mass;
                previousDrag = holdingObj.drag;
                holdingObj.mass = holdingMassModifier;
                holdingObj.drag = holdingMassModifier;
            }
            return;
        }
        else print("Also didnt hit");

        */
    }
}
