using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour {
    
        public Slider healthBar;

        float speed = 20.0F;
        float rotationSpeed = 120.0F;
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        public Transform respawn;
        float health = 100.0f;

        void Update()
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            // fica direcionada para a camera
            Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
            // valor da barra de vida é igual a variavel vida
            healthBar.value = (int)health;
            // segue o player
            healthBar.transform.position = healthBarPos + new Vector3(0, 60, 0);

            // se aperta espaço atira
            if (Input.GetKeyDown("space"))
            {
                // spawna a bala
                GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                // adiciona força nela
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*2000);
            }

            if (health <= 0)
            {
                health = 100;
                transform.position = respawn.position;
            }
        }    

    void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "bullet")
            {
                health -= 10;
            }
        }

    public void Damage(float damage)
    {
        health += damage;
    }

}
