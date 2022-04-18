using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Syndic.domain.Models;

namespace Syndic.Persistence.EntityFramework
{
    public partial class SyndicContext : DbContext
    {

        public SyndicContext()
        {
        }

        public SyndicContext(DbContextOptions<SyndicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Choice> Choices { get; set; } = null!;
        public virtual DbSet<Case> Cases { get; set; } = null!;
        public virtual DbSet<file> _files { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<results> results { get; set; } = null!;
        public virtual DbSet<Status> Statues { get; set; } = null!;
        public virtual DbSet<Vote> Votes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("category_pkey");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("id_category");

                entity.Property(e => e.CategoryName).HasColumnName("category_name");
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.HasKey(e => e.IdChoice)
                    .HasName("choice_pkey");

                entity.ToTable("choice");

                entity.Property(e => e.IdChoice)
                    .ValueGeneratedNever()
                    .HasColumnName("id_choice");

                entity.Property(e => e.choice).HasColumnName("choice");

                entity.Property(e => e.IdVote).HasColumnName("id_vote");

                entity.HasOne(d => d.IdVoteNavigation)
                    .WithMany(p => p.Choices)
                    .HasForeignKey(d => d.IdVote)
                    .HasConstraintName("choice_id_vote_fkey");
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.HasKey(e => e.IdCase)
                    .HasName("case_pkey");

                entity.ToTable("case");

                entity.Property(e => e.IdCase)
                    .ValueGeneratedNever()
                    .HasColumnName("id_case");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.creationDate).HasColumnName("creation_Date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Status).HasColumnName("Status");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("case_category_fkey");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("case_Status_fkey");
            });

            modelBuilder.Entity<file>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("File_pkey");

                entity.ToTable("File");

                entity.Property(e => e.IdFile)
                    .ValueGeneratedNever()
                    .HasColumnName("id_File");

                entity.Property(e => e.creationDate).HasColumnName("creation_Date");

                entity.Property(e => e._file).HasColumnName("file");

                entity.Property(e => e.IdCase).HasColumnName("id_case");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdCaseNavigation)
                    .WithMany(p => p._files)
                    .HasForeignKey(d => d.IdCase)
                    .HasConstraintName("File_id_case_fkey");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNote)
                    .HasName("note_pkey");

                entity.ToTable("note");

                entity.Property(e => e.IdNote)
                    .ValueGeneratedNever()
                    .HasColumnName("id_note");

                entity.Property(e => e.creationDate).HasColumnName("creation_Date");

                entity.Property(e => e.IdCase).HasColumnName("id_case");

                entity.Property(e => e.note).HasColumnName("note");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdCaseNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdCase)
                    .HasConstraintName("note_id_dase_fkey");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.IdParticipant)
                    .HasName("participant_pkey");

                entity.ToTable("participant");

                entity.Property(e => e.IdParticipant)
                    .ValueGeneratedNever()
                    .HasColumnName("id_participant");

                entity.Property(e => e.participantName).HasColumnName("participant_name");
            });

            modelBuilder.Entity<results>(entity =>
            {
                entity.HasKey(e => new { e.IdParticipant, e.IdVote })
                    .HasName("results_pkey");

                entity.ToTable("results");

                entity.Property(e => e.IdParticipant).HasColumnName("id_participant");

                entity.Property(e => e.IdVote).HasColumnName("id_vote");

                entity.Property(e => e.IdChoice).HasColumnName("id_choice");

                entity.HasOne(d => d.IdChoiceNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdChoice)
                    .HasConstraintName("results_id_choice_fkey");

                entity.HasOne(d => d.IdParticipantNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdParticipant)
                   
                    .HasConstraintName("results_id_participant_fkey");

                entity.HasOne(d => d.IdVoteNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdVote)
                    
                    .HasConstraintName("results_id_vote_fkey");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("Status_pkey");

                entity.ToTable("Status");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_Status");

                entity.Property(e => e.statusName).HasColumnName("status_name");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.IdVote)
                    .HasName("vote_pkey");

                entity.ToTable("vote");

                entity.Property(e => e.IdVote)
                    .ValueGeneratedNever()
                    .HasColumnName("id_vote");

                entity.Property(e => e.creationDate).HasColumnName("creation_Date");

                entity.Property(e => e.IdCase).HasColumnName("id_dase");

                entity.Property(e => e.Title).HasColumnName("titre");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdCaseNavigation)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdCase)
                    .HasConstraintName("vote_id_dase_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
