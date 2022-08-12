using UnityEngine;

[System.Serializable]
public class TwoPointsRange
{
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;

    public Vector2 GetPointInRange() {
        return pointA + Random.Range(0f, 1f) * (pointB - pointA);
    }
}