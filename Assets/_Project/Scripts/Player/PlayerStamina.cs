using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Image staminaBarImg;
    [SerializeField] private float fillAmount = 1f; // Полная шкала
    [SerializeField] private float depletionTime = 0.5f; // Время на уменьшение (секунды)
    [SerializeField] private LevelManager level;
    [SerializeField] private GameObject danger;
    [SerializeField] private float amount;
    [SerializeField] private AudioSource heartAudio;

    private bool dangerActivated = false; // Флаг, чтобы не включать `danger` каждый кадр
    private float targetStamina; // Целевая стамина
    private float lerpTimer = 0f; // Таймер для Lerp

    private void Start()
    {
        danger.SetActive(false); // По умолчанию `danger` выключен
        targetStamina = fillAmount; // Начальная цель — полная шкала
    }

    private void Update()
    {
        // Плавно уменьшаем стамину
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

        // Включаем danger при 30% стамины
        if (fillAmount <= 0.2f && !dangerActivated)
        {
            danger.SetActive(true);
            dangerActivated = true;
            heartAudio.Play();
        }
    }

    // Вызов уменьшения стамины
    public void CutStamina()
    {
        targetStamina = Mathf.Clamp(fillAmount - amount, 0f, 1f); // Устанавливаем новую цель
        lerpTimer = 0f; // Сбрасываем таймер Lerp
    }
}
