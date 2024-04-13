using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private GameObject _cam;
    private Rigidbody holdingObj;
    private Transform handRoot;
    [SerializeField] private float playerInteractDistance = 3f;
    private bool isActive = false;

    public Transform grabObj;
    private float previousDrag;
    private float previousMass;
    [SerializeField] private float holdingMassModifier = 100;

    private void Awake() {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        handRoot = transform.GetChild(2);
        Physics.IgnoreLayerCollision(3, 3);
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
        isActive = Physics.Raycast(_cam.transform.position, _cam.transform.TransformDirection(Vector3.forward), out hit, playerInteractDistance);
        if (isActive && hit.transform.GetComponent<Rigidbody>() != null) {
            holdingObj = hit.transform.GetComponent<Rigidbody>();
            previousMass = holdingObj.mass;
            previousDrag = holdingObj.drag;
            holdingObj.mass = holdingMassModifier;
            holdingObj.drag = holdingMassModifier;
        }
    }
}
