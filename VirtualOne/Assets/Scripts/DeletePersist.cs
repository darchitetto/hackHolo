using UnityEngine;
using UnityEngine.VR.WSA.Persistence;
using UnityEngine.VR.WSA;

public class DeletePersist : MonoBehaviour
{
    bool Placing = false;

    AudioSource audioSource = null;
    AudioClip completedClip = null;

    void Start()
    {
        // Add an AudioSource component and set up some defaults
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Custom;

        // Load the Sphere sounds from the Resources folder
        completedClip = Resources.Load<AudioClip>("PersistDeleted");
    }

    void AnchorStoreReady(WorldAnchorStore store)
    {
        string[] ids = store.GetAllIds();
        for (int index = 0; index < ids.Length; index++)
        {
            Debug.Log(ids[index]);
            bool deleted = store.Delete(ids[index]);
            Debug.Log("deleted: " + deleted);
        }
        audioSource.clip = completedClip;
        audioSource.Play();

    }

    void OnSelect()
    {
        WorldAnchorStore.GetAsync(AnchorStoreReady);

    }
}