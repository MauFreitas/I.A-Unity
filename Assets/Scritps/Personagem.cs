using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class Personagem : MonoBehaviour
{
    protected State _currentStete = null;
    public NavMeshAgent agent = null;
    public Transform myTransform = null;

    public ItemCatalog itemCatalog = null;

    public bool isEnemy = false;
    public bool haveLoot = false;

    public EState CurrentState = EState.None;

    public float velocidade = 1.0f;
    public int vida = 1;
    public int damage = 1;

    public bool isAlive
    {
        get
        {
            return vida > 0;
        }
    }
    public Transform collectPoint = null;

    protected Item _targetItem = null;
    public Item TItem
    {
        get
        {
            return _targetItem;
        }
    }
    protected Item _item = null;
    public Item Item
    {
        get
        {
            return _item;
        }
    }
    public abstract void ChangeState(EState state);
    public abstract void PlayTrigger(EStateTrigger trigger);
    public void TargetItem (Item newItem)
    {
        _targetItem = newItem;
    }
    public void CollectItem(Item newItem)
    {
        _item = newItem;
        _item.personagem = this;
    }
    public void LeaveItem(bool justLeave)
    {
        _item.Leave(justLeave);
        _item = null;
    }
    public void TakeDamage(int damage)
    {
        vida -= damage;
        vida = Mathf.Max(vida, 0);

        PlayTrigger(EStateTrigger.TakeDamage);
    }

}
