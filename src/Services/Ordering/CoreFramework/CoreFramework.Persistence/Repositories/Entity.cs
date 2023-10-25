namespace CoreFramework.Persistence.Repositories;

public class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Entity()
    {
        if(Id == Guid.Empty)
        {
             Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }

    public Entity(Guid id) : this()
    {
        Id = id;
    }

    public Entity(Guid id, DateTime startedAt, DateTime? endedAt): this()
    {
        Id = id;
        CreatedAt = startedAt;
        UpdatedAt = endedAt;
    }
    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}