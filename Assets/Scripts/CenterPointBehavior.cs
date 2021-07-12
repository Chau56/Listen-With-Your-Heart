using UnityEngine;

public class CenterPointBehavior : MonoBehaviour
{
    [SerializeField]
    private GameEvents events;
    private void Awake()
    {
        gameObject.SetActive(false);
        events.GamePause += () => gameObject.SetActive(true);
        events.GameResume += () => gameObject.SetActive(false);
    }
}
