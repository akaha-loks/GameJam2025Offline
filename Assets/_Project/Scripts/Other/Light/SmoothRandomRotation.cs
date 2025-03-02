using UnityEngine;

public class SmoothRandomRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f; // Скорость вращения

    private Quaternion targetRotation;

    private void Start()
    {
        SetNewRandomRotation();
    }

    private void Update()
    {
        // Плавно интерполируем текущий поворот к целевому
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Если поворот почти завершён, устанавливаем новый
        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            SetNewRandomRotation();
        }
    }

    private void SetNewRandomRotation()
    {
        float randomX = Random.Range(-35f, 35f);
        float randomY = Random.Range(0f, 360f);
        float randomZ = transform.eulerAngles.z; // Оставляем Z без изменений

        targetRotation = Quaternion.Euler(randomX, randomY, randomZ);
    }
}
