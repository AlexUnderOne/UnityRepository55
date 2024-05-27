using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEnemy : Enemy
{
    [SerializeField] float attackRadius;
    [SerializeField] LayerMask whatIsPlayer;
    [SerializeField] int boomDamage;
    [SerializeField] GameObject boomEffect;
    public override void Update()
    {
        base.Update();
        if (checkCanAttack())
        {
            BoomAttack();
        }
    }
    void BoomAttack()
    {
        Collider2D[] detectedObject = Physics2D.OverlapCircleAll(transform.position, attackRadius, whatIsPlayer);
        foreach (Collider2D item in detectedObject)
        {
            item?.GetComponent<ScriptTwo>()?.Damage(boomDamage);
        }
        Instantiate(boomEffect, transform.position, Quaternion.identity);
        enemyDeath();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
