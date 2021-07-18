///<summary>
///作者：周权
///创建日期：2021-7-12
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(ParticleSystem))]
public class TrailController : SwitchBehavior
{
    private TrailRenderer trail;
    private ParticleSystem particle;

    // Start is called before the first frame update
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
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
        events.GameAwake += Die;
        events.GameStart += Revive;
        events.GameAbnormalEnd += Die;
    }

    private void Die()
    {
        trail.emitting = false;
        trail.Clear();
        particle.Stop();
    }

    private void Revive()
    {
        trail.Clear();
        trail.emitting = true;
        particle.Play();
    }
}
