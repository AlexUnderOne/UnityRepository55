using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRigidBody;
    Animator enemyAnimation;
    [SerializeField] int health;
    [SerializeField] float stopDistance, enemySpeed, distanceToRunOut;
    protected ScriptTwo player;
    bool isDeath = false;
    SpriteRenderer enemySpriteRenderer;
    bool canAttack = false;

    [SerializeField] GameObject effectHitEnemy;
    Vector3 addRandomPose;

    [SerializeField] int minCoinsAdd, maxCoinsAdd;


    public virtual void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<Animator>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();

        player = ScriptTwo.instance;

        StartCoroutine(nameof(setRandomPosition));
        EnemyLayerManager.instance.Add(enemySpriteRenderer);
    }

    private void OnDestroy()
    {
        EnemyLayerManager.instance.Delete(enemySpriteRenderer);
    }
    public virtual void Update()
    {
        if (isDeath || !player) return;
        positionScale(player.transform.position);

    }
    private void FixedUpdate()
    {

        if (isDeath) return;
        if (player && Vector2.Distance(transform.position, player.transform.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position + addRandomPose, enemySpeed * Time.fixedDeltaTime);
            enemyAnimation.SetBool("run", true);
            canAttack = false;
        }
        else if (player && Vector2.Distance(transform.position, player.transform.position) < distanceToRunOut)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position + addRandomPose, -enemySpeed * Time.fixedDeltaTime);
            enemyAnimation.SetBool("run", true);
            canAttack = false;
        }
        else
        {
            enemyAnimation.SetBool("run", false);
            canAttack = true;
        }
    }

    IEnumerator setRandomPosition()
    {
        addRandomPose = new Vector3(Random.Range(-stopDistance + 0.1f, stopDistance - 0.1f), Random.Range(-stopDistance + 0.1f, stopDistance + 0.1f));

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(nameof(setRandomPosition));
    }
    void positionScale(Vector3 position)
    {
        if (position.x >= transform.position.x) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }
    protected void enemyDeath()
    {
        isDeath = true;

        ScriptTwo.instance.AddMoney(Random.Range(minCoinsAdd, maxCoinsAdd));
        enemyAnimation.SetTrigger("death");
        //Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0) enemyDeath();
        Instantiate(effectHitEnemy, transform.position, Quaternion.identity);


    }
    public IEnumerator destroyObject()
    {
        while (enemySpriteRenderer.color.a != 0)
        {
            float saturation = enemySpriteRenderer.color.a;
            enemySpriteRenderer.color = new Color(255, 255, 255, saturation -= 0.1f);
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
    public virtual bool checkCanAttack()
    {
        return canAttack && !isDeath;
    }
}
