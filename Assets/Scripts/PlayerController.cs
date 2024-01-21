using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    
    private Rigidbody _playerRb;
    private bool _isOnGround = true;
    private bool _gameOver = false;
    private Animator _playerAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }   
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _gameOver = true;
        explosionParticle.Play();
        dirtParticle.Stop();
        _playerAnim.SetBool("Death_b", true);
        _playerAnim.SetInteger("DeathType_int", 1);
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }
}
