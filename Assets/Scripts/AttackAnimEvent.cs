using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimEvent : MonoBehaviour
{
    public void AttackEvent()
    {
        GetComponentInParent<PlayerController>().Attack();
    }
}
