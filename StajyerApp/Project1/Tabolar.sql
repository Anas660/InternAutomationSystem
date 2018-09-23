CREATE TABLE [dbo].[Bolum] (
    [BolumId]  INT            IDENTITY (1, 1) NOT NULL,
    [BolumAdi] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED ([BolumId] ASC)
);

go

CREATE TABLE [dbo].[Okul] (
    [OkulId]  INT            IDENTITY (1, 1) NOT NULL,
    [OkulAdi] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Okul] PRIMARY KEY CLUSTERED ([OkulId] ASC)
);

go 

CREATE TABLE [dbo].[PersonelDepartman] (
    [PersonelDepartmanId] INT            IDENTITY (1, 1) NOT NULL,
    [DepartmanKodu]       NVARCHAR (255) NULL,
    [DepartmanAdi]        NVARCHAR (255) NULL,
    [DepartmanParentId]   NVARCHAR (255) NULL,
    [SystemId]            INT            NULL,
    [DepartmanDurum]      BIT            NULL,
    [CreationDate]        DATETIME       NULL,
    [ModificationDate]    DATETIME       NULL,
    CONSTRAINT [PK_PersonelDepartman] PRIMARY KEY CLUSTERED ([PersonelDepartmanId] ASC)
);

go

CREATE TABLE [dbo].[PersonelStajyer] (
    [StajyerId]     INT            IDENTITY (1, 1) NOT NULL,
    [OkulId]        INT            NULL,
    [BolumId]       INT            NULL,
    [Adi]           NVARCHAR (150) NULL,
    [Soyadi]        NVARCHAR (150) NULL,
    [Telefon]       NVARCHAR (50)  NULL,
    [Email]         NVARCHAR (50)  NULL,
    [Adres]         NVARCHAR (250) NULL,
    [DogumYeri]     NVARCHAR (150) NULL,
    [DogumTarihi]   DATETIME       NULL,
    [TcNo]          NVARCHAR (50)  NULL,
    [SicilNo]       NVARCHAR (50)  NULL,
    [BaslamaTarihi] DATETIME       NULL,
    [BitisTarihi]   DATETIME       NULL,
    [DepartmanId]   INT            NULL,
    CONSTRAINT [PK_Stajyer] PRIMARY KEY CLUSTERED ([StajyerId] ASC),
    CONSTRAINT [FK_PersonelStajyer_Okul] FOREIGN KEY ([OkulId]) REFERENCES [dbo].[Okul] ([OkulId]),
    CONSTRAINT [FK_PersonelStajyer_Bolum] FOREIGN KEY ([BolumId]) REFERENCES [dbo].[Bolum] ([BolumId]),
    CONSTRAINT [FK_PersonelStajyer_PersonelDepartman] FOREIGN KEY ([DepartmanId]) REFERENCES [dbo].[PersonelDepartman] ([PersonelDepartmanId])
);


go

CREATE TABLE [dbo].[StajyerKontanjan] (
    [StajyerKontenjanId] INT IDENTITY (1, 1) NOT NULL,
    [DepartmanId]        INT NULL,
    [Durum]              INT NULL,
    [AnlikSayi]          INT NULL,
    [KontenjanSayisi]    INT NULL,
    CONSTRAINT [PK_StajyerKontanjan] PRIMARY KEY CLUSTERED ([StajyerKontenjanId] ASC),
    CONSTRAINT [FK_StajyerKontanjan_PersonelDepartman] FOREIGN KEY ([DepartmanId]) REFERENCES [dbo].[PersonelDepartman] ([PersonelDepartmanId]),
    CONSTRAINT [CK_StajyerKontenjan] CHECK ([AnlikSayi]<=[KontenjanSayisi]),
    CONSTRAINT [CK_AnlikSayi] CHECK ([AnlikSayi]>=(0))
);
