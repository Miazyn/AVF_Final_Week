using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;
    public float shooting_speed = 3f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private SpriteRenderer enemy;
    private Material original;
    public Material flash;

    void Start()
    {
        enemy = gameObject.GetComponent<SpriteRenderer>();
        original = enemy.material;
        if (gameObject.CompareTag("Enemy"))
        {
            InvokeRepeating("Enemy_Shoot", 1f, shooting_speed);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        enemy.material = flash;
        Flash();
        if (health <= 0)
        {

            Die();

        }

    }
    void Flash()
    {

        float startAni = Time.timeSinceLevelLoad;
        if(Time.timeSinceLevelLoad - startAni > 0.5f)
        {
            enemy.material = original;
        }

    }
    void Enemy_Shoot()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
