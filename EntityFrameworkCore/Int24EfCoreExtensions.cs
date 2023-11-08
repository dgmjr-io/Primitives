namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class UInt24EfCoreExtensions
{
    public static PropertyBuilder<ui24?> UInt24Property<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, ui24?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UInt24Property(propertyExpression);

    public static PropertyBuilder<ui24?> UInt24Property<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ui24?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new CastingConverter<ui24, uint>());

    public static PropertyBuilder<ui24> UInt24Property<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, ui24>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UInt24Property(propertyExpression);

    public static PropertyBuilder<ui24> UInt24Property<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ui24>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new CastingConverter<ui24, uint>());
}

public static class Int24EfCoreExtensions
{
    public static PropertyBuilder<ui24?> Int24Property<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, ui24?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().Int24Property(propertyExpression);

    public static PropertyBuilder<ui24?> Int24Property<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ui24?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion(new CastingConverter<i24, int>());

    public static PropertyBuilder<ui24> Int24Property<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, ui24>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().Int24Property(propertyExpression);

    public static PropertyBuilder<ui24> Int24Property<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ui24>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion(new CastingConverter<i24, int>());
}
