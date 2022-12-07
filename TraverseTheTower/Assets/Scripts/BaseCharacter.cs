using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public GameObject    TargetCharacter;
    public BaseCharacter otherCharacter;

    public delegate void onAttack();
    public onAttack attack;
    public delegate void onDamaged(int incomingDamage);
    public onDamaged damaged;
    public GameObject projectileOrigin;
    public GameObject projectilePrefab;

    public int maxHealth    = 80;
    public int health       = 80;
    public int attackDamage = 6;

    private void Awake()
    {
        if (TargetCharacter.GetComponent<BaseCharacter>()) 
        {
            otherCharacter = TargetCharacter.GetComponent<BaseCharacter>();
        }
        Component[] equipments = this.gameObject.GetComponents<BaseEquipment>();

        foreach (BaseEquipment equipment in equipments) 
        {
            equipment.enabled = true;
            Debug.Log("Equipped.");
        }

        // assign damaged and attack
        damaged += baseOnDamaged;
        attack  += baseOnAttack;
    }

    private void OnMouseDown()
    {
        attack?.Invoke();
    }

    private void baseOnDamaged(int incomingDamage) 
    {
        if (this.health > 0) 
        {
            health -= incomingDamage;
            Debug.Log("I'm hit. New health:" + health);
        }
    }

    private void baseOnAttack() 
    {
        if (otherCharacter 
        &&  this.projectileOrigin
        &&  this.projectilePrefab)
        {
            Projectile projectile;

            GameObject projectileObject = Instantiate(this.projectilePrefab,
                                                      this.projectileOrigin.transform.position,
                                                      Quaternion.identity) 
                                                      as GameObject;
            projectile = projectileObject.GetComponent<Projectile>();

            projectile.InitWithParameters(this, otherCharacter, this.attackDamage);


            // otherCharacter.damaged?.Invoke(attackDamage);
            // Debug.Log("Bam. Enemy health: " + otherCharacter.health);
        }
    }





}
