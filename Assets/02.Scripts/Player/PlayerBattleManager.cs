using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : MonoBehaviour
{
    [Header("Battle key Bindings")]
    [SerializeField] private KeyCode attackKey;  // ����Ű
    [SerializeField] private KeyCode changeKey;  // źâ ����Ű

    [Header("ReLoading")]
    [SerializeField] int loadingCheakTime = 3;
    private float currentCheakTime;
    private bool isLoadable;

    // component
    private Bomb bomb;
    private Water water;
    private Getling getling;


    /// <summary>
    /// ������ üũ �� �����ΰ� �װ� üũ�ϴ°� �����ߴ�. ��ȹ�� �̵� �ѹ� �� �ٽ� �о����
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

    // źâ ����
    private void WeaponLoading()
    {
        if (Input.GetKeyDown(changeKey))
        {
            Player.WeaponType mainWeapon = Player.Instance.mainWeaponType;
            Player.Instance.mainWeaponType = Player.Instance.subWeaponType;
            Player.Instance.subWeaponType = mainWeapon;
        }
    }

    // ���� ����
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

    // ������ ���� (źâüũ -> ����)
    private void LoadingCall(string loadingType)
    {
        switch (loadingType)
        {
            case "Bomb������":
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
                break;
            case "Water������":
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
                break;
            case "Getling������":
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
                break;
            default:
                Debug.Log("������� �ȵǾ��");
                break;
        }
    }

    // ������ ���� ���� üũ
    // �ӵ��� 0�̰� �������̿� loadingCheakTime �̻� �־��� ��
    // ���� � ������������ üũ�ϰ� źâ ��ȯ�ϴ°� �߰� �ʿ�
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "��ź������" ||       // TODO : ���Ķ�
            collision.gameObject.tag == "���ѿ�����" ||
            collision.gameObject.tag == "��Ʋ��������")
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
