using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMvmts : MonoBehaviour
{
    [SerializeField] private Game game;
    public GameObject platform;
    float speed = 0.05f;

    void Update()
    {
        if (!game.menuing)
        {
            float moveX = Input.GetAxis("Vertical");
            float moveZ = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(Mathf.Clamp(moveX, -speed, speed), 0, Mathf.Clamp(-moveZ, -speed, speed)));

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
