using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    #region Variables

    [Header("Set in Inspector")]
    public float minDist = 0.1f;
    public static ProjectileLine projectileLine;
    private GameObject _poi;
    private LineRenderer line;
    private List<Vector3> points;

    #endregion

    #region Properties

    public Vector3 LastPoint
    {
        get
        {
            if (points == null)
            {
                return Vector3.zero;
            }

            return points[points.Count - 1];
        }
    }

    public GameObject Poi
    {
        get => _poi;
        set
        {
            _poi = value;
            if (_poi != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        projectileLine = this;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        points = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        if (Poi == null)
        {
            if (FollowCam.poi != null)
            {
                if (FollowCam.poi.tag == "Projectile")
                {
                    Poi = FollowCam.poi;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        AddPoint();
        if (FollowCam.poi == null)
        {
            Poi = null;
        }
    }

    #endregion

    #region Public methods

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;
        if (points.Count > 0 && (pt - LastPoint).magnitude < minDist)
        {
            return;
        }

        if (points.Count == 0)
        {
            Vector3 launchPosDiff = pt - Slingshot.LaunchPos;
            points.Add(pt + launchPosDiff);
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            line.enabled = true;
        }
        else
        {
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count - 1, LastPoint);
            line.enabled = true;
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    #endregion
}