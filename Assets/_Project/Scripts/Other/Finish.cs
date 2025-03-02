using UnityEngine;
using UnityEngine.InputSystem;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishView; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Invoke("OpenFinishView", 0.5f);
        }
    }

    private void OpenFinishView()
    {
        finishView.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
