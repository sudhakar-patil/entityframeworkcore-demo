using efcoredemo.Interface;
namespace efcoredemo.Database
{
public abstract class BaseEntity : IEntity
    {       
        public int Id { get; set; }
    }
}