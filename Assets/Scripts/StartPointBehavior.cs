using UnityEngine;

public class StartPointBehavior : MonoBehaviour
{
    [SerializeField]
    private GameEvents events;
    private void Awake()
    {
        events.GamePause += () => gameObject.SetActive(false);
        events.GameResume += () => gameObject.SetActive(true);
    }
}
