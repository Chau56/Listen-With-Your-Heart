///<summary>
///作者：周权
///创建日期：2021-7-21
///最新修改日期：2021-7-21
///</summary>


using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WinSound : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var sound = GetComponent<AudioSource>();
        var events = GameEvents.instance;
        events.GameWin += sound.Play;
        events.GameBeforeAwake += sound.Stop;
    }
}
