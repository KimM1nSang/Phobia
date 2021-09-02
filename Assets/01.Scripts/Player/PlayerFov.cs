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
        //�÷��̾� ���̾��� ��ȣ�� �˾ƿ´�.
    }
    //������ 1�� ���� ���ֿ� �ִ� ���� ��ǥ�� ���ϴ� �Լ�
    public Vector3 CirclePoint(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad),
                            0,
                            Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    /// <summary>
    /// �þ߹��� �ȿ� ������Ʈ�� �ִ°�
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
    /// ������Ʈ ���̿� �ٸ� ������Ʈ�� �ִ°�
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
