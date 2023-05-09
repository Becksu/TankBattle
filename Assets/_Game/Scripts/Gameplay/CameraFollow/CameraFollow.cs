using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform tF;
    public Vector3 offset;
    public float speed;

    private void Awake()
    {
        tF = transform;
    }
    void Start()
    {
        offset = tF.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        tF.position = Vector3.Lerp(tF.position, player.position + offset,speed);
    }
}
