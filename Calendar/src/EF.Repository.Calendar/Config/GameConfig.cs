using Domain.Calendar;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using System;

namespace EF.Repository.Calendar
{
    public class GameConfig
    {
        public static Action<EntityTypeBuilder<Game>> Config()
        {
            return c =>
            {
                c.ForRelational(f => f.Table("Game"));
                c.Key(k => k.Id);
                c.Property(p => p.Name).Required().MaxLength(100);
                c.Property(p => p.Release).Required();
            };
        }
    }
}
