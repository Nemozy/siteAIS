CREATE TABLE [dbo].[authkeydb] (
    [Id]       INT           NOT NULL,
    [authkey]  NVARCHAR (50) NULL,
    [datetime] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[energydb] (
    [Id]          INT      NOT NULL,
    [energylimit] INT      NULL,
    [datetime]    DATETIME NULL,
    [energycount] INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[expdb] (
    [Id]       INT NOT NULL,
    [expcount] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[globalitemdb] (
    [Id]   INT NOT NULL,
    [type] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[inventorydb] (
    [Id]            INT            NOT NULL,
    [idmassyacheek] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[moneydb] (
    [Id]    INT NOT NULL,
    [gold]  INT NULL,
    [oensh] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[racedb] (
    [Id]   INT NOT NULL,
    [type] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[racetypedb] (
    [Id]     INT NOT NULL,
    [damage] INT NULL,
    [hp]     INT NULL,
    [mp]     INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[settingsdb] (
    [Id]     INT NOT NULL,
    [music]  INT NULL,
    [sound]  INT NULL,
    [volume] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[shipdb] (
    [Id]       INT NOT NULL,
    [shiptype] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[stagedb] (
    [Id]            INT NOT NULL,
    [planet1]       INT NULL,
    [planet2]       INT NULL,
    [planet3]       INT NULL,
    [planet4]       INT NULL,
    [planet5]       INT NULL,
    [planet6]       INT NULL,
    [planet7]       INT NULL,
    [planet8]       INT NULL,
    [planet9]       INT NULL,
    [planet10]      INT NULL,
    [planet11]      INT NULL,
    [planet12]      INT NULL,
    [planet13]      INT NULL,
    [planet14]      INT NULL,
    [planet15]      INT NULL,
    [lastplanetwin] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[userdb] (
    [Id]         INT           NOT NULL,
    [Nickname]   NVARCHAR (50) COLLATE Cyrillic_General_CI_AS_KS NULL,
    [Idsbase]    INT           NULL,
    [Timecreate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[yacheykadb] (
    [Id]      NVARCHAR(50) NOT NULL,
    [type]    INT NULL,
    [item_id] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);