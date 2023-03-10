using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(e => e.CommentId);

            builder.Property(e => e.CommentId)
            .HasColumnName("IdComentario")
            .ValueGeneratedNever();

            builder.Property(e => e.PostId)
            .HasColumnName("IdPublicacion")
            .ValueGeneratedNever();

            builder.Property(e => e.UserId)
            .HasColumnName("IdUsuario")
            .ValueGeneratedNever();

            builder.Property(e => e.IsActive)
            .HasColumnName("Activo");

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("Descripcion")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Date).HasColumnType("datetime")
            .HasColumnName("Fecha");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Coments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}
