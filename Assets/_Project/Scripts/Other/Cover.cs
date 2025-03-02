using UnityEngine;

public class Cover : MonoBehaviour
{
    public bool isOnsCover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cover"))
        {
            isOnsCover = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cover"))
        {
            isOnsCover = false;
        }
    }
}
