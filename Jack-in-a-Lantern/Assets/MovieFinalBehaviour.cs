using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovieFinalBehaviour : MonoBehaviour
{
    [SerializeField] private int movieChoiceId;
    private TextMeshProUGUI textField;

    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
        textField.text = MovieSelection.GetFinalMovie(movieChoiceId);
    }
}
