using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour
{
    public Transform player;           // PlayerCapsule
    public Transform goal;             // LevelEndTrigger
    public Slider progressBar;         // UI Slider

    private float maxDistance;

    void Start()
    {
        maxDistance = Vector3.Distance(player.position, goal.position);
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(player.position, goal.position);
        float progress = Mathf.Clamp01(1 - (currentDistance / maxDistance));
        progressBar.value = progress;
    }
}
