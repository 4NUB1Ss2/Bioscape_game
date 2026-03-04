using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notepad : MonoBehaviour
{ 
    // Start is called before the first frame update
    
    [Header("Notepad UI")]
    [SerializeField] GameObject notepadScreen;
    [SerializeField] GameObject cellphoneScreen;
    
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
