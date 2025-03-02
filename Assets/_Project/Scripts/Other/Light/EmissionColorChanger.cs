using UnityEngine;

public class EmissionColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private float minSpeed = 1f; // Минимальная скорость
    [SerializeField] private float maxSpeed = 4f; // Максимальная скорость

    private Material material;
    private float speed;
    private float time;

    private void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        // Создаём новый экземпляр материала, чтобы не менять оригинал
        material = targetRenderer.material;
        material.EnableKeyword("_EMISSION");

        // Устанавливаем случайную скорость в диапазоне
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        time += Time.deltaTime * speed;

        // Генерируем плавный цвет на основе синусоидальных волн
        float r = Mathf.Sin(time) * 0.5f + 0.5f;
        float g = Mathf.Sin(time + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(time + 4f) * 0.5f + 0.5f;

        Color emissionColor = new Color(r, g, b) * 2f; // Умножаем для яркости

        material.SetColor("_EmissionColor", emissionColor);
    }
}
