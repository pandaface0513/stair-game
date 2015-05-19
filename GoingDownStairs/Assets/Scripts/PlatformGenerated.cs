using UnityEngine;
using System.Collections;

public class PlatformGenerated : MonoBehaviour {
	public GameObject[] platformList;
	public Transform leftBound;
	public Transform rightBound;
	public Transform camera;
	public Transform initialPlatform;

	public static int maxPlatform=15;
	public float minYInc = 2.0f;
	public float maxYInc = 5.0f;

	public float topRange = 10;

	private float leftRange;
	private float rightRange;

	private float lowestYPosition;

	private GameObject[] list = new GameObject[maxPlatform];
	
	// Use this for initialization
	void Start () {
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		leftRange = -(width/2);
		rightRange = width / 2;

		lowestYPosition = initialPlatform.transform.position.y;
		for (int i =0;i<maxPlatform;i++){
			list[i] = GameObject.Instantiate(platformList[Random.Range (0, platformList.Length - 1)]);

			Vector2 scale = list[i].transform.localScale;
			scale.x = (width/10);
			list[i].transform.localScale = scale;
			initialPlatform.localScale = scale;

			float platformWidth = list[i].GetComponentInChildren<BoxCollider2D>().bounds.size.x;
			float x = Random.Range (leftRange, rightRange-platformWidth);
			float y = lowestYPosition-Random.Range (minYInc, maxYInc);
			list[i].transform.position = new Vector3(x,y,0);

			lowestYPosition = y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		for (int i =0;i<maxPlatform;i++){
			float thisY = list[i].transform.position.y;

			if(thisY>camera.position.y+topRange)
			{
				Destroy(list[i]);
				list[i] = GameObject.Instantiate(platformList[Random.Range (0, platformList.Length - 1)]);
				float platformWidth = list[i].GetComponentInChildren<BoxCollider2D>().bounds.size.x;
				float x = Random.Range (leftRange, rightRange-platformWidth);
				float y = lowestYPosition-Random.Range (minYInc, maxYInc);
				list[i].transform.position = new Vector3(x,y,0);
				
				lowestYPosition = y;
			}
		}
	}
}
