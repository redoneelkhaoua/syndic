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

        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Choix> Choixes { get; set; } = null!;
        public virtual DbSet<Dossier> Dossiers { get; set; } = null!;
        public virtual DbSet<Fichier> Fichiers { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Resultat> Resultats { get; set; } = null!;
        public virtual DbSet<Statut> Statuts { get; set; } = null!;
        public virtual DbSet<Vote> Votes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=0000;Host=localhost;Port=5432;Database=Syndic;Pooling=true;Connection Lifetime=0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie)
                    .HasName("categorie_pkey");

                entity.ToTable("categorie");

                entity.Property(e => e.IdCategorie)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categorie");

                entity.Property(e => e.NomCategorie).HasColumnName("nom_categorie");
            });

            modelBuilder.Entity<Choix>(entity =>
            {
                entity.HasKey(e => e.IdChoix)
                    .HasName("choix_pkey");

                entity.ToTable("choix");

                entity.Property(e => e.IdChoix)
                    .ValueGeneratedNever()
                    .HasColumnName("id_choix");

                entity.Property(e => e.choix).HasColumnName("choix");

                entity.Property(e => e.IdVote).HasColumnName("id_vote");

                entity.HasOne(d => d.IdVoteNavigation)
                    .WithMany(p => p.Choixes)
                    .HasForeignKey(d => d.IdVote)
                    .HasConstraintName("choix_id_vote_fkey");
            });

            modelBuilder.Entity<Dossier>(entity =>
            {
                entity.HasKey(e => e.IdDossier)
                    .HasName("dossier_pkey");

                entity.ToTable("dossier");

                entity.Property(e => e.IdDossier)
                    .ValueGeneratedNever()
                    .HasColumnName("id_dossier");

                entity.Property(e => e.Categorie).HasColumnName("categorie");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.HasOne(d => d.CategorieNavigation)
                    .WithMany(p => p.Dossiers)
                    .HasForeignKey(d => d.Categorie)
                    .HasConstraintName("dossier_categorie_fkey");

                entity.HasOne(d => d.StatutNavigation)
                    .WithMany(p => p.Dossiers)
                    .HasForeignKey(d => d.Statut)
                    .HasConstraintName("dossier_statut_fkey");
            });

            modelBuilder.Entity<Fichier>(entity =>
            {
                entity.HasKey(e => e.IdFichier)
                    .HasName("fichier_pkey");

                entity.ToTable("fichier");

                entity.Property(e => e.IdFichier)
                    .ValueGeneratedNever()
                    .HasColumnName("id_fichier");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.fichier).HasColumnName("fichier");

                entity.Property(e => e.IdDossier).HasColumnName("id_dossier");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdDossierNavigation)
                    .WithMany(p => p.Fichiers)
                    .HasForeignKey(d => d.IdDossier)
                    .HasConstraintName("fichier_id_dossier_fkey");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNote)
                    .HasName("note_pkey");

                entity.ToTable("note");

                entity.Property(e => e.IdNote)
                    .ValueGeneratedNever()
                    .HasColumnName("id_note");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.IdDossier).HasColumnName("id_dossier");

                entity.Property(e => e.note).HasColumnName("note");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdDossierNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdDossier)
                    .HasConstraintName("note_id_dossier_fkey");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.IdParticipant)
                    .HasName("participant_pkey");

                entity.ToTable("participant");

                entity.Property(e => e.IdParticipant)
                    .ValueGeneratedNever()
                    .HasColumnName("id_participant");

                entity.Property(e => e.NomParticipant).HasColumnName("nomparticipant");
            });

            modelBuilder.Entity<Resultat>(entity =>
            {
                entity.HasKey(e => new { e.IdParticipant, e.IdVote })
                    .HasName("resultat_pkey");

                entity.ToTable("resultat");

                entity.Property(e => e.IdParticipant).HasColumnName("id_participant");

                entity.Property(e => e.IdVote).HasColumnName("id_vote");

                entity.Property(e => e.IdChoix).HasColumnName("id_choix");

                entity.HasOne(d => d.IdChoixNavigation)
                    .WithMany(p => p.Resultats)
                    .HasForeignKey(d => d.IdChoix)
                    .HasConstraintName("resultat_id_choix_fkey");

                entity.HasOne(d => d.IdParticipantNavigation)
                    .WithMany(p => p.Resultats)
                    .HasForeignKey(d => d.IdParticipant)
                   
                    .HasConstraintName("resultat_id_participant_fkey");

                entity.HasOne(d => d.IdVoteNavigation)
                    .WithMany(p => p.Resultats)
                    .HasForeignKey(d => d.IdVote)
                    
                    .HasConstraintName("resultat_id_vote_fkey");
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.IdStatut)
                    .HasName("statut_pkey");

                entity.ToTable("statut");

                entity.Property(e => e.IdStatut)
                    .ValueGeneratedNever()
                    .HasColumnName("id_statut");

                entity.Property(e => e.NomStatut).HasColumnName("nom_statut");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.HasKey(e => e.IdVote)
                    .HasName("vote_pkey");

                entity.ToTable("vote");

                entity.Property(e => e.IdVote)
                    .ValueGeneratedNever()
                    .HasColumnName("id_vote");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.IdDossier).HasColumnName("id_dossier");

                entity.Property(e => e.Titre).HasColumnName("titre");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdDossierNavigation)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.IdDossier)
                    .HasConstraintName("vote_id_dossier_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
