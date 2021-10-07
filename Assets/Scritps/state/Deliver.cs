using UnityEngine;

public class Deliver : State
{
    public Deliver(Personagem personagem)
    {
        this.personagem = personagem;
    }
    public override void EnterState()
    {
        personagem.agent.isStopped = false;
        SetDestination();
    }
    public override void Action()
    {
        if (personagem.agent.remainingDistance <= 1.0f)
        {
            personagem.LeaveItem(false);
            if (personagem.isEnemy)
            {
                personagem.ChangeState(EState.Patrol);
            }
            else
            {
                personagem.ChangeState(EState.Search);
            }
        }
    }
    public override void ExitState()
    {
        personagem.agent.isStopped = true;
    }
    public override void TriggerAction(EStateTrigger trigger)
    {

    }
    public void SetDestination()
    {
        if (personagem.isEnemy)
        {
            personagem.agent.SetDestination(personagem.Item.DeliverPoint.position);
        }
        else
        {
            personagem.agent.SetDestination(personagem.Item.LeavePoint.position);
        }
    }
}
