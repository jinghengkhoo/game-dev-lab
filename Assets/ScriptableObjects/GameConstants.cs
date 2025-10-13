using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // lives
    public int maxLives;

    // Mario's movement
    public int speed;
    public int maxSpeed;
    public int upSpeed;
    public int deathImpulse;

    // Goomba's movement
    public float goombaPatrolTime;
    public float goombaMaxOffset;
}
