using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    float timer;
    [SerializeField] float timeBetweenAttack;
    [SerializeField] Transform shootPosition;
    Transform player;
    [SerializeField] float minSpread, maxSpread;
    [SerializeField] GameObject bullet;

    public override void Start()
    {
        base.Start();
        timer = timeBetweenAttack;
        player = ScriptTwo.instance.transform;
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
                Shoot();

            }
        }
        void Shoot()
        {
            Vector2 direction = player.position - shootPosition.position;
            float AngleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion cameraRotation = Quaternion.AngleAxis(AngleDirection, Vector3.forward);
            cameraRotation.z += Random.Range(minSpread, maxSpread);
            shootPosition.rotation = cameraRotation;

            Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        }
    }
}
