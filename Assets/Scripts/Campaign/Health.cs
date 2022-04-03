using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    public float Value;
    
    public void Damage (float amount) {
        Value -= amount;
        if (Value <= 0) {
            Die ();
        }
    }

    public void Heal (float amount) {
        Value += amount;
    }

    public virtual void Die() {

    }
}
