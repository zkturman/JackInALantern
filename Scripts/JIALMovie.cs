using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIALMovie
{
    private MoviePlatform platform = MoviePlatform.Netflix;
    public string Name { get; private set; }

    public string Url { get; private set; }
    private HashSet<int> movieScores = new HashSet<int>();
    public HashSet<int> MovieScores
    {
        get => movieScores;
        set => movieScores = value;
    }

    public JIALMovie(string movieName, string movieURL)
    {
        Name = movieName;
        Url = movieURL;
    }

    public string GetPlatform()
    {
        return platform.ToString();
    }

    public void SetMovieScores(List<int> scores)
    {
        foreach(int x in scores)
        {
            AddMovieScore(x);
        }
    }

    public void AddMovieScore(int score)
    {
        if (!movieScores.Contains(score))
        {
            movieScores.Add(score);
        }
    }

    public bool MatchesScore(int value)
    {
        return movieScores.Contains(value);
    }

    public void PrintScores()
    {
        string returnString = "The scores are ";
        foreach(int x in movieScores)
        {
            returnString += x + ",";
        }
        Debug.Log(returnString);
    }
}
