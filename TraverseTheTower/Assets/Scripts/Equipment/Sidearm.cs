using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidearm : BaseEquipment
{
    BaseCharacter baseCharacter;
    public int sidearmDamage = 1;

    
    void OnEnable()
    {
        if (this.gameObject.GetComponent<BaseCharacter>()) 
        {
            this.baseCharacter = this.GetComponent<BaseCharacter>();

            this.baseCharacter.attack += AttackWithSidearm;
            Debug.Log("Sidearm Equipped.");

        }
    }

    void AttackWithSidearm() 
    {
        if (this.baseCharacter) 
        {
            this.baseCharacter.otherCharacter.damaged?.Invoke(sidearmDamage);
            Debug.Log("Bang! Hit with sidearm. Enemy health ="
                      + this.baseCharacter.otherCharacter.health);
        }
    }
}
