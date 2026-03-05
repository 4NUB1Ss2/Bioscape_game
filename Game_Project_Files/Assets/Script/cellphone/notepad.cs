using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class notepad : MonoBehaviour
{ 
    // Start is called before the first frame update
    
    [Header("Notepad UI")]
    [SerializeField] GameObject notepadScreen;
    [SerializeField] GameObject cellphoneScreen;
    [SerializeField] TMP_InputField titleInputField;
    [SerializeField] TMP_InputField bodyInputField;
    
    private Note currentNote;
    
    void Start()
    {
        if (notepadScreen != null)
        {
            notepadScreen.SetActive(false);
            cellphoneScreen.SetActive(true);
        }
        
    }

    public void OpenNotepad()
    {
        if (notepadScreen != null) ;
        {
            notepadScreen.SetActive(true);
            cellphoneScreen.SetActive(false);
            notepadScreen.transform.SetAsFirstSibling();
        }
    }

    public void SaveNote()
    {
        string title = titleInputField.text;
        string body = bodyInputField.text;

        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(body))
        {
            Debug.LogWarning("Não é possivel salvar uma nota vazia");
            return;
        }

        if (string.IsNullOrEmpty(title))
        {
            title = "sem titulo";
        }
        
        NotesManager.Instance.AddNote(title, body);
        Debug.Log("nota salva");
        
        titleInputField.text = "";
        bodyInputField.text = "";
        
    }

    public void CloseNotepad()
    {
        if (notepadScreen != null)
        {
            notepadScreen.SetActive(false);
            cellphoneScreen.SetActive(true);
        }
    }

    public void toggleNotepad()
    {
        if (notepadScreen != null)
        {
            notepadScreen.SetActive(!notepadScreen.activeSelf);
            cellphoneScreen.SetActive(!cellphoneScreen.activeSelf);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
