using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaBarImg;
    [SerializeField] private float fillAmount = 1f; // Полная шкала
    [SerializeField] private float depletionTime = 5f; // Время до полного уменьшения (секунды)
    [SerializeField] private LevelManager level;

    private float depletionRate;

    private void Start()
    {
        depletionRate = 1f / depletionTime; // Рассчитываем скорость уменьшения
    }

    private void Update()
    {
        if (fillAmount > 0)
        {
            fillAmount -= depletionRate * Time.deltaTime; // Плавное уменьшение
            fillAmount = Mathf.Clamp01(fillAmount); // Ограничение от 0 до 1
        }
        else
        {
            level.Restart();
        }

        staminaBarImg.fillAmount = fillAmount;
    }
}
