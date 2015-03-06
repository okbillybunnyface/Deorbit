using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public float smoothness = 1;
    public float zoomOutSize = 200;

    private float zoomInSize;
    private float targetSize;
    private Vector3 targetPosition;
    private Vector3 offset = new Vector3(0, 0, -10);
    Vector3 centerOfScene;

	// Use this for initialization
	void Start () {
        zoomInSize = camera.orthographicSize;
        transform.position = player.transform.position + offset;
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Find the average position in the scene.
        Transform[] allObjects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
        centerOfScene = Utility.AveragePosition(allObjects);

        if (Input.GetKey(KeyCode.S))
        {
            targetSize = zoomOutSize;
            targetPosition = new Vector3(centerOfScene.x, centerOfScene.y, offset.z);
        }
        else
        {
            targetSize = zoomInSize;
            targetPosition = player.transform.position + offset;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime * smoothness);
	}
}
