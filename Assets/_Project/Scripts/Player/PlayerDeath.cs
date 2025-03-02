using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private LevelManager forDev;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("You die");
        if(forDev != null)
            forDev.RestartPosition();
        else
            SceneManager.LoadScene("DeathDromRoboCop");
    }
}
