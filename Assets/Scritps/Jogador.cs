
using UnityEngine;

public class Jogador : Personagem
{
    public Vector3 direcao = Vector3.zero;

    private Collect _collect = null;
    private Deliver _deliver = null;
    private Search _search = null;
    private MoveTo _moveTo = null;
    private Death _death = null;

    public void Awake()
    {
        _collect = new Collect(this);
        _deliver = new Deliver(this);
        _search = new Search(this);
        _moveTo = new MoveTo(this);
        _death = new Death(this);

        agent.speed = velocidade;
    }
    public void Start()
    {
        ChangeState(EState.Search);
    }
    public void Update()
    {
        if(_currentStete != null)
        {
            _currentStete.Action();
        }
    }
    public override void ChangeState(EState state)
    {
        if (_currentStete != null)
        {
            _currentStete.ExitState();
        }
        CurrentState = state;

        switch (state)
        {
            case EState.Collect:
                _currentStete = _collect;
                break;
            case EState.Deliver:
                _currentStete = _deliver;
                break;
            case EState.Search:
                _currentStete = _search;
                break;
            case EState.MoveTo:
                _currentStete = _moveTo;
                break;
            case EState.Death:
                _currentStete = _death;
                break;
            default:
                _currentStete = null;
                break;
        }
        if(_currentStete != null)
        {
            _currentStete.EnterState();
        }
    }
    public override void PlayTrigger(EStateTrigger trigger)
    {
        if(trigger == EStateTrigger.TakeDamage)
        {
            if(vida == 0)
            {
                ChangeState(EState.Death);
            }
        }
        else
        {
            if(_currentStete != null)
            {
                _currentStete.TriggerAction(trigger);
            }
        }
    }
}
