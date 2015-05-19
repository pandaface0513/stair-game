using System;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
	public Transform leftBound;
	public Transform rightBound;
	public Transform spike;
	public float yChangeRate = 0.5f;

	private Vector3 oldPosition;
	private float height;
	private float width;
	
	// Use this for initialization
	private void Start()
	{
		oldPosition = transform.position;
		transform.parent = null;
		height = Camera.main.orthographicSize * 2.0f;
		width = height * Screen.width / Screen.height;
	}
	
	
	// Update is called once per frame
	private void Update()
	{
	}

	private void FixedUpdate()
	{
		oldPosition.y -= yChangeRate;
		transform.position = oldPosition;
		leftBound.position = new Vector3(-(width/2),transform.position.y-8,leftBound.position.z);
		rightBound.position = new Vector3(width/2,transform.position.y-8,rightBound.position.z);
		spike.position = new Vector3(-2,transform.position.y+9, spike.position.z);
		oldPosition = transform.position;
	}
}
