using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public abstract class Sound : ScriptableObject
{
    public new string name;
    public AudioClip clip;
    [Range(0.0f, 1.0f)]
    public float volume = 1;
    [HideInInspector]
    public AudioSource source;
}
