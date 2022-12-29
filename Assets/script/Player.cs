using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> 
{

    public float fireRate;
    float m_curFireRate;
    public GameObject viewFinder;

    GameObject m_viewFinderClone;

    bool m_isShort;

    private void Awake()
    {
        m_curFireRate = fireRate;
        
    }
    private void Start()
    {
        if (viewFinder)
        {
           m_viewFinderClone=  Instantiate(viewFinder, Vector3.zero, Quaternion.identity) ;
        }
    }
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && !m_isShort){
            shot(mousePos);
        }

        if (m_isShort)
        {
            
            m_curFireRate -= Time.deltaTime;

            if(m_curFireRate <= 0)
            {
                m_isShort = false;
                m_curFireRate = fireRate;
            }
        }
        if (m_viewFinderClone)
        {
            m_viewFinderClone.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    void shot(Vector3 mosPos)
    {
         m_isShort= true;

        Vector3 shotDir = Camera.main.transform.position - mosPos;
        shotDir.Normalize();

        RaycastHit2D[] hits = Physics2D.RaycastAll(mosPos, shotDir);

        if(hits.Length > 0 && hits != null )
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                
                if(hit.collider && (Vector2.Distance(hit.collider.transform.position, mosPos)) <= 0.4f)
                {
                    Bird bird = hit.collider.GetComponent<Bird>();

                    if(bird)
                    {
                        bird.Die();
                    }

                    Debug.Log(hit.collider.name);
                }
            }
        }
        AudioController.Ins.playSound(AudioController.Ins.shootting);
    }
}
