using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{
    [Header("Battle key Bindings")]
    [SerializeField] private KeyCode attackKey;  // 공격키
    [SerializeField] private KeyCode loadingKey; // 탄창 변경키

    private void Update()
    {
        WeaponLoading();
        BattleInPut();
    }

    // 탄창 변환
    private void WeaponLoading()
    {
        if (Input.GetKeyDown(loadingKey))
        {
            Player.WeaponType mainWeapon = Player.Instance.mainWeaponType;
            Player.Instance.mainWeaponType = Player.Instance.subWeaponType;
            Player.Instance.subWeaponType = mainWeapon;
        }
    }

    // 공격 명령
    private void BattleInPut()
    {
        if (Input.GetKey(loadingKey)) 
        {
            switch (Player.Instance.mainWeaponType)
            {
                case Player.WeaponType.Gun:
                    // 무기 클래스의 공격 호출
                    break;
                case Player.WeaponType.Getling:
                    // 무기 클래스의 공격 호출
                    break;
                case Player.WeaponType.Sniper:
                    // 무기 클래스의 공격 호출
                    break;
                default:
                    break;
            }
        };


    }
}
