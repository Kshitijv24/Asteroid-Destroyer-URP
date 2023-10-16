using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    GameOverHandler gameOverHandler;
    [SerializeField] GameObject playerDeathVFX;
    [SerializeField] ParticleSystem playerDamagedVFX;
    [SerializeField] AudioClip playerSpaceShipDeathSFX;
    [SerializeField] int playerHP = 3;
    
    TextMeshProUGUI healthText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        healthText = FindObjectOfType<TextMeshProUGUI>();

        if (healthText != null)
        {
            healthText.text = $"HP: {playerHP}";
        }

        gameOverHandler = FindObjectOfType<GameOverHandler>();
    }

    public int GetPlayerHealth() => playerHP;

    public TextMeshProUGUI GetPlayerHealthTextUI() => healthText;

    public void DamagePlayer(int damageAmount)
    {
        AudioManager.Instance.PlaySound(playerSpaceShipDeathSFX, 1f);
        playerDamagedVFX.Play();
        playerHP -= damageAmount;
        healthText.text = $"HP: {playerHP}";

        if (playerHP <= 0)
        {
            Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
            gameOverHandler.ShowEndGameScreen();
            gameObject.SetActive(false);
        }
    }

    public void IncrementPlayerHealth()
    {
        if (playerHP >= 3) return;

        playerHP++;
        healthText.text = $"HP: {playerHP}";
    }
}
