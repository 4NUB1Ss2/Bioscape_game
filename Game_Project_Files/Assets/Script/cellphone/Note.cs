using System;

[System.Serializable]

public class Note
{
    public string id;
    public string title;
    public string body;
    public string dateCreated;

    public Note(string title, string body)
    {
        this.id = Guid.NewGuid().ToString();
        this.title = title;
        this.body = body;
        this.dateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}