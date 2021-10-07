using UnityEngine;

public class Patrol : State
{
    private int _pointIndex = 0;
    private Transform[] _points = null;
    public Patrol(Personagem personagem, Transform[] points)
    {
        this.personagem = personagem;
        _points = points;
    }
    public override void EnterState()
    {
        personagem.agent.isStopped = false;
        _pointIndex = 0;
        SetDestination();
    }
    public override void Action()
    {
        ChangeDestination();
        CheckJogadorDistance();
    }
    public override void ExitState()
    {
        personagem.agent.isStopped = true;
    }
    public override void TriggerAction(EStateTrigger trigger)
    {
        switch (trigger)
        {
            case EStateTrigger.FindItem:
                personagem.ChangeState(EState.Collect);
                break;
            case EStateTrigger.GetClose:
                personagem.ChangeState(EState.Follow);
                break;

        }
    }
    private void SetDestination()
    {
        personagem.agent.SetDestination(_points[_pointIndex].position);
    }
    private void ChangeDestination()
    {
        if(personagem.agent.remainingDistance <= personagem.agent.stoppingDistance)
        {
            _pointIndex++;
            if(_pointIndex >= _points.Length)
            {
                _pointIndex = 0;
            }
            SetDestination();
        }
    }
    private void CheckJogadorDistance()
    {
        Inimigo inimigo = (Inimigo)personagem;
        if(inimigo.jogador == null)
        {
            return;
        }
        if(Vector3.Distance(personagem.myTransform.position, inimigo.jogador.myTransform.position)< 2.0f)
        {
            personagem.ChangeState(EState.Follow);
        }
    }
}
