using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isPointerOver = false;
    [SerializeField] private float range;
    public float moveSpeed = 5f; // �������� ����������

    private RectTransform buttonRectTransform;

    void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        originalPosition = buttonRectTransform.localPosition;
        targetPosition = new Vector3(originalPosition.x + range, originalPosition.y, originalPosition.z); // ����� �����
    }

    void Update()
    {
        if (isPointerOver)
        {
            // ������ ������� ������ �����, ���� ��������� ���� ��� ���
            buttonRectTransform.localPosition = Vector3.Lerp(buttonRectTransform.localPosition, targetPosition, Time.deltaTime * moveSpeed);
        }
        else
        {
            // ������ ���������� ������ � �������� ���������
            buttonRectTransform.localPosition = Vector3.Lerp(buttonRectTransform.localPosition, originalPosition, Time.deltaTime * moveSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true; // ���� ������ �� ������
        Debug.Log("Pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false; // ���� �������� ������
        Debug.Log("Pointer exited");
    }
}
