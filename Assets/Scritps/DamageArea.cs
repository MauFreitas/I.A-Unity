using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField]
    private Personagem _personagem = null;

    public void Active()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Personagem otherPersonagem))
        {
            otherPersonagem.TakeDamage(_personagem.damage);
            gameObject.SetActive(false);
        }
    }
}
