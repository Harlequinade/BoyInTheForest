using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_map_camera : MonoBehaviour {

    public Transform player;
    public Transform main_camera;
    public float rotationspeed = 10f;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y =transform.position.y;
        transform.position = newPosition;

        Quaternion newRotation = Quaternion.Euler(90f, main_camera.rotation.y*rotationspeed, 0f);
        transform.rotation = newRotation;
    }
}
