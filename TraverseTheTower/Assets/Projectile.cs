using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int damage = 0;

    private BaseCharacter target;
    private Transform     targetTransform;
    public  float         projectileSpeed   = 1.0f;
    public  float         collisionDistance = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // move projectile towards the target
        if (this.targetTransform)
        {
            Vector3 direction = (Vector3)targetTransform.position - this.transform.position;
            if (direction.magnitude <= collisionDistance) 
            {
                target.damaged?.Invoke(this.damage);
                Destroy(this.gameObject);
            }
            direction.Normalize();
            this.gameObject.transform.position += direction * projectileSpeed * Time.deltaTime;

            this.transform.LookAt(target.gameObject.transform, Vector3.up);
        }
    }

    public void InitWithParameters(BaseCharacter _shooter, BaseCharacter _target, int _projectileDamage) 
    {
        this.target              = _target;
        this.targetTransform     = _target.gameObject.GetComponent<Transform>();
        this.damage              = _projectileDamage;

        if (_target.gameObject.GetComponent<CapsuleCollider>()) 
        {
            // TODO: Remove this or put it somewhere else. GetComponent shouldn't be called on each instantiation.
            this.collisionDistance = _target.gameObject.GetComponent<CapsuleCollider>().radius;
        }

    }

    
}
