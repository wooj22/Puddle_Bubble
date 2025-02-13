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

    // hp UI
    public void HpUiIconDown()
    {
        hpImageArray[Player.Instance.hp].sprite = miusHpSprite;
    }

    // źâ UI

}
