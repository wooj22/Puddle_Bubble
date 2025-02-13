using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [Header("UI Asset")]
    [SerializeField] private Sprite miusHpSprite;

    [Header("UI Elements")]
    [SerializeField] private Image[] hpImageArray = new Image[5];
    [SerializeField] private Image mainAmmoImage;
    [SerializeField] private Image subAmmoImage;
    [SerializeField] private Text mainAmmoText;
    [SerializeField] private Text subAmmoText;
    [SerializeField] private Text currentWeaponText;

    //[Header("UI Key Bindings")]
    //[SerializeField] private KeyCode testUIKey = KeyCode.Escape;


    public static PlayerUIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void UpdateCurrentWeaponUI(string text)
    {
        currentWeaponText.text = "현재무기 : [" + text + "]";
    }

    // hp UI
    public void HpUiIconDown()
    {
        hpImageArray[Player.Instance.hp].sprite = miusHpSprite;
    }

    // 탄창 UI

}
