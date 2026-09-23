using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float speed = 1f;

    private void Update()
    {
        float step = speed * Time.deltaTime;

        Vector2 newPos = Vector2.MoveTowards(transform.position, player.position, step);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
