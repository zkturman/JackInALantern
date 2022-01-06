using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovieBehaviour : MonoBehaviour
{
    private JIALMovie movieOption1;
    private JIALMovie movieOption2;
    private JIALMovie movieOption3;
    private JIALMovie movieOption4;
    [SerializeField] private List<MonoBehaviour> pair1Choices = new List<MonoBehaviour>();
    [SerializeField] private List<MonoBehaviour> pair2Choices = new List<MonoBehaviour>();

    private int[] pair1values = new int[2] { 2, 3 };
    private int[] pair2values = new int[2] { 2, 2 };

    private void Awake()
    {
        movieOption1 = new JIALMovie("Candyman", null);
        movieOption2 = new JIALMovie("Hush", null);
        movieOption3 = new JIALMovie("The Strangers", null);
        movieOption4 = new JIALMovie("The Blair Witch Project", null);
        MovieSelection.AddMoviePair(movieOption2, movieOption3);
        MovieSelection.AddMoviePair(movieOption1, movieOption4);
        List<int> pair1Scores = MovieSelection.GenerateScores(new List<int>(pair1values));
        MovieSelection.DetermineScores(pair1Scores, 0);
        List<int> pair2Scores = MovieSelection.GenerateScores(new List<int>(pair2values));
        MovieSelection.DetermineScores(pair2Scores, 1);

        movieOption1.PrintScores();
        movieOption2.PrintScores();
        movieOption3.PrintScores();
        movieOption4.PrintScores();
    }

    public void StoreChoices()
    {
        MovieSelection.MakeDecision(0, getProduct(pair1Choices));
        MovieSelection.MakeDecision(1, getProduct(pair2Choices));
    }

    private int getProduct(List<MonoBehaviour> choices)
    {
        int product = 1;
        foreach(MonoBehaviour choice in choices)
        {
            product *= ((IChoiceMaker)choice).ChoiceValue;
        }
        return product;
    }
}
