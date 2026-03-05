using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NotesManager : MonoBehaviour
{
    private static NotesManager instance;
    public static NotesManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NotesManager>();
            }
            return instance;
        }
    }
    
    private NoteList notesList = new NoteList();

    private string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "notes.json");
        string directory = Path.GetDirectoryName(savePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("pasta criada");
        }
        
        LoadNotes();
        Debug.Log($"As notas serão salvas em: {savePath}");
    }

    public void SaveNotes()
    {
        string json = JsonUtility.ToJson(notesList,  true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Notes salvas total: {notesList.notes.Count}");
    }

    public void LoadNotes()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            notesList = JsonUtility.FromJson<NoteList>(json);
            Debug.Log($"Notes carregadas total: {notesList.notes.Count}");
        }
        else
        {
            Debug.Log("Nenhum arquivo encontrado. Criando Nova lista");
        }
    }

    public Note AddNote(string title, string body)
    {
        Note newNote = new Note(title, body);
        notesList.notes.Add(newNote);
        SaveNotes();
        return newNote;
    }

    public void UpdateNote(string noteId, string newTitle, string newBody)
    {
        Note note = notesList.notes.Find(n => n.id == noteId);

        if (note != null)
        {
            note.title = newTitle;
            note.body = newBody;
            SaveNotes();
            Debug.Log("Nota Atualizada");
        }
    }

    public void DeleteNote(string noteId)
    {
        notesList.notes.RemoveAll(n => n.id == noteId);
        SaveNotes();
        Debug.Log("Nota Deletada");
    }

    public List<Note> GetAllNotes()
    {
        return notesList.notes;
    }

    public Note GetNoteById(string noteId)
    {
        return notesList.notes.Find(n => n.id == noteId);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
