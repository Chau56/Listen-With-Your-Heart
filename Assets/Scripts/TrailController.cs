using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class TrailController : SwitchBehavior
{
    private TrailRenderer trail;

    // Start is called before the first frame update
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
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
        events.GameEnd += Die;
    }

    private void Die()
    {
        trail.enabled = false;
    }

    private void Revive()
    {
        trail.enabled = true;
    }
}
