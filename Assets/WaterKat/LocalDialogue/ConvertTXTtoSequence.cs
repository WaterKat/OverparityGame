using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using WaterKat.Dialogue;
using UnityEditor;

public class ConvertTXTtoSequence : MonoBehaviour
{
    public TextAsset textFile;
    public string characterInfoPath = "Assets / TESTING / Dialogue / CharacterObjects /";
    public string outputDialogueSequencePath = "Assets / TESTING / Dialogue / OutputSequences /";


    [ContextMenu("PrintLines")]
    List<string> LinesFromTextFile()
    {
        string[] Lines = textFile.text.Split('\n','\r');
        List<string> TextLines = new List<string>();
        foreach (var line in Lines)
        {
            if (line.Length > 0)
            {
                TextLines.Add(line);
            }
        }
        return TextLines;
    }

    string[] ConvertLineToCharDialogueArray(string inputLine)
    {
        string[] Lines = inputLine.Split(':');
        if (Lines.Length > 2)
        {
            Debug.LogError("Colon used in DialogueText!");
        }
        return new string[] { Lines[0], Lines[1].Substring(1) };
    } 

    List<DialogueCharacterInfo> LoadCharacterInfoAssetsFromPath(string path)
    {
        List<DialogueCharacterInfo> characterInfos = new List<DialogueCharacterInfo>();
        string[] guids = AssetDatabase.FindAssets("", new[] { path });
        foreach (var guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            characterInfos.Add(AssetDatabase.LoadAssetAtPath(assetPath,typeof(DialogueCharacterInfo)) as DialogueCharacterInfo);
        }
        /*
        List<DialogueCharacterInfo> usableAssets = new List<DialogueCharacterInfo>();

        Debug.Log(assetArray.Length);
        foreach (var asset in assetArray)
        {
            Debug.Log("Asset:" + asset.name);
            if (asset is DialogueCharacterInfo)
            {
                usableAssets.Add(asset as DialogueCharacterInfo);
            }
        }
        */
        return characterInfos;
    }

    DialogueSequence SequenceFromLines()
    {
        DialogueSequence dialogueSequence = ScriptableObject.CreateInstance<DialogueSequence>();
        dialogueSequence.Dialogue = new List<DialogueInfo>();

        List<string> DialogueLines = LinesFromTextFile();

        Dictionary<string, DialogueCharacterInfo> characterDictionary = new Dictionary<string, DialogueCharacterInfo>();

        List<DialogueCharacterInfo> characterInfos = LoadCharacterInfoAssetsFromPath(characterInfoPath);


        Debug.Log("Lines in dialogue:" + DialogueLines.Count);
        foreach (var line in DialogueLines)
        {
            DialogueCharacterInfo dialogueCharacterInfo = null;
            string[] stringPair = ConvertLineToCharDialogueArray(line);
            if (characterDictionary.ContainsKey(stringPair[0]))
            {
                dialogueCharacterInfo = characterDictionary[stringPair[0]];
            }
            else
            {
                foreach (var character in characterInfos)
                {
                    Debug.Log(character.name);
                    if (character.name == stringPair[0])
                    {
                        characterDictionary.Add(stringPair[0], character);
                        dialogueCharacterInfo = characterDictionary[stringPair[0]];
                        break;
                    }
                }
                if (dialogueCharacterInfo == null)
                {
                    Debug.LogError("NO CHARACTER FOUND: " + stringPair[0]);
                    continue;
                }
            }
            if (dialogueCharacterInfo != null)
            {
                DialogueInfo dialogueInfo = new DialogueInfo();
                dialogueInfo.character = dialogueCharacterInfo;
                dialogueInfo.dialogue= stringPair[1];
                dialogueSequence.name = "test";
                dialogueSequence.Dialogue.Add(dialogueInfo);
            }
            else
            {
                Debug.Log("dialogueCharacter is null");
            }
        }
        return dialogueSequence;
    }

    [ContextMenu("Process Text")]
    void ProcessTextFile()
    {
        DialogueSequence sequence = SequenceFromLines();
        sequence.name = textFile.name;
        AssetDatabase.CreateAsset(sequence, outputDialogueSequencePath + sequence.name + ".asset");
    }
    
}
