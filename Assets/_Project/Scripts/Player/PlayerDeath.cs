using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private LevelManager forDev;
    [SerializeField] private RoboCopController roboCop;
    [SerializeField] private GameObject endEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OnFloor"))
        {
            RoboCopFind();
            Debug.Log("Find");
        }

        if (other.CompareTag("Death"))
        {
            Die();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OnFloor"))
        {
            RoboCopNotFind();
            Debug.Log("Not Find");
        }
    }

    private void Die()
    {
        endEffect.SetActive(true);
    }

    public void RoboCopFind()
    {
        if (roboCop != null)
            roboCop.isPlayerFind = true;
    }

    public void RoboCopNotFind()
    {
        if (roboCop != null)
            roboCop.isPlayerFind = false;
    }
}
