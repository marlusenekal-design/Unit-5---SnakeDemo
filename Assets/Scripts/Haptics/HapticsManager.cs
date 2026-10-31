using UnityEngine;

public class HapticsManager : MonoBehaviour
{
    public SnakeEating snakeEating;
    public SnakeCollision snakeCollision;
    public long eatVibrationMs = 40;
    public long deathVibrationMs = 400;

    void OnEnable()
    {
        snakeEating.OnAteFood += HandleAteFood;
        snakeCollision.OnDied += HandleDied;
    }

    void OnDisable()
    {
        snakeEating.OnAteFood -= HandleAteFood;
        snakeCollision.OnDied -= HandleDied;
    }

    void HandleAteFood()
    {
        AndroidVibration.Vibrate(eatVibrationMs);
    }

    void HandleDied()
    {
        AndroidVibration.Vibrate(deathVibrationMs);
    }
}