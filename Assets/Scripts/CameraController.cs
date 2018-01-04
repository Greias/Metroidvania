using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Transform transform;
    private Transform transformPlayer;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        transformPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = Vector3.zero;
        Vector3 positionPlayer = transformPlayer.position;
        position.x = positionPlayer.x;
        position.y = positionPlayer.y;
        position.z = -10;
        transform.position = position;
	}
}
