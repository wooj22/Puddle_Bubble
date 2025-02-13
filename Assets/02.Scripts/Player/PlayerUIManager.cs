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

    // 현재 무기 UI
    public void UpdateCurrentWeaponUI(string text)
    {
        currentWeaponText.text = "현재무기 : [" + text + "]";
    }

    // HP UI
    public void HpUiIconDown()
    {
        hpImageArray[Player.Instance.hp].sprite = miusHpSprite;
    }

    // 메인탄창 UI
    public void UpdateMainAmmoUI(int mainAmmo, int maxAmmo)
    {
        mainAmmoText.text = mainAmmo.ToString();
        mainAmmoImage.fillAmount = (float)mainAmmo / (float)maxAmmo;
        Debug.Log(mainAmmo / maxAmmo);
    }

    // 서브탄창 UI
    public void UpdateSubAmmoUI(int subAmmo, int maxAmmo)
    {
        subAmmoText.text = subAmmo.ToString();
        subAmmoImage.fillAmount = (float)subAmmo / (float)maxAmmo;
    }
}
