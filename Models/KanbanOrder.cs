using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class KanbanOrder
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }

    public string StatusesJson { get; set; }

    [NotMapped]
    public string[] Statuses
    {
        get => StatusesJson == null ? Array.Empty<string>() : JsonSerializer.Deserialize<string[]>(StatusesJson);
        set => StatusesJson = JsonSerializer.Serialize(value);
    }
}