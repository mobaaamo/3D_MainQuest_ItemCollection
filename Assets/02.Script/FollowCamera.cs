using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Player;

    public float offsetX = 0.0f;
    public float offsetY = 10.0f;
    public float offsetZ = -10.0f;

    public float CameraSpeed = 10.0f;
    Vector3 PlayerPos;

    private void FixedUpdate()
    {
        PlayerPos = new Vector3(
            Player.transform.position.x + offsetX,
            Player.transform.position.y + offsetY,
            Player.transform.position.z + offsetZ
            );
        transform.position = Vector3.Lerp(transform.position, PlayerPos, Time.deltaTime * CameraSpeed);
    }
    
}
