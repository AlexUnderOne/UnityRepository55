using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speedOfBullet;
    [SerializeField] float deathTime;
    [SerializeField] int damage;

    [System.Serializable]
    public enum Type
    {
        Player,
        Enemy
    }
    [SerializeField] Type type;
    void Start()
    {
        Invoke(nameof(Death), deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedOfBullet);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Death();
        }
        if (collision.gameObject.tag == "enemy" && type == Type.Player)
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Death();
        }
        if (collision.gameObject.tag == "Player" && type == Type.Enemy)
        {
            collision.gameObject.GetComponent<ScriptTwo>().Damage(damage);
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);

    }
}
