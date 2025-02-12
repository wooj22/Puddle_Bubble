using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{
    [Header("Battle key Bindings")]
    [SerializeField] private KeyCode attackKey;  // 공격키
    [SerializeField] private KeyCode loadingKey; // 탄창 변경키

    [Header("ReLoading")]
    [SerializeField] int loadingCheakTime = 3;
    private float currentCheakTime;
    private bool isLoadable;

    // component
    private Gun gun;

    /// <summary>
    /// 재장전 체크 뭔 웅덩인가 그거 체크하는거 만들어야댐. 기획서 이따 한번 쫙 다시 읽어봐라
    /// </summary>

    private void Start()
    {
        gun = GetComponent<Gun>();
    }

    private void Update()
    {
        WeaponLoading();
        BattleInPut();
    }

    // 탄창 변경
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
        if (Input.GetKey(attackKey)) 
        {
            switch (Player.Instance.mainWeaponType)
            {
                case Player.WeaponType.Gun:
                    gun.Attack();
                    break;
                case Player.WeaponType.Getling:
                    // 무기 클래스의 공격 호출(아직없음)
                    break;
                case Player.WeaponType.Sniper:
                    // 무기 클래스의 공격 호출(아직없음)
                    break;
                default:
                    break;
            }
        };
    }

    // 재장전 명령
    private void ReLoading()
    {
        switch (Player.Instance.mainWeaponType)
        {
            case Player.WeaponType.Gun:
                // 무기 클래스의 재장전 호출
                break;
            case Player.WeaponType.Getling:
                // 무기 클래스의 재장전 호출
                break;
            case Player.WeaponType.Sniper:
                // 무기 클래스의 재장전 호출
                break;
            default:
                break;
        }
    }

    // 재장전 가능 여부 체크
    // 속도가 0이고 물웅덩이에 loadingCheakTime 이상 있었을 때
    // 이제 어떤 물웅덩이인지 체크하고 탄창 변환하는거 추가 필요
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "아직없는물웅덩이1" || collision.gameObject.tag == "아직없는물웅덩이2")
        {
            currentCheakTime += Time.deltaTime;
            if (currentCheakTime > loadingCheakTime)
            {
                if (Player.Instance.currentPlayerState == Player.PlayerState.Idle)
                {
                    isLoadable = true;
                    switch (collision.gameObject.tag)
                    {
                        case "dfs":
                            break;
                    }
                    ReLoading();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCheakTime = 0;
        isLoadable = false;
    }
}
