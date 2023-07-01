using UnityEngine;

public class FollowCam : MonoBehaviour
{
    #region Variables

    [Header("Set Dynamically")]
    public float camZ;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;
    public static GameObject poi;

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        camZ = transform.position.z;

        Destroy(GameObject.FindWithTag("BG_MUSIC_CREATED"));
    }

    private void FixedUpdate()
    {
        Vector3 destination;
        if (poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;
            if (poi.tag == "Projectile")
            {
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    poi = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }

    #endregion
}