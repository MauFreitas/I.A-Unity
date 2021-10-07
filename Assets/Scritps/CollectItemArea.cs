using UnityEngine;

public class CollectItemArea : MonoBehaviour
{
    [SerializeField]
    private Personagem _personagem = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item item))
        {
            if(item.MyTransform.parent != null)
            {
                return;
            }
            if (_personagem.CurrentState != EState.MoveTo)
        {
            return;
        }
        if (_personagem.Item == null)
        {
            if((_personagem.isEnemy&&!item.IsSafe())||
                (!_personagem.isEnemy && !item.CanLeave()))
            {
                _personagem.CollectItem(item);
                _personagem.PlayTrigger(EStateTrigger.FindItem);
            }
        }
        
        }
    }
}
