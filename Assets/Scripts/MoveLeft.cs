using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float speed = 30;

    private void Start()
    {
        playerControllerScript =
           FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
      transform.Translate(Vector3.left * Time.deltaTime* speed);

        if (!playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }

    }
   }
