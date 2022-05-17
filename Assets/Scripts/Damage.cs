using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(int dam)
    {
        health -= dam;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
