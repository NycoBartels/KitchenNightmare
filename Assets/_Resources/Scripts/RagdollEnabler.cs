using UnityEngine;

public class RagdollEnabler : MonoBehaviour {
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private Transform RagdollRoot;
    [SerializeField]
    private bool StartRagdoll = false;
    [SerializeField] private GameObject pelvisToEnable;
    // Only public for Ragdoll Runtime GUI for explosive force
    public Rigidbody[] Rigidbodies;
    private CharacterJoint[] Joints;
    private Collider[] Colliders;

    [Header("Set Start Animation")]
    [SerializeField] private string animationName;

    private void Awake() {
        Rigidbodies = RagdollRoot.GetComponentsInChildren<Rigidbody>();
        Joints = RagdollRoot.GetComponentsInChildren<CharacterJoint>();
        Colliders = RagdollRoot.GetComponentsInChildren<Collider>();
        Animator = GetComponentInChildren<Animator>();

        if (StartRagdoll) {
            EnableRagdoll();
        }
        else {
            EnableAnimator();
        }
        Animator.Play(animationName);
    }
    public void EnableRagdoll() {
        pelvisToEnable.SetActive(true);
        Animator.enabled = false;
        foreach (CharacterJoint joint in Joints) {
            joint.enableCollision = true;
        }
        foreach (Collider collider in Colliders) {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in Rigidbodies) {
            rigidbody.velocity = Vector3.zero;
            rigidbody.detectCollisions = true;
            rigidbody.useGravity = true;
        }
    }

    public void EnableAnimator() {
        Animator.enabled = true;
        foreach (CharacterJoint joint in Joints) {
            joint.enableCollision = false;
        }
        foreach (Collider collider in Colliders) {
            collider.enabled = false;
        }
        foreach (Rigidbody rigidbody in Rigidbodies) {
            rigidbody.detectCollisions = false;
            rigidbody.useGravity = false;
        }
    }
}