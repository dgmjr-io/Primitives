namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class XriEfCoreExtensions
{
    public static PropertyBuilder<xri> XriProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, xri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().XriProperty(propertyExpression);

    public static PropertyBuilder<xri?> XriProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, xri?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().XriProperty(propertyExpression);

    public static PropertyBuilder<xri> XriProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, xri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<xri>())
            .HasMaxLength(UriMaxLength);

    public static PropertyBuilder<xri?> XriProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, xri?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<xri>())
            .HasMaxLength(UriMaxLength);
}
