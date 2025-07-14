using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;

    private AudioSource audioSource;
    private float stepTimer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval && !audioSource.isPlaying)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
