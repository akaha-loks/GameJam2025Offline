using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private LevelManager forDev;
    [SerializeField] private RoboCopController roboCop;
    [SerializeField] private GameObject endEffect;
    [SerializeField] private AudioSource findAudio;
    [SerializeField] private AudioSource roboCopOnAudio;

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
        findAudio.Play();
        Invoke("RoboCopAudioPlay", 1f);
    }

    public void RoboCopNotFind()
    {
        if (roboCop != null)
            roboCop.isPlayerFind = false;
        Invoke("RoboCopAudioStop", 0.5f);
    }

    private void RoboCopAudioPlay()
    {
        roboCopOnAudio.Play();
    }
    private void RoboCopAudioStop()
    {
        roboCopOnAudio.Stop();
    }
}
