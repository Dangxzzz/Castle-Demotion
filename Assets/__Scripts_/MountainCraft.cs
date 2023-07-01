using UnityEngine;

public class MountainCraft : MonoBehaviour
{
    #region Variables

    public Vector3 mountainPosMax = new(150, 0, 10);
    public Vector3 mountainPosMin = new(-50, 0, -10);
    public GameObject mountainPrefab;
    public float mountainScaleMax = 3;
    public float mountainScaleMin = 1;
    [Header("Set in Inspector")]
    public int numClouds = 40;

    private GameObject[] cloudInstances;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        cloudInstances = new GameObject[numClouds];
        for (int i = 0; i < numClouds; i++)
        {
            mountainPrefab = Instantiate(mountainPrefab);
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(mountainPosMin.x, mountainPosMax.x);
            cPos.y = Random.Range(mountainPosMin.y, mountainPosMax.y);
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(mountainScaleMin, mountainScaleMax, scaleU);
            cPos.y = Mathf.Lerp(mountainPosMin.y, cPos.y, scaleU);
            cPos.z = 100;
            mountainPrefab.transform.position = cPos;
            mountainPrefab.transform.localScale = Vector3.one * scaleVal;
            mountainPrefab.transform.Rotate(0, 0, scaleVal);
        }
    }

    #endregion
}