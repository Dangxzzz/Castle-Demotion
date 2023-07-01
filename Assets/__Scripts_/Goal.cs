using UnityEngine;

public class Goal : MonoBehaviour
{
    #region Variables

    public static bool goalMelt;

    #endregion

    #region Unity lifecycle

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            goalMelt = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            c.r = 1;
            mat.color = c;
        }
    }

    #endregion
}