using UnityEngine;

public class EmissionColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private float minSpeed = 1f; // ����������� ��������
    [SerializeField] private float maxSpeed = 4f; // ������������ ��������

    private Material material;
    private float speed;
    private float time;

    private void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }

        // ������ ����� ��������� ���������, ����� �� ������ ��������
        material = targetRenderer.material;
        material.EnableKeyword("_EMISSION");

        // ������������� ��������� �������� � ���������
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        time += Time.deltaTime * speed;

        // ���������� ������� ���� �� ������ �������������� ����
        float r = Mathf.Sin(time) * 0.5f + 0.5f;
        float g = Mathf.Sin(time + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(time + 4f) * 0.5f + 0.5f;

        Color emissionColor = new Color(r, g, b) * 2f; // �������� ��� �������

        material.SetColor("_EmissionColor", emissionColor);
    }
}
