BEGIN TRANSACTION;
GO

CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Apellido] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [pass] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Marcas] (
    [Id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NOT NULL,
    [pais] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);
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
    [Color] nvarchar(max) NOT NULL,
    [marcaId] int NOT NULL,
    CONSTRAINT [PK_Coches] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Coches_Marcas_marcaId] FOREIGN KEY ([marcaId]) REFERENCES [Marcas] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AddClienteVeiwModel_ClienteId] ON [AddClienteVeiwModel] ([ClienteId]);
GO

CREATE INDEX [IX_Coches_marcaId] ON [Coches] ([marcaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231117164131_cocheMarca', N'7.0.12');
GO

COMMIT;
GO

