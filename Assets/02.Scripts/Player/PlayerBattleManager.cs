using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{
    [Header("Battle key Bindings")]
    [SerializeField] private KeyCode attackKey;  // 공격키
    [SerializeField] private KeyCode changeKey;  // 탄창 변경키

    [Header("ReLoading")]
    [SerializeField] int loadingCheakTime = 3;
    private float currentCheakTime;
    private bool isLoadable;

    // component
    private Weapon gun;

    /// <summary>
    /// 재장전 체크 뭔 웅덩인가 그거 체크하는거 만들어야댐. 기획서 이따 한번 쫙 다시 읽어봐라
    /// </summary>

    private void Start()
    {
        gun = GetComponent<Weapon>();
    }

    private void Update()
    {
        WeaponLoading();
        AttackCall();
    }

    // 탄창 변경
    private void WeaponLoading()
    {
        if (Input.GetKeyDown(changeKey))
        {
            Player.WeaponType mainWeapon = Player.Instance.mainWeaponType;
            Player.Instance.mainWeaponType = Player.Instance.subWeaponType;
            Player.Instance.subWeaponType = mainWeapon;
        }
    }

    // 공격 명령
    private void AttackCall()
    {
        if (Input.GetKey(attackKey)) 
        {
            switch (Player.Instance.mainWeaponType)
            {
                case Player.WeaponType.Bomb:
                    gun.Attack();
                    break;
                case Player.WeaponType.Water:
                    // 무기 클래스의 공격 호출(아직없음)
                    break;
                case Player.WeaponType.Getling:
                    // 무기 클래스의 공격 호출(아직없음)
                    break;
                default:
                    break;
            }
        };
    }

    // 재장전 명령
    private void LoadingCall(string loadingType)
    {
        switch (loadingType)
        {
            case "폭탄웅덩이":
                if (Player.Instance.mainWeaponType != Player.WeaponType.Bomb)
                {
                    // 메인탄창(무기탄약)을 0으로 초기화하고
                    Player.Instance.mainWeaponType = Player.WeaponType.Bomb;
                    // 폭탄의 장전 호출
                }
                // 폭탄 무기 클래스의 장전 호출
                break;
            case "물총웅덩이":
                if (Player.Instance.mainWeaponType != Player.WeaponType.Water)
                {
                    // 메인탄창(무기탄약)을 0으로 초기화하고
                    Player.Instance.mainWeaponType = Player.WeaponType.Water;
                    // 물총의 장전 호출
                }
                // 물총 무기 클래스의 장전 호출
                break;
            case "게틀링웅덩이":
                if (Player.Instance.mainWeaponType != Player.WeaponType.Getling)
                {
                    // 메인탄창(무기탄약)을 0으로 초기화하고
                    Player.Instance.mainWeaponType = Player.WeaponType.Getling;
                    // 게틀링의 장전 호출
                }
                // 게틀링 무기 클래스의 장전 호출           
                break;
            default:
                Debug.Log("여기오면 안되어용");
                break;
        }

        switch (Player.Instance.mainWeaponType)
        {
            case Player.WeaponType.Bomb:
                // 무기 클래스의 재장전 호출
                break;
            case Player.WeaponType.Water:
                // 무기 클래스의 재장전 호출
                break;
            case Player.WeaponType.Getling:
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
        if(collision.gameObject.tag == "폭탄웅덩이" ||       // TODO : 고쳐라
            collision.gameObject.tag == "물총웅덩이" ||
            collision.gameObject.tag == "게틀링웅덩이")
        {
            currentCheakTime += Time.deltaTime;
            if (currentCheakTime >= loadingCheakTime)
            {
                if (Player.Instance.currentPlayerState == Player.PlayerState.Idle)
                {
                    isLoadable = true;
                    
                    LoadingCall(collision.gameObject.tag);
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
