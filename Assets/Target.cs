using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public bool isAlive = true;
    public UnityEvent interact;
    public UnityEvent getGutted;
    public UnityEvent onTriggerEnter;
}
