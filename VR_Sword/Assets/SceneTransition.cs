using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneTransition : MonoBehaviour
{
    public GameObject scenevideoPrefab; 
    private VideoPlayer videoPlayer;
    public OVRCameraRig overCameraRig; 
    private Vector3 spawnPosition;

    void Start()
    {
        
        spawnPosition = scenevideoPrefab.transform.position; 
    }

    public void GoToScene(int sceneIndex)
    {
        GameObject scenevideo = Instantiate(scenevideoPrefab, spawnPosition, overCameraRig.centerEyeAnchor.rotation);
        videoPlayer = scenevideo.GetComponent<VideoPlayer>();
        
        StartCoroutine(WaitForVideo(sceneIndex));
    }

    private IEnumerator WaitForVideo(int sceneIndex)
    {
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    // Update method if needed
    void Update() { }
}
