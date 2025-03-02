using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaBarImg;
    [SerializeField] private float fillAmount = 1f; // ������ �����
    [SerializeField] private float depletionTime = 0.5f; // ����� �� ���������� (�������)
    [SerializeField] private LevelManager level;
    [SerializeField] private GameObject danger;
    [SerializeField] private float amount;
    [SerializeField] private AudioSource heartAudio;

    private bool dangerActivated = false; // ����, ����� �� �������� `danger` ������ ����
    private float targetStamina; // ������� �������
    private float lerpTimer = 0f; // ������ ��� Lerp

    private void Start()
    {
        danger.SetActive(false); // �� ��������� `danger` ��������
        targetStamina = fillAmount; // ��������� ���� � ������ �����
    }

    private void Update()
    {
        // ������ ��������� �������
        if (fillAmount > targetStamina)
        {
            lerpTimer += Time.deltaTime / depletionTime;
            fillAmount = Mathf.Lerp(fillAmount, targetStamina, lerpTimer);
        }

        if (fillAmount <= 0)
        {
            level.Restart();
        }

        staminaBarImg.fillAmount = fillAmount;

        // �������� danger ��� 30% �������
        if (fillAmount <= 0.2f && !dangerActivated)
        {
            danger.SetActive(true);
            dangerActivated = true;
            heartAudio.Play();
        }
    }

    // ����� ���������� �������
    public void CutStamina()
    {
        targetStamina = Mathf.Clamp(fillAmount - amount, 0f, 1f); // ������������� ����� ����
        lerpTimer = 0f; // ���������� ������ Lerp
    }
}
