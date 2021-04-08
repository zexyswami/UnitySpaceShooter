using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   [SerializeField]
    private float _enemySpeed = 4f;

    private Player _player;
    
    
    // Start is called before the first frame update
        void Start()
    {
            _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down 4 meters per second
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        
        //check for if bottom of screen
        //respawn at top with a new random x position
        if(transform.position.y <= -5.46f)
        {
            float randomX = Random.Range(-8f, 8f); 
            transform.position = new Vector3(randomX, 7.31f, 0);
        }
    }

    //when enemy collides with player destroy enemy
    //when enemy collides with laser destroy laser
    //destroy enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Player":
                //check if player collistion has script
                //call damage method from player
                if(_player != null )
                {
                    _player.Damage();
                }
                break;
            case "Laser":
                Destroy(other.gameObject);
                if(_player != null)
                {
                    _player.ScoreAdd(10);
                }
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }
}
