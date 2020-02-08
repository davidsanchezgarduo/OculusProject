using UnityEngine;
using UnityEngine.Playables;
public class BossCutscene : MonoBehaviour
{
    public PlayableDirector bossDirector;
    public ThirdPersonController playerController;
    private bool used = false;

    void Start()
    {
        bossDirector.played += StartCutScene;
        bossDirector.stopped += StopCutScene;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && !used)
        {
            bossDirector.Play();
        }
    }

    private void StartCutScene(PlayableDirector director)
    {
        playerController.ActiveController(false);
    }

    private void StopCutScene(PlayableDirector director)
    {
        used = true;
        playerController.ActiveController(true);
    }
}
