using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using EF.Repository.Calendar;

namespace EF.Repository.Calendar.Migrations
{
    [ContextType(typeof(CalendarContext))]
    partial class CalendarContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("Domain.Calendar.Game", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Name")
                            .Annotation("MaxLength", 100)
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<DateTimeOffset>("Release")
                            .Annotation("OriginalValueIndex", 2);
                        b.Key("Id");
                        b.Annotation("Relational:TableName", "Game");
                    });
                
                return builder.Model;
            }
        }
    }
}
