IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Livrator] (
    [id] int NOT NULL IDENTITY,
    [Nume_Livrator] nvarchar(max) NOT NULL,
    [Prenume_Livrator] nvarchar(max) NOT NULL,
    [Telefon_Livrator] nvarchar(max) NOT NULL,
    [Statut_Livrator] bit NOT NULL,
    CONSTRAINT [PK_Livrator] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Produs] (
    [Id] int NOT NULL IDENTITY,
    [Nume_Produs] nvarchar(max) NOT NULL,
    [Pret_Produs] decimal(18,2) NOT NULL,
    [Imagine] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Produs] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Stare_Comanda] (
    [Id] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NULL,
    CONSTRAINT [PK_Stare_Comanda] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comanda_Livrare] (
    [id] int NOT NULL IDENTITY,
    [Nume] nvarchar(max) NOT NULL,
    [Prenume] nvarchar(max) NOT NULL,
    [Oras] nvarchar(max) NOT NULL,
    [Strada] nvarchar(max) NOT NULL,
    [Numar] nvarchar(max) NOT NULL,
    [Bloc] nvarchar(max) NULL,
    [Scara] nvarchar(max) NULL,
    [Apartament] nvarchar(max) NULL,
    [Numar_Telefon] nvarchar(max) NOT NULL,
    [Data_Comanda] datetime2 NOT NULL,
    [Stare_Comanda_ID] int NOT NULL,
    CONSTRAINT [PK_Comanda_Livrare] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Comanda_Livrare_Stare_Comanda_Stare_Comanda_ID] FOREIGN KEY ([Stare_Comanda_ID]) REFERENCES [Stare_Comanda] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comanda_Livrare_Produs] (
    [id] int NOT NULL IDENTITY,
    [Produs_ID] int NOT NULL,
    [Comanda_ID] int NOT NULL,
    [Cantitate] int NOT NULL,
    CONSTRAINT [PK_Comanda_Livrare_Produs] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Comanda_Livrare_Produs_Comanda_Livrare_Comanda_ID] FOREIGN KEY ([Comanda_ID]) REFERENCES [Comanda_Livrare] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Comanda_Livrare_Produs_Produs_Produs_ID] FOREIGN KEY ([Produs_ID]) REFERENCES [Produs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Comanda_Livrare_Stare_Comanda_ID] ON [Comanda_Livrare] ([Stare_Comanda_ID]);
GO

CREATE INDEX [IX_Comanda_Livrare_Produs_Comanda_ID] ON [Comanda_Livrare_Produs] ([Comanda_ID]);
GO

CREATE INDEX [IX_Comanda_Livrare_Produs_Produs_ID] ON [Comanda_Livrare_Produs] ([Produs_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220417225649_Init', N'6.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220418094632_mig', N'6.0.4');
GO

COMMIT;
GO

