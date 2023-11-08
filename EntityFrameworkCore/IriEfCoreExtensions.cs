namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class IriEfCoreExtensions
{
    public static PropertyBuilder<iri> IriProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, iri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().IriProperty(propertyExpression);

    public static PropertyBuilder<iri?> IriProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, iri?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().IriProperty(propertyExpression);

    public static PropertyBuilder<iri> IriProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, iri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<iri>())
            .HasMaxLength(UriMaxLength);

    public static PropertyBuilder<iri?> IriProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, iri?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<iri>())
            .HasMaxLength(UriMaxLength);
}
