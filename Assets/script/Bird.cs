using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float xspeed = 0;
    public float minspeed;
    public float maxspeed;

    Rigidbody2D m_rb;
    bool m_moveleftonStart;//kiem tra xem di chuyen sang trai
    public GameObject vfxDie;
    bool isDeath;

    
    private void Awake()
    {
        
        m_rb= GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        RandamMovingDirection();
    }

    private void Update()
    {
        m_rb.velocity = m_moveleftonStart ? new Vector2(-xspeed, Random.Range(minspeed, maxspeed)) //dk dung ,di cuyen sang trai
            : new Vector2(xspeed, Random.Range(minspeed, maxspeed));

        flip();
    }

    public void RandamMovingDirection()
    {
        m_moveleftonStart = transform.position.x > 0 ? true : false;
    }
    private void flip()
    {
        if(m_moveleftonStart)
        {
            if (transform.localScale.x < 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }else{
            if (transform.localScale.x > 0) return;

            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Die()
    {
        isDeath= true;

        managerGame.Ins.KillBird++;
        Destroy(gameObject);

        if (vfxDie)
        {
            Instantiate(vfxDie, transform.position , Quaternion.identity);  

            GameGUIManager.Ins.UpdateKiller(managerGame.Ins.KillBird);
        }
    }
}
