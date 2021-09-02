using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFov : MonoBehaviour
{

    public float viewRange = 15.0f;
    [Range(0, 360)]
    public float viewAngle = 120.0f;

    public LayerMask layerMask;

    private int interactableLayer;

    [SerializeField]
    private Collider[] colls;

    void Start()
    {
        interactableLayer = LayerMask.NameToLayer("interactable");
        //플레이어 레이어의 번호를 알아온다.
    }
    //반지름 1인 원의 원주에 있는 점의 좌표를 구하는 함수
    public Vector3 CirclePoint(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),
                            0,
                            Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    /// <summary>
    /// 시야범위 안에 오브젝트가 있는가
    /// </summary>
    /// <returns></returns>
    public bool IsObjInFov()
    {
        bool isTrace = false;
        colls = Physics.OverlapSphere(transform.position, viewRange, 1 << interactableLayer);
        if (colls.Length >= 1)
        {

            Vector3 dir = GetDir();

            if (Vector3.Angle(transform.forward, dir) < viewAngle * 0.5f)
            {
                isTrace = true;
            }
        }
        return isTrace;
    }
    private Vector3 GetDir()
    {
        int n = 0;
        while (n < colls.Length)
        {
            if(Vector3.Angle(transform.forward, GetDir(n)) < viewAngle * 0.5f)
            {
                return GetDir(n);
            }
            n++;
        }
        return new Vector3();

    }
    private Vector3 GetDir(int n)
    {
        return (colls[n].transform.position - transform.position).normalized;
    }
    /// <summary>
    /// 오브젝트 사이에 다른 오브젝트가 있는가
    /// </summary>
    /// <returns></returns>
    public bool IsViewObj()
    {
        bool isView = false;
        RaycastHit hit;
        Vector3 dir = GetDir();
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), dir, out hit, viewRange, layerMask))
        {
            isView = (hit.collider.gameObject.CompareTag("interactable"));
        }
        return isView;
    }

    /// <summary>
    /// 시야에 있는 오브젝트 정보
    /// </summary>
    /// <returns></returns>
    public InteractableObject GetObjInview()
    {
        RaycastHit hit;
        Vector3 dir = GetDir();
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), dir, out hit, viewRange, layerMask))
        {
            return hit.collider.GetComponent<InteractableObject>();
        }
        else
        {
            return null;
        }
    }
}
