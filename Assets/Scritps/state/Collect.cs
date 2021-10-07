using UnityEngine;

public class Collect : State
{
    public Collect(Personagem personagem)
    {
        this.personagem = personagem;
    }
    public override void Action()
    {
        
    }
    public override void EnterState()
    {
        personagem.Item.SetNewParent(personagem.collectPoint);
        personagem.ChangeState(EState.Deliver);
    }
    public override void ExitState()
    {
        
    }
    public override void TriggerAction(EStateTrigger trigger)
    {
        
    }
}
