using UnityEngine;

public class Follow : State
{
    private Inimigo _inimigo = null;
    private float _time = 0.0f;
    private float _maxFollowTime = 8.0f;

    public Follow(Personagem inimigo)
    {
        this.personagem = inimigo;
        _inimigo = (Inimigo)personagem;
    }
    public override void EnterState()
    {
        personagem.agent.isStopped = false;
        _time = 0.0f;
        SetDestination();
    }
    public override void Action()
    {
        if (!_inimigo.jogador.isAlive)
        {
            if (_inimigo.jogador.haveLoot)
            {
                personagem.ChangeState(EState.Search);
            }
            else
            {
                personagem.ChangeState(EState.Patrol);
            }
            return;
        }
        if (SetDestination())
        {
            return;
        }
        if(personagem.agent.remainingDistance <= 1.25f)
        {
            personagem.ChangeState(EState.Attack);
        }
        _time += Time.deltaTime;
        if(_time < _maxFollowTime)
        {
            return;
        }
        if (personagem.agent.remainingDistance >= 5.0f)
        {
            personagem.ChangeState(EState.Patrol);
        }
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
        }
    }
    public bool SetDestination ()
    {
        if(_inimigo.jogador == null)
        {
            personagem.ChangeState(EState.Patrol);
            return true;
        }
        personagem.agent.SetDestination(_inimigo.jogador.myTransform.position);
        return false;
    }
}
