using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ForDeveloper forDev;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("You die");
        if(forDev != null)
            forDev.RestartPosition();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
