using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISearchCharacter
{
    public GameObject SearchTool { get; set; }
    public void ToggleSearchAction();
}
