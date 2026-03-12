using Soenneker.Entities.Entity.Abstract;
using Soenneker.Extensions.String;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Entities;

/// <summary>
/// A collection of helpful Entities extension methods
/// </summary>
public static class EntitiesExtension
{
    /// <summary>
    /// Shorthand for SplitId on the Id of the entity.
    /// </summary>
    /// <returns>
    /// Will not return the partitionKey unless it's the same as the documentId
    /// </returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToDocumentId<T>(this T entity) where T : IEntity
    {
        (_, string documentId) = entity.Id.ToSplitId();

        return documentId;
    }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToPartitionKey<T>(this T entity) where T : IEntity
    {
        (string partitionKey, _) = entity.Id.ToSplitId();

        return partitionKey;
    }
}