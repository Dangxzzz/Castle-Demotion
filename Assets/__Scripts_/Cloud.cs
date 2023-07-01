using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    #region Variables

    [Header("Set in Inspector")]
    public GameObject cloudSphere;
    public int numSpheresMax = 10;
    public int numSpheresMin = 6;
    public float scaleYMin = 2f;
    public Vector3 sphereOffsetScale = new(5, 2, 1);
    public Vector2 sphereScaleRangeX = new(4, 8);
    public Vector2 sphereScaleRangeY = new(3, 4);
    public Vector2 sphereScaleRangeZ = new(2, 4);

    private List<GameObject> spheres;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        spheres = new List<GameObject>();

        int num = Random.Range(numSpheresMin, numSpheresMax);
        for (int i = 0; i < num; i++)
        {
            GameObject sp = Instantiate(cloudSphere);
            spheres.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(transform);

            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localPosition = offset;

            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

            scale.y *= 1 - Mathf.Abs(offset.x) / sphereOffsetScale.x;
            scale.y = Mathf.Max(scale.y, scaleYMin);

            spTrans.localScale = scale;
        }
    }

    #endregion
}