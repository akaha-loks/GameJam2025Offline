using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isPointerOver = false;
    [SerializeField] private float range;
    public float moveSpeed = 5f; // Скорость выдвижения

    private RectTransform buttonRectTransform;

    void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        originalPosition = buttonRectTransform.localPosition;
        targetPosition = new Vector3(originalPosition.x + range, originalPosition.y, originalPosition.z); // Сдвиг влево
    }

    void Update()
    {
        if (isPointerOver)
        {
            // Плавно двигаем кнопку влево, если указатель мыши над ней
            buttonRectTransform.localPosition = Vector3.Lerp(buttonRectTransform.localPosition, targetPosition, Time.deltaTime * moveSpeed);
        }
        else
        {
            // Плавно возвращаем кнопку в исходное положение
            buttonRectTransform.localPosition = Vector3.Lerp(buttonRectTransform.localPosition, originalPosition, Time.deltaTime * moveSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true; // Мышь навела на кнопку
        Debug.Log("Pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false; // Мышь покинула кнопку
        Debug.Log("Pointer exited");
    }
}
