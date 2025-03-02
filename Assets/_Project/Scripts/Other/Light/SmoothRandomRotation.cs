using UnityEngine;

public class SmoothRandomRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f; // �������� ��������

    private Quaternion targetRotation;

    private void Start()
    {
        SetNewRandomRotation();
    }

    private void Update()
    {
        // ������ ������������� ������� ������� � ��������
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // ���� ������� ����� ��������, ������������� �����
        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            SetNewRandomRotation();
        }
    }

    private void SetNewRandomRotation()
    {
        float randomX = Random.Range(-35f, 35f);
        float randomY = Random.Range(0f, 360f);
        float randomZ = transform.eulerAngles.z; // ��������� Z ��� ���������

        targetRotation = Quaternion.Euler(randomX, randomY, randomZ);
    }
}
