using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CodeHausAPI.Models;

namespace CodeHausAPI.Data
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyFeature> CompanyFeatures { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Inspection> Inspections { get; set; } = null!;
        public virtual DbSet<InspectionQuestion> InspectionQuestions { get; set; } = null!;
        public virtual DbSet<InspectionQuestionAnswer> InspectionQuestionAnswers { get; set; } = null!;
        public virtual DbSet<InspectionQuestionType> InspectionQuestionTypes { get; set; } = null!;
        public virtual DbSet<InspectionTemplate> InspectionTemplates { get; set; } = null!;
        public virtual DbSet<InspectionTemplateSection> InspectionTemplateSections { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(255)
                    .HasColumnName("companyCode");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FilesLocation)
                    .HasMaxLength(255)
                    .HasColumnName("files_location");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CompanyFeature>(entity =>
            {
                entity.ToTable("company_features");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("features");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeatureName)
                    .HasMaxLength(255)
                    .HasColumnName("feature_name");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active");

                entity.Property(e => e.PageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("page_url");
            });

            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.ToTable("inspections");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignedUserId).HasColumnName("assigned_user_id");

                entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InspectionClientId).HasColumnName("inspection_client_id");

                entity.Property(e => e.InspectionTemplateId).HasColumnName("inspection_template_id");
            });

            modelBuilder.Entity<InspectionQuestion>(entity =>
            {
                entity.ToTable("inspection_questions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InspectionQuestion1)
                    .HasMaxLength(255)
                    .HasColumnName("inspection_question");

                entity.Property(e => e.InspectionQuestionTypeId).HasColumnName("inspection_question_type_id");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active");
            });

            modelBuilder.Entity<InspectionQuestionAnswer>(entity =>
            {
                entity.ToTable("inspection_question_answers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InpectionQuestionImageAnswer)
                    .HasMaxLength(255)
                    .HasColumnName("inpection_question_image_answer");

                entity.Property(e => e.InpectionQuestionTextAnswer)
                    .HasMaxLength(255)
                    .HasColumnName("inpection_question_text_answer");

                entity.Property(e => e.InpsectionQuestionId).HasColumnName("inpsection_question_id");
            });

            modelBuilder.Entity<InspectionQuestionType>(entity =>
            {
                entity.ToTable("inspection_question_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.QuestionDisplayValue)
                    .HasMaxLength(255)
                    .HasColumnName("question_display_value");

                entity.Property(e => e.QuestionOptions)
                    .HasMaxLength(255)
                    .HasColumnName("question_options");

                entity.Property(e => e.QuestionType)
                    .HasMaxLength(255)
                    .HasColumnName("question_type");
            });

            modelBuilder.Entity<InspectionTemplate>(entity =>
            {
                entity.ToTable("inspection_templates");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("timestamp")
                    .HasColumnName("date_created")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InspectionSectionIds)
                    .HasMaxLength(255)
                    .HasColumnName("inspection_section_ids");

                entity.Property(e => e.InspectionTemplateName)
                    .HasMaxLength(255)
                    .HasColumnName("inspection_template_name");

                entity.Property(e => e.IsActive)
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active");
            });

            modelBuilder.Entity<InspectionTemplateSection>(entity =>
            {
                entity.ToTable("inspection_template_sections");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InspectionQuestionIds)
                    .HasMaxLength(255)
                    .HasColumnName("inspection_question_ids");

                entity.Property(e => e.SectionName)
                    .HasMaxLength(255)
                    .HasColumnName("section_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
