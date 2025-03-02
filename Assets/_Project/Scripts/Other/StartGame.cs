using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool isGamePlay;

    private void Start()
    {
        if (isGamePlay)
            Invoke("MouseNotShow", 0.1f);
        else
            Invoke("MouseShow", 0.1f);
    }

    private void MouseShow()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void MouseNotShow()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
