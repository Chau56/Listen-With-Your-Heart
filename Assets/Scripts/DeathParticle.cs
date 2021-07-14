using UnityEngine;

public class DeathParticle : SwitchBehavior
{
    [SerializeField]
    private GameObject dieParticle;
    [SerializeField]
    private ParticleSystem reviveParticle;

    private void Start()
    {
        Swicher(() =>
        {
            events.BlackDying += Die;
            events.BlackReviving += Revive;
        }, () =>
        {
            events.WhiteDying += Die;
            events.WhiteReviving += Revive;
        });
        events.GameAwake += Revive;
    }

    private void Die()
    {
        Debug.Log("die paiticle init");
        reviveParticle.Stop();
        reviveParticle.Clear();
        Instantiate(dieParticle, transform.position, new Quaternion());
    }

    private void Revive()
    {
        Debug.Log("revive particle init");
        reviveParticle.Play();
    }
}
