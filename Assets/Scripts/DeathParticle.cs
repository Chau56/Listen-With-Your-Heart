using UnityEngine;

[RequireComponent(typeof(DeathLogic))]
public class DeathParticle : MonoBehaviour
{
    private DeathLogic logic;
    [SerializeField]
    private GameObject dieParticle;

    private void Start()
    {
        logic = GetComponent<DeathLogic>();
        logic.OnDied += StartParticle;
    }
    private void StartParticle()
    {
        Debug.Log(nameof(StartParticle));
        Instantiate(dieParticle, transform.position, new Quaternion());
    }
}
