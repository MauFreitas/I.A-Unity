using UnityEngine;

public class Death : State
{
    private Rigidbody _rigidbody = null;
    private const float _deathTime = 5.0f;
    private float _time = 0.0f;
    public Death(Personagem personagem)
    {
        this.personagem = personagem;
        _rigidbody = personagem.GetComponent<Rigidbody>();
        
    }
    public override void Action()
    {
        _time += Time.deltaTime;
        if(_time >= _deathTime)
        {
            GameObject.Destroy(personagem.gameObject);
        }

    }
    public override void EnterState()
    {
        if(personagem.Item != null)
        {
            personagem.haveLoot = true;
            personagem.LeaveItem(true);
        }
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.MoveRotation(Quaternion.Euler(0.0f, 0.0f, 0.0f));
        personagem.agent.enabled = false;
    }
    public override void ExitState()
    {

    }
    public override void TriggerAction(EStateTrigger trigger)
    {

    }
    
}
