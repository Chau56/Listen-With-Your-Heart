using UnityEngine;

[RequireComponent(typeof(DeathLogic))]
public class DeathParticle : MonoBehaviour
{
    private DeathLogic Logic;
    [SerializeField]
    private GameObject dieParticle;

    private void Start()
    {
        Logic = GetComponent<DeathLogic>();
        Logic.OnDied += StartParticle;
    }
    private void StartParticle()
    {
        Instantiate(dieParticle, transform);
    }
}
