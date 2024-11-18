using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] sentences;

    [System.Serializable]
    public class choice
    {
        public string choiceText;
        public string[] resultingLines;
    }

    public choice[] choices;
}
