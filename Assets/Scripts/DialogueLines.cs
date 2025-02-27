using UnityEngine;
using TMPro;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] TimelineTextlines;

    int currentLine = 0;

    void NextDialogueLine()
    {
        currentLine++;
        if (currentLine < TimelineTextlines.Length)
        {
            dialogueText.text = TimelineTextlines[currentLine];
        }
        else
        {
            currentLine = 0;
            dialogueText.text = TimelineTextlines[currentLine];
        }
    }

    void Start()
    {
        dialogueText.text = TimelineTextlines[currentLine];
    }

    
}
