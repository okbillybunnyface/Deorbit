using UnityEngine;
using System.Collections;

public class ShipScript : MonoBehaviour {

    public GameObject goal, hud;
    public float thrust = 1;
    public float rotationSpeed = 15;
    public UnityEngine.UI.Text text;

    private LineRenderer lineR;

	// Use this for initialization
	void Start () {
        lineR = this.GetComponent<LineRenderer>();
        lineR.SetVertexCount(2);
        lineR.sortingOrder = -1;
        UpdateLine();
	}
	
	// Update is called once per frame
	void Update () 
    {
        UpdateLine();

        text.text = "Distance to Goal: " + (goal.transform.position - transform.position).magnitude.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.AddForce(transform.up * thrust);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            particleSystem.enableEmission = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            particleSystem.enableEmission = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -Time.deltaTime * rotationSpeed);
        }
	}

    private void UpdateLine()
    {
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, goal.transform.position);
    }
}
