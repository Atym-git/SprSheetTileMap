using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField] private float _cameraHeight = 1f;
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _camera;

    void Update()
    {
        CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
        Vector3 newPos = new Vector3(_player.position.x, _player.position.y + _cameraHeight, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);
    }
}
