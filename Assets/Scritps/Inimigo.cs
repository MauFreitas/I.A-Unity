using UnityEngine;

public class Inimigo : Personagem
{
    private Search _search = null;
    private MoveTo _moveTo = null;
    private Attack _attack = null;
    private Patrol _patrol = null;
    private Follow _follow = null;
    private Collect _collect = null;
    private Deliver _deliver = null;

    public Personagem jogador = null;

    public DamageArea damageArea = null;

    public Transform[] points = null;

    public void Awake()
    {
        _patrol = new Patrol(this, points);
        _follow = new Follow(this);
        _moveTo = new MoveTo(this);
        _search = new Search(this);
        _collect = new Collect(this);
        _deliver = new Deliver(this);
        _attack = new Attack(this);

        agent.speed = velocidade;
    }
    public void Start()
    {
        ChangeState(EState.Patrol);
    }
    public void Update()
    {
        if (_currentStete != null)
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
            case EState.Patrol:
                _currentStete = _patrol;
                break;
            case EState.Follow:
                _currentStete = _follow;
                break;
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
            case EState.Attack:
                _currentStete = _attack;
                break;
            default:
                _currentStete = null;
                break;
        }
        if (_currentStete != null)
        {
            _currentStete.EnterState();
        }
    }
    public override void PlayTrigger(EStateTrigger trigger)
    {
        if(_currentStete != null)
        {
            _currentStete.TriggerAction(trigger);
        }
    }
}
