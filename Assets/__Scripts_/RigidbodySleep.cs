using UnityEngine;

public class RigidbodySleep : MonoBehaviour
{
    #region Unity lifecycle

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.Sleep();
        }
    }

    #endregion
}