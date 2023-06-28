using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

public static class SnakeCaseExtensions
{
    public static void ToSnakeCaseNames(this ModelBuilder modelBuilder)
    {
        if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

        foreach (var entity in modelBuilder.Model?.GetEntityTypes())
        {
            if (entity == null) continue;

            var tableName = entity.GetTableName()?.ToSnakeCase();
            if (!string.IsNullOrEmpty(tableName))
            {
                entity.SetTableName(tableName);
            }

            foreach (var property in entity.GetProperties()?.Where(p => p != null))
            {
                var columnName = property.Name?.ToSnakeCase();
                if (!string.IsNullOrEmpty(columnName))
                {
                    property.SetColumnName(columnName);
                }
            }

            foreach (var key in entity.GetKeys()?.Where(k => k != null))
            {
                var keyName = key.GetName()?.ToSnakeCase();
                if (!string.IsNullOrEmpty(keyName))
                {
                    key.SetName(keyName);
                }
            }

            foreach (var foreignKey in entity.GetForeignKeys()?.Where(fk => fk != null))
            {
                var foreignKeyName = foreignKey.GetConstraintName()?.ToSnakeCase();
                if (!string.IsNullOrEmpty(foreignKeyName))
                {
                    foreignKey.SetConstraintName(foreignKeyName);
                }
            }

            foreach (var index in entity.GetIndexes()?.Where(i => i != null))
            {
                var indexName = index.GetDatabaseName()?.ToSnakeCase();
                if (!string.IsNullOrEmpty(indexName))
                {
                    index.SetDatabaseName(indexName);
                }
            }
        }
    }

    //UserId -> user_id
    private static string ToSnakeCase(this string name)
        => Regex.Replace(
            name ?? string.Empty,
            @"([a-z0-9])([A-Z])",
            "$1_$2").ToLower();
}
