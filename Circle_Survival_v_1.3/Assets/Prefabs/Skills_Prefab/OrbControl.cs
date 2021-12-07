using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbControl : MonoBehaviour
{
    public int damage;
  
    private void Start()
    {
        
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("RedEnemy") || other.gameObject.CompareTag("BlackEnemy") || other.gameObject.CompareTag("OrangeEnemy"))
        {
            other.gameObject.GetComponent<EnemyControlScript>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<BossControl>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        /*if ((orb == OrbCount.one) || (orb == OrbCount.two))
        {
            positionX = center.position.x + Mathf.Cos(angleX) * radius;
            positionY = center.position.y + Mathf.Sin(angleX) * radius;
            transform.position = new Vector2(positionX, positionY);
            angleX = angleX + Time.deltaTime * anglSpeed;

            if (angleX >= 360)
                angleX = 0.0f;
        }

        if ((orb == OrbCount.three) || (orb == OrbCount.four))
        {
            positionX = center.position.x + Mathf.Cos(angleY) * radius;
            positionY = center.position.y + Mathf.Sin(angleY) * radius;
            transform.position = new Vector2(positionX, positionY);
            angleY = angleY + Time.deltaTime * anglSpeed;

            if (angleY >= 360)
                angleY = 0.0f;
        }*/
    }
}
