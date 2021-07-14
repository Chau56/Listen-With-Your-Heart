using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class TrailParticleCOntroller : SwitchBehavior
{
    private ParticleSystem particle;

    // Start is called before the first frame update
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        Swicher(() =>
        {
            events.BlackDying += Die;
            events.BlackReviving += Revive;
        }, () =>
        {
            events.WhiteDying += Die;
            events.WhiteReviving += Revive;
        });
        events.GameStart += Revive;
        events.GameAbnormalEnd += Die;
    }

    private void Die()
    {
        particle.Stop();
    }

    private void Revive()
    {
        particle.Play();
    }
}
