using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ConvertTXTtoSequence : MonoBehaviour
{
    public TextAsset textFile;

    [ContextMenu("PrintLines")]
    void Test()
    {
        string[] Lines = textFile.text.Split('\n','\r');
        foreach (var line in Lines)
        {
            Debug.Log(line);
        }
    }
    
}
