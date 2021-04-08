using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _powerupSpeed = 3f;
    [SerializeField]
    private int _powerupID; //0 = triple 1 = speed 2 = shields

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _powerupSpeed * Time.deltaTime);
        if(transform.position.y <= -5.46)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter2D( Collider2D other)
    {
        
        if ( other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        Destroy(this.gameObject);
                        break;
                    case 1:
                        Destroy(this.gameObject);
                        player.SpeedActive();
                        break;
                    case 2:
                        Destroy(this.gameObject);
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Did not collect Powerup!!");
                        break;
                }  
            }
        }
    }
}
