using UnityEngine;

public class Glass_Destroy : MonoBehaviour
{
    #region Unity lifecycle

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

    #endregion
}