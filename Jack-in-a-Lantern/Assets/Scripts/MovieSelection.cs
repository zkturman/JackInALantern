using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovieSelection
{
    private static List<JIALMovie[]> movieChoices = new List<JIALMovie[]>();
    private static List<JIALMovie> selectedMovies = new List<JIALMovie>();
    public static void AddMoviePair(JIALMovie firstMovie, JIALMovie secondMovie)
    {
        checkNull(firstMovie);
        checkNull(secondMovie);
        JIALMovie[] movieChoice = new JIALMovie[2];
        movieChoice[0] = firstMovie;
        movieChoice[1] = secondMovie;
        movieChoices.Add(movieChoice);
    }

    private static void checkNull(object objectToCheck)
    {
        if (objectToCheck == null)
        {
            throw new System.Exception("Cannot evaluate null object.");
        }
    }

    public static List<int> GenerateScores(List<int> totalOptions)
    {
        List<int> startingPerm = getAllValues(totalOptions[0]);
        List<int> remainingValues = new List<int>();
        if (totalOptions.Count > 1)
        {
            remainingValues = totalOptions.GetRange(1, totalOptions.Count - 1);
        }
        return generateScores(startingPerm, remainingValues);
    }

    private static List<int> generateScores(List<int> startingPerm, List<int> remainingValues)
    {
        List<int> values = new List<int>();
        if (remainingValues == null || remainingValues.Count == 0) 
        {
            for (int i = 0; i < startingPerm.Count; i++)
            {
                values.Add(startingPerm[i]);
            }    
        }
        else
        {
            List<int> nextPerm = getAllValues(remainingValues[0]);
            List<int> products = new List<int>();
            for (int i = 0; i < startingPerm.Count; i++)
            {
                for (int j = 0; j < nextPerm.Count; j++)
                {
                    products.Add(startingPerm[i] * nextPerm[j]);
                }
            }
            values = generateScores(products, remainingValues.GetRange(1, remainingValues.Count - 1));
        }
        return values;
    }

    private static List<int> getAllValues(int x)
    {
        List<int> possibleValues = new List<int>();
        for (int i = 1; i <= x; i++)
        {
            possibleValues.Add(i);
        }
        return possibleValues;
    }

    public static void DetermineScores(List<int> possibleScores, int moviePairId)
    {
        int movieScoreQuantity = possibleScores.Count / 2;
        JIALMovie movie1 = movieChoices[moviePairId][0];
        JIALMovie movie2 = movieChoices[moviePairId][1];
        for (int i = 0; i < movieScoreQuantity; i++)
        {
            int diceRoll = Random.Range(0, possibleScores.Count);
            movie1.AddMovieScore(possibleScores[diceRoll]);
            possibleScores.RemoveAt(diceRoll);
        }
        movieScoreQuantity = possibleScores.Count;
        for (int i = 0; i < movieScoreQuantity; i++)
        {
            int diceRoll = Random.Range(0, possibleScores.Count);
            movie2.AddMovieScore(possibleScores[diceRoll]);
            possibleScores.RemoveAt(diceRoll);
        }
    }

    public static void MakeDecision(int pairIndex, int key)
    {
        JIALMovie[] moviePair = movieChoices[pairIndex];
        if (moviePair[0].MatchesScore(key))
        {
            selectedMovies.Add(moviePair[0]);
        }
        else
        {
            selectedMovies.Add(moviePair[1]);
        }
        Debug.Log("A selected key is " + key);
    }

    public static string GetFinalMovie(int choiceIndex)
    {
        return selectedMovies[choiceIndex].Name;
    }
}
