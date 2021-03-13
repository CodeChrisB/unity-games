// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Collections.Generic;

public class Question
{
    public int Id;
    public int StroyPathId;
    public string Title;
    public List<Answer> Anwsers = new List<Answer>();

    public Question(int id,int path,string title)
    {
        Id = id;
        StroyPathId = path;
        Title = title;
    }
}


