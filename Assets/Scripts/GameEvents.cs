using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action GameFailed;
    [SerializeField]
    private DeathLogic player1;
    private bool p1Dead;
    [SerializeField]
    private DeathLogic player2;
    private bool p2Dead;

    // Start is called before the first frame update
    private void Start()
    {
        player1.OnDied += () => CheckFailed(PlayerEnum.Black);
        player2.OnDied += () => CheckFailed(PlayerEnum.White);
        GameFailed += () => Debug.Log("Game failed.");
    }

    private void CheckFailed(PlayerEnum player)
    {
        switch (player)
        {
            case PlayerEnum.Black:
                p1Dead = true;
                break;
            case PlayerEnum.White:
                p2Dead = true;
                break;
        }
        if (p1Dead && p2Dead)
        {
            GameFailed();
        }
    }
}
