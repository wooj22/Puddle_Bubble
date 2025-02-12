using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [Header("UI Key Bindings")]
    [SerializeField] private KeyCode testUIKey = KeyCode.Escape;

    [Header("UI Elements")]
    [SerializeField] private GameObject stopPannelUI;

    public void Update()
    {
        HandleInputUI();
    }

    // UI Input Controll
    private void HandleInputUI()
    {

    }
}
