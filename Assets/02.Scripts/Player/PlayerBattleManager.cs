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
    public bool isLoadable;

    // component
    private Bomb bomb;
    private Water water;
    private Getling getling;


    /// <summary>
    /// 재장전 체크 뭔 웅덩인가 그거 체크하는거 만들어야댐. 기획서 이따 한번 쫙 다시 읽어봐라
    /// </summary>

    private void Start()
    {
        bomb = GetComponent<Bomb>();
        water = GetComponent<Water>();
        getling = GetComponent<Getling>();
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
                    bomb.Attack();
                    break;
                case Player.WeaponType.Water:
                    water.Attack();
                    break;
                case Player.WeaponType.Getling:
                    getling.Attack();
                    break;
                default:
                    break;
            }
        };
    }

    // 재장전 명령 (탄창체크 -> 장전)
    private void LoadingCall(PubbleState state)
    {
        switch (state)
        {
            case PubbleState.bomb:
                if (Player.Instance.mainWeaponType != Player.WeaponType.Bomb)
                {
                    if(Player.Instance.mainWeaponType == Player.WeaponType.Water)
                    {
                        water.InitAmmo();
                    }
                    else
                    {
                        getling.InitAmmo();
                    }
                    Player.Instance.mainWeaponType = Player.WeaponType.Bomb;
                }
                bomb.Loading();
                Debug.Log("폭탄 장전");
                break;
            case PubbleState.water:
                if (Player.Instance.mainWeaponType != Player.WeaponType.Water)
                {
                    if (Player.Instance.mainWeaponType == Player.WeaponType.Bomb)
                    {
                        bomb.InitAmmo();
                    }
                    else
                    {
                        getling.InitAmmo();
                    }
                    Player.Instance.mainWeaponType = Player.WeaponType.Water;
                }
                water.Loading();
                Debug.Log("물 장전");
                break;
            case PubbleState.gatling:
                if (Player.Instance.mainWeaponType != Player.WeaponType.Getling)
                {
                    if (Player.Instance.mainWeaponType == Player.WeaponType.Bomb)
                    {
                        bomb.InitAmmo();
                    }
                    else
                    {
                        water.InitAmmo();
                    }
                    Player.Instance.mainWeaponType = Player.WeaponType.Water;
                }
                water.Loading();
                Debug.Log("게틀링 장전");
                break;
            default:
                Debug.Log("여기오면 안되어용");
                break;
        }
    }

    // 재장전 가능 여부 체크
    // 속도가 0이고 물웅덩이에 loadingCheakTime 이상 있었을 때
    // 이제 어떤 물웅덩이인지 체크하고 탄창 변환하는거 추가 필요
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            currentCheakTime += Time.deltaTime;
            if (currentCheakTime >= loadingCheakTime)
            {
                if (Player.Instance.currentPlayerState == Player.PlayerState.Idle)
                {
                    isLoadable = true;
                    LoadingCall(collision.gameObject.GetComponent<PubbleContorl>().state);
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
