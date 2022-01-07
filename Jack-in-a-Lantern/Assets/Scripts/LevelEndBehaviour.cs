using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndBehaviour : MonoBehaviour
{
    [SerializeField] private LevelMovieBehaviour movieSelector;
    [SerializeField] private GameObject sceneCurtain;
    private void OnCollisionEnter(Collision collision)
    {
        movieSelector.StoreChoices();
        StartCoroutine(loadNextScene());
    }

    private IEnumerator loadNextScene()
    {
        sceneCurtain.GetComponentInChildren<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ResultScene");
    }
}
