using UnityEngine;
using UnityEngine.InputSystem;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Invoke("OpenFinishView", 0.5f);
        }
    }

    private void OpenFinishView()
    {
        finishScene.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
