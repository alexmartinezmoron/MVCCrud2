BEGIN TRANSACTION;
GO

CREATE TABLE [AddClienteVeiwModel] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [pass] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AddClienteVeiwModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AddClienteVeiwModel_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Coches] (
    [Id] int NOT NULL IDENTITY,
    [Matricula] nvarchar(max) NOT NULL,
    [Modelo] nvarchar(max) NOT NULL,
    [Marca] nvarchar(max) NOT NULL,
    [Color] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Coches] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_AddClienteVeiwModel_ClienteId] ON [AddClienteVeiwModel] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231117154241_coches', N'7.0.12');
GO

COMMIT;
GO

