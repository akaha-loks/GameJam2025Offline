using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaBarImg;
    [SerializeField] private float fillAmount = 1f; // ������ �����
    [SerializeField] private float depletionTime = 5f; // ����� �� ������� ���������� (�������)
    [SerializeField] private LevelManager level;

    private float depletionRate;

    private void Start()
    {
        depletionRate = 1f / depletionTime; // ������������ �������� ����������
    }

    private void Update()
    {
        if (fillAmount > 0)
        {
            fillAmount -= depletionRate * Time.deltaTime; // ������� ����������
            fillAmount = Mathf.Clamp01(fillAmount); // ����������� �� 0 �� 1
        }
        else
        {
            level.Restart();
        }

        staminaBarImg.fillAmount = fillAmount;
    }
}
