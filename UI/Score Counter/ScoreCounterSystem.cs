using UnityEngine;

public class ScoreCounterSystem
{
    private Player player;

    public ScoreCounterSystem(Player player)
    {
        this.player = player;
    }

    public int GetScore()
    {
        var score = 0.0f;
        score += player.Movement.TotalDistance * 10;
        return Mathf.RoundToInt(score);
    }
}
