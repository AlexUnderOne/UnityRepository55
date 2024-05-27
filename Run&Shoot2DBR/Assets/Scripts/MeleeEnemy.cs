using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    float timer;
    [SerializeField] float timeBetweenAttack, attackSpeed;
    [SerializeField] int damage;
    public override void Start()
    {
        base.Start();
        timer = timeBetweenAttack;
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (checkCanAttack() && player)
        {

            if (timer >= timeBetweenAttack)
            {
                timer = 0;
                StartCoroutine(nameof(Attack));
            }
        }
    }
    IEnumerator Attack()
    {

        ScriptTwo.instance.Damage(damage);
        Vector2 originalEnemyPosition = transform.position;
        Vector2 playerPosition = ScriptTwo.instance.transform.position;

        float percent = 0f;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalEnemyPosition, playerPosition, interpolation);
            yield return null;
        }
    }
}
