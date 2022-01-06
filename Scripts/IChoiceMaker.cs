using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChoiceMaker
{
    public int ChoiceValue { get; }
    public int DetermineChoice();
}
