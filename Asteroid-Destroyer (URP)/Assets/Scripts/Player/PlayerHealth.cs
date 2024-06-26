using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    GameOverHandler gameOverHandler;
    [SerializeField] GameObject playerDeathVFX;
    [SerializeField] ParticleSystem playerDamagedVFX;
    [SerializeField] int playerHP = 3;
    [SerializeField] int maxPlayerHP = 5;
    
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
            Debug.Log("There are more than one " + this.GetType() + " Instances", this);
            return;
        }
    }

    private void Start()
    {
        healthText = GameObject.FindGameObjectWithTag("PlayerHealthTextUI").GetComponent<TextMeshProUGUI>();

        if (healthText == null) return;

        healthText.text = $"HP: {playerHP}";
        gameOverHandler = FindObjectOfType<GameOverHandler>();
    }

    public int GetPlayerHealth() => playerHP;

    public TextMeshProUGUI GetPlayerHealthTextUI() => healthText;

    public void DamagePlayer(int damageAmount)
    {
        AudioManager.Instance.PlayPlayerShipDestroyedSFX(1f);

        playerDamagedVFX.Play();
        playerHP -= damageAmount;
        healthText.text = $"HP: {playerHP}";

        if (playerHP <= 0) 
            PlayerDied();
    }

    private void PlayerDied()
    {
        Instantiate(playerDeathVFX, transform.position, Quaternion.identity);
        gameOverHandler.ShowEndGameScreen();
        gameObject.SetActive(false);
    }

    public void IncrementPlayerHealth()
    {
        if (playerHP >= maxPlayerHP) return;

        playerHP++;
        healthText.text = $"HP: {playerHP}";
    }
}
