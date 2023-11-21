
-- Bang AdminUser
CREATE TABLE [dbo].[AdminUser] (
    [ID]           INT            NOT NULL,
    [NameUser]     NVARCHAR (MAX) NULL,
   [EmailUser]		NVARCHAR(MAX) NULL,
    [PasswordUser] NCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
--Bang Category
CREATE TABLE [dbo].[Category] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IDCate]   NCHAR (20)     NOT NULL,
    [NameCate] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([IDCate] ASC)
);
--Bang Customer
CREATE TABLE [dbo].[Customer] (
    [IDCus]    INT            IDENTITY (1, 1) NOT NULL,
    [NameCus]  NVARCHAR (MAX) NULL,
    [PassWordCus] NVARCHAR(50) NULL,
    [EmailCus] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([IDCus] ASC)
);
--Bang Products
CREATE TABLE [dbo].[Products] (
    [ProductID]     INT             IDENTITY (1, 1) NOT NULL,
    [NamePro]       NVARCHAR (MAX)  NULL,
    [DecriptionPro] NVARCHAR (MAX)  NULL,
    [Category]      NCHAR (20)      NULL,
	[Material]      TEXT        NULL,
    [Amout]         INT         NULL,
    [Size]		NVARCHAR (MAX)       NULL,
	[IDCate]		NCHAR(20)   NULL,
    [Description] NVARCHAR(MAX) NULL,
	[Madein]    NVARCHAR(MAX)	NULL,
	[Lens]		NVARCHAR(MAX)	NULL,
	[Color]		NVARCHAR(MAX)   NULL,
    [Price]         DECIMAL (18, 2) NULL,
    [ImagePro]      NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Pro_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([IDCate])
);
--Bang OrderPro
CREATE TABLE [dbo].[OrderPro] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [DateOrder]        DATE           NULL,
    [IDCus]            INT            NULL,
    [Address] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDCus]) REFERENCES [dbo].[Customer] ([IDCus])
);
--Bang OrderDetail
CREATE TABLE [dbo].[OrderDetail] (
    [ID]        INT        IDENTITY (1, 1) NOT NULL,
    [IDProduct] INT        NULL,
    [IDOrder]   INT        NULL,
    
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDProduct]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([IDOrder]) REFERENCES [dbo].[OrderPro] ([ID])
);

