using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public int Path { get; private set; }
    public int QuestionId { get; private set; }
    internal void SetQuestion(Question current)
    {
        Path = current.StroyPathId;
        QuestionId = current.Id;
    }
}
