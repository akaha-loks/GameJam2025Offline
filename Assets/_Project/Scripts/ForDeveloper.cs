using UnityEngine;
using UnityEngine.SceneManagement;

public class ForDeveloper : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform spawnTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RestartPosition();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartPosition()
    {
        playerTransform.position = spawnTransform.position;
    }
}
