using UnityEngine;
using System.Collections;

public class Utility 
{
    //a and b must the same length
    public static float[] Lerp(float[] a, float[] b, float c)
    {
        if(a.Length != b.Length)
        {
            throw new System.IndexOutOfRangeException("Parameter arrays must be the same size.");
        }

        float[] output = new float[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            output[i] = Mathf.Lerp(a[i], b[i], c);
        }

        return output;
    }

    //These return the average position of all the objects given.
    public static Vector3 AveragePosition(Vector3[] positions)
    {
        Vector3 output = Vector3.zero;

        foreach (Vector3 a in positions)
        {
            output += a;
        }

        output /= positions.Length;

        return output;
    }
    public static Vector3 AveragePosition(Transform[] transforms)
    {
        Vector3[] allObjPos = new Vector3[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            allObjPos[i] = transforms[i].position;
        }
        return AveragePosition(allObjPos);
    }
    public static Vector3 AveragePosition(GameObject[] gameObjects)
    {
        Vector3[] allObjPos = new Vector3[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            allObjPos[i] = gameObjects[i].transform.position;
        }
        return AveragePosition(allObjPos);
    }
}
