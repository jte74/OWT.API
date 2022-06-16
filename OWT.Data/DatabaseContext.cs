using Microsoft.EntityFrameworkCore;
using OWT.Data.EntityModels;

namespace OWT.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<ContactSkill> ContactSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactSkill>()
                        .HasKey(s => new { s.SkillId, s.ContactId });

            modelBuilder.Entity<ContactSkill>()
            .HasOne<Contact>(sc => sc.Contact)
            .WithMany(s => s.ContactSkill)
            .HasForeignKey(sc => sc.ContactId);


            modelBuilder.Entity<ContactSkill>()
                .HasOne<Skill>(sc => sc.Skill)
                .WithMany(s => s.ContactSkill)
                .HasForeignKey(sc => sc.SkillId);

            var Julien = new Contact
            {
                Id = 1,
                FirstName = "Julien",
                LastName = "Tellier",
                Email = "julien.tellier74@mail.com",
                FullName = "JulienTellier",
                Phone = "0672222667",
                Address = "13 rue des pinsons"
            };

            var Alfred = new Contact
            {
                Id = 2,
                FirstName = "Alfred",
                LastName = "Tellier",
                Email = "Alfred.tellier74@mail.com",
                FullName = "AlfredTellier",
                Phone = "0672222668",
                Address = "13 rue des lilas"
            };

            var Jean = new Contact
            {
                Id = 3,
                FirstName = "Jean",
                LastName = "Tellier",
                Email = "Jean.tellier74@mail.com",
                FullName = "JeanTellier",
                Phone = "0672222669",
                Address = "13 rue du stade"
            };

            var skill = new Skill { Id = 1, Name = "C#" ,Level = "senior" };
            var skill1 = new Skill { Id = 2, Name = "Devops" ,Level = "junior" };
            var skill2 = new Skill { Id = 3, Name = ".Net" ,Level = "intermediate" };

            var assoJulien = new ContactSkill { SkillId = skill.Id, ContactId = Julien.Id };
            var assoJean = new ContactSkill { SkillId = skill1.Id, ContactId = Jean.Id };
            var assoAlfred = new ContactSkill { SkillId = skill2.Id, ContactId = Alfred.Id };

            modelBuilder.Entity<Contact>().HasData(Julien, Alfred, Jean);
            modelBuilder.Entity<Skill>().HasData(skill, skill1, skill2);
            modelBuilder.Entity<ContactSkill>().HasData(assoJulien, assoJean, assoAlfred);
        }
        }
    }
