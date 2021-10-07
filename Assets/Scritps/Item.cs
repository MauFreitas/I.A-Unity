
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Collider _collider = null;

    [SerializeField]
    private Transform _transform = null;
    public Transform MyTransform
    {
        get
        {
            return _transform;
        }
    }
    [SerializeField]
    private Transform _deliverPoint = null;
    public Transform DeliverPoint
    {
        get
        {
            return _deliverPoint;
        }
    }
    [SerializeField]
    private Transform _leavePoint = null;
    public Transform LeavePoint
    {
        get
        {
            return _leavePoint;
        }
    }
    public Personagem personagem = null;
    public bool HasParent
    {
        get
        {
            return (_transform.parent != null && personagem != null);
        }
    }
    public void SetNewParent(Transform newParent)
    {
        _collider.enabled = false;
        _transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }
    public void Leave(bool justLeave)
    {
        personagem = null;
        _transform.SetParent(null);
        _collider.enabled = true;

        if (justLeave)
        {
            Vector3 pos = _transform.position;
            pos += Random.insideUnitSphere * 2;
            pos.y = 0.56f;

            transform.position = pos;
            return;
        }
        if (IsSafe())
        {
            _transform.localPosition = _deliverPoint.position;
        }
        else
        {
            _transform.localPosition = _leavePoint.position;
        }
    }
    public bool IsSafe()
    {
        return Vector3.Distance(_transform.position, _deliverPoint.position) <= 5.0f;
    }
    public bool CanLeave()
    {
        return Vector3.Distance(_transform.position, _leavePoint.position) <= 3.0f;
    }
}
