using System;
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
        string id = entity.Id;
        (_, Range document) = id.ToSplitIdRanges();
        return id[document];
    }

    /// <summary>
    /// Builds the Cosmos DB partition-key text represented by the entity.
    /// </summary>
    /// <typeparam name="T">The sequence element or result type.</typeparam>
    /// <param name="entity">The entity whose partition key is required.</param>
    /// <returns>The serialized partition-key text.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToPartitionKey<T>(this T entity) where T : IEntity
    {
        string id = entity.Id;
        (Range partition, _) = id.ToSplitIdRanges();
        return id[partition];
    }
}