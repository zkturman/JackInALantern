using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMaskBehaviour : MonoBehaviour, ICollidable, IChoice
{
    [SerializeField] private int maskId;
    public int MaskId { get => maskId; }
    [SerializeField] private int choiceId;
    public int ChoiceId { get => choiceId; }
    public bool isActive = false;
    [SerializeField] private AudioSource collisionSound;
    public void ActivateMask()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    public void UpdateThisStats()
    {
        gameObject.SetActive(false);
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        statsToChange.GetComponent<PlayerInteraction>().AddMask();
    }

    public void StartCollision()
    {
        PlayerInteraction player = FindObjectOfType<PlayerInteraction>();
        player.GetComponentInChildren<RotatingMaskBehaviour>().ActivateMask(MaskId);
        UpdateThisStats();
        UpdateOtherStats(player.gameObject);
        AudioSource.PlayClipAtPoint(collisionSound.clip, this.transform.position);
    }
}
