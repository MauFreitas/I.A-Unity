using UnityEngine;

public class Attack : State
{
    private Inimigo _inimigo = null;
    private const float _attackTime = 3.0f;
    private float _time = 0.0f;

    public Attack(Personagem personagem)
    {
        this.personagem = personagem;
        _inimigo = personagem.GetComponent<Inimigo>();
    }

    public override void EnterState()
    {
        _time = 0.0f;
        _inimigo.damageArea.Active();

        personagem.agent.isStopped = true;
    }
    public override void Action()
    {
        _time += Time.deltaTime;
        if(_time >= _attackTime)
        {
            personagem.ChangeState(EState.Follow);
        }
    }
    public override void ExitState()
    {
        personagem.agent.isStopped = false;
    }
    public override void TriggerAction(EStateTrigger trigger)
    {
     
    }
}
