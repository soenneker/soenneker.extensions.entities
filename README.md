[![](https://img.shields.io/nuget/v/soenneker.extensions.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.entities/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.entities/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.entities.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.entities/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.entities/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.entities/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Entities

Extracts Cosmos-style partition and document identifiers from an `IEntity` compound `Id`.

## Installation

```bash
dotnet add package Soenneker.Extensions.Entities
```

## Usage

```csharp
using Soenneker.Entities.Entity.Abstract;
using Soenneker.Extensions.Entities;

IEntity entity = GetEntity();
entity.Id = "customer-42:order-100";

string partitionKey = entity.ToPartitionKey(); // "customer-42"
string documentId = entity.ToDocumentId();      // "order-100"
```

The ID is split at its last colon. This supports compound partition keys:

```text
region:customer-42:order-100
└──── partition key ────┘ └ document ID
```

When the ID contains no colon, both methods return the complete ID. A leading colon produces an empty partition key; a trailing colon produces an empty document ID. Null or empty entity IDs are rejected by the underlying string split operation, and passing a null entity is not supported.
