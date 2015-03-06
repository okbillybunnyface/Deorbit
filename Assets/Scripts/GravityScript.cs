using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

    public float intensity = 10;

	void FixedUpdate () 
    {
        GameObject[] satellites = GameObject.FindGameObjectsWithTag("Affected");

        foreach(GameObject s in satellites)
        {
            if (s != this.gameObject)
            {
                Vector3 direction = transform.position - s.transform.position;

                s.rigidbody2D.AddForce(1 * direction * intensity * transform.localScale.x * s.rigidbody2D.mass / Mathf.Pow(direction.magnitude, 2));
            }
        }
	}
}
