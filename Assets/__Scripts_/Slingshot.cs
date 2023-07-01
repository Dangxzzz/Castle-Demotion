using UnityEngine;

public class Slingshot : MonoBehaviour
{
    #region Variables

    public bool aimingMode;
    public Transform idlePosition;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public LineRenderer[] lineRenderers;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public GameObject projectile;
    public Transform[] stripPositions;
    public float velocityMult = 8f;
    private static Slingshot _slingshot;
    private bool isMouseDown;
    private Rigidbody projectileRigidbody;

    #endregion

    #region Properties

    public static Vector3 LaunchPos
    {
        get
        {
            if (_slingshot == null)
            {
                return Vector3.zero;
            }

            return _slingshot.launchPos;
        }
    }

    #endregion

    #region Unity lifecycle

    private void Awake()
    {
        _slingshot = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void Start() //
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
    }

    private void Update()
    {
        float maxMagnitude = GetComponent<SphereCollider>().radius;
        if (isMouseDown) //
        {
            //
            Vector3 mousePosition2D = Input.mousePosition; //
            mousePosition2D.z = -Camera.main.transform.position.z; //
            Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);
            Vector3 mousePositionDelta = mousePosition3D - launchPos;

            if (mousePositionDelta.magnitude > maxMagnitude)
            {
                mousePositionDelta.Normalize();
                mousePositionDelta *= maxMagnitude;
            }

            Vector3 stripPos = launchPos + mousePositionDelta;
            lineRenderers[0].transform.position = stripPos;
            lineRenderers[1].transform.position = stripPos;
            SetStrips(stripPos);
        } //
        else
        {
            ResetStrips();
        }

        if (!aimingMode)
        {
            return;
        }

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;
        //float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.poi = projectile;
            projectile = null;
            MissionDemotion.ShotFired();
            ProjectileLine.projectileLine.Poi = projectile;
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
        aimingMode = true;
        projectile = Instantiate(prefabProjectile);
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    private void OnMouseEnter()
    {
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }

    #endregion

    #region Private methods

    private void ResetStrips()
    {
        SetStrips(idlePosition.position);
    }

    private void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
    }

    #endregion
}