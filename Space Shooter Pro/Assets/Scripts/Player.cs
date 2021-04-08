using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5f;
    private float _alternateSpeed = 8.5f;
    public float verticalInput;
    public float horizontalInput; 
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private bool _isTripleActive = false;
    private bool _isSpeedActive = false;
    [SerializeField]
    private bool _isShieldActive = false;
    private float _powerupCD = 5f;
    [SerializeField]
    private GameObject _shield;

    [SerializeField]
    private int _score = 0;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        //take the current position and assign it a start position  (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
        
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if ( _uiManager == null )
        {
            Debug.LogError("The UI Manager is NULL.");
        }

    }

    // Update is called once per frame at 60 frames/ 1 sec
    void Update()
    {
        CalculateMovement();
        if ( Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire )
        {
            FireLaser();
        }
    }
    
    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        if ( _isTripleActive == true )
        {
            Instantiate(_tripleShotPrefab, transform.position + new Vector3(-0.7f, -1.2f, 0f), Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + (_laserPrefab.transform.up * 0.98f), Quaternion.identity);
        }
                 
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        if(_isSpeedActive == true )
        {
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _alternateSpeed * Time.deltaTime);
        }
        
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _playerSpeed * Time.deltaTime);
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.95f, 0), 0);

        //make player wrap screen when moved outside the border
        if ( transform.position.x >= 11.29f )
        {
            transform.position = new Vector3(-11.31f, transform.position.y, 0);
        }
        else if ( transform.position.x <= -11.31f )
        {
            transform.position = new Vector3(11.29f, transform.position.y, 0);
        }
    }
    
    public void Damage()
    {
        if (_isShieldActive == true)
        {
            _isShieldActive = false;
            _shield.SetActive(false);
            return;
        }
        _lives --;

        _uiManager.UpdateLives(_lives);

        if(_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
    
    public void TripleShotActive()
    {
         _isTripleActive = true;
        StartCoroutine(TripleShotPowerDownRoutine(_powerupCD));
    }
    
    public IEnumerator TripleShotPowerDownRoutine(float time)
    {
        yield return new WaitForSeconds(time);  
        _isTripleActive = false;
    }

    public void SpeedActive ()
    {
        _isSpeedActive = true;
        StartCoroutine(SpeedPowerDownRoutine(_powerupCD));
    }

    public IEnumerator SpeedPowerDownRoutine (float time)
    {
        yield return new WaitForSeconds(time);
        _isSpeedActive = false;
    }

    public void ShieldActive ()
    {
        _isShieldActive = true;
        _shield.SetActive(true);
    }

    public  void ScoreAdd (int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}

