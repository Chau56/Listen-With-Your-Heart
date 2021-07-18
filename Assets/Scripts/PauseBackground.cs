///<summary>
///作者：周权
///创建日期：2021-7-13
///最新修改日期：2021-7-15
///</summary>


using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PauseBackground : MonoBehaviour
{
    private GameEvents events;
    private Animator anima;
    // Start is called before the first frame update
    private void Start()
    {
        events = GameEvents.instance;
        anima = GetComponent<Animator>();
        events.GamePause += Pause;
        events.GameResume += Resume;
        events.GameAwake += Resume;
        events.GameWin += Pause;
    }

    private void Pause()
    {
        anima.SetBool("Pause", true);
    }

    private void Resume()
    {
        anima.SetBool("Pause", false);
    }
}
