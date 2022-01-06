using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKeyBehaviour : MonoBehaviour, ICollidable
{
    [SerializeField] private AudioSource collectSound;
    private Animator keyAnimator;
    
    private void Awake()
    {
        keyAnimator = GetComponentInChildren<Animator>();
    }

    public void StartCollision()
    {
        StartCoroutine(collectItem());
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        PlayerInteraction player = FindObjectOfType<PlayerInteraction>();
        player.AddKey();
    }

    public void UpdateThisStats()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator collectItem()
    {
        UpdateOtherStats(FindObjectOfType<PlayerInteraction>().gameObject);
        keyAnimator.Play("Disappear");
        collectSound.Play();
        yield return new WaitForSeconds(0.75f);
        UpdateThisStats();
    }
}
