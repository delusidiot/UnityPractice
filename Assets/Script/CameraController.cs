using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;//실제로 GameObject를 넣은 상태가 아니다. Player를 Unity editor에서 넣어줘야된다.
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {//LateUpdate는 FixedUpdate이후 불러온다.
        transform.position = player.transform.position + offset;
	}
}
