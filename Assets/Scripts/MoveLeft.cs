using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    
    private PlayerController _playerControllerScript;
    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( ! _playerControllerScript.IsGameOver() )
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
    }
}
