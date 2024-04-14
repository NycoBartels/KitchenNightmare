using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doordash : MonoBehaviour
{
    [SerializeField] private Animator doornob;
    [SerializeField] private Animator door;
    // Start is called before the first frame update
    public void triggeranimation()
    {
        doornob.SetTrigger("nobfall");
        door.SetTrigger("doorfall");
    }
}
