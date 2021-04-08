using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{   
    [SerializeField]
    private float _laserSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserMovement();
        DestroyLaser();
    }
    
    void LaserMovement()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
    }

    void DestroyLaser()
    {
        if(transform.position.y >= 6.94f)
        {
            if ( transform.parent == true )
            {
                Destroy(this.transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
