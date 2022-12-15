using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyscript : MonoBehaviour
{
    public Transform []gunPoint;
    public GameObject enemyBullet;
    public GameObject Enemyflash;
    public GameObject EnemyExplosionPrefabs;
    public GameObject damageEffer;
    public HealthBar healthbar;
    public float speed = 1f;
    public float health = 10f;
    public GameObject Coin;
    public AudioClip bulletSound;
    public AudioClip damgeSound;
    public AudioClip explosionSound;
    public AudioSource audioSource;

    float barSize = 1f;
    float damge = 0;

    public float enemyBulletTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Enemyflash.SetActive(false);
        StartCoroutine(EnemyShooting());
        damge = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="PlayerBullet")
        {
            audioSource.PlayOneShot(damgeSound);
            DamageHealthbar();
            Destroy(collision.gameObject);
            GameObject damageVFX = Instantiate(damageEffer, collision.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.05f);
            if (health<=0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Instantiate(Coin, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject EnemyColision = Instantiate(EnemyExplosionPrefabs, transform.position, Quaternion.identity);
                Destroy(EnemyColision, 0.4f);
            }
            
        }
        
    }
    void DamageHealthbar()
    {
        if (health>0)
        {
            health -= 1;
            barSize = barSize - damge;
            healthbar.SetSize(barSize);
        }
    }
    void EnemyFire()
    {
        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
        }
        //Instantiate(enemyBullet, gunPoint1.position, Quaternion.identity);
        //Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);
    }
    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyBulletTime);
            EnemyFire();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            Enemyflash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            Enemyflash.SetActive(false);
        }
       
    }
}
