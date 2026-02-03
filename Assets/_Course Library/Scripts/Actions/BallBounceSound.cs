using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    public AudioClip bounceClip;
    public float minVolume = 0.1f;
    public float maxVolume = 1.0f;
    public float maxSpeed = 10f;

    private AudioSource audioSource;
    private Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 바닥에만 반응하고 싶으면 태그 체크
        // if (!collision.gameObject.CompareTag("Ground")) return;

        float speed = collision.relativeVelocity.magnitude;

        float volume = Mathf.Clamp01(speed / maxSpeed);
        volume = Mathf.Lerp(minVolume, maxVolume, volume);

        audioSource.PlayOneShot(bounceClip, volume);
    }
}
