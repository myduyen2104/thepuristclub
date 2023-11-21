-- Bảng Category
CREATE TABLE [dbo].[Category] (  
    [CatID]     INT           IDENTITY (1, 1) NOT NULL,
    [NameCate]  NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([CatID] ASC)
);

-- Bảng Products
CREATE TABLE [dbo].[Products] (
    [ProductID] INT             IDENTITY (1, 1) NOT NULL,
    [NamePro]   NVARCHAR(MAX)   NOT NULL,
    [ImagePro]  NVARCHAR(MAX)   NOT NULL,
	[Material]      TEXT        NULL,
    [Amout]         INT         NULL,
    [Size]          TEXT        NULL,
    [Price]         FLOAT(53)   NOT NULL,
    [CatID]       INT             NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Madein]    NVARCHAR(MAX)	NULL,
	[Lens]		NVARCHAR(MAX)	NULL,
	[Color]		NVARCHAR(MAX)   NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Pro_Category] FOREIGN KEY ([CatID]) REFERENCES [dbo].[Category] ([CatID])
);


-- Bảng Customer
CREATE TABLE [dbo].[Customer] (
    [IDCus]     INT             IDENTITY (1, 1) NOT NULL,
    [NameCus]   NVARCHAR(MAX)   NULL,
    [EmailCus]  NVARCHAR(MAX)   NULL,
    [PassCus]   NCHAR(50)       NOT NULL,
    [AddressCus] NVARCHAR(MAX)  NULL, -- Thêm cột AddressCus
    PRIMARY KEY CLUSTERED ([IDCus] ASC)
);

-- Bảng AdminUser
CREATE TABLE [dbo].[AdminUser] (
    [ID]            INT             NOT NULL,
    [NameUser]      NVARCHAR(MAX)   NOT NULL,
    [EmailUser]     NVARCHAR(MAX)   NOT NULL,
    [RoleUser]      NVARCHAR(MAX)   NOT NULL,
    [PasswordUser]  NCHAR(50)       NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Bảng OrderPro
CREATE TABLE [dbo].[OrderPro] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [DateOrder]         DATE            NULL,
    [IDCus]             INT             NULL,
    [AddressDelivery]   NVARCHAR(MAX)   NULL, -- Sửa tên cột thành AddressDelivery
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDCus]) REFERENCES [dbo].[Customer] ([IDCus])
);

-- Bảng OrderDetail
CREATE TABLE [dbo].[OrderDetail] (
    [ID]        INT         IDENTITY (1, 1) NOT NULL,
    [IDProduct] INT         NULL,
    [IDOrder]   INT         NULL,
    [Quantity]  INT         NULL,
    [UnitPrice] FLOAT(53)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([IDProduct]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([IDOrder]) REFERENCES [dbo].[OrderPro] ([ID])
);

-- Bảng Blog
CREATE TABLE [dbo].[Blog](
    [ID]            INT             NOT NULL,
    [Title]         TEXT            NULL,
    [Date]          DATE            NULL,
    [ImageBl]       NVARCHAR(MAX)   NULL,
    [DescriptionBl] NVARCHAR(MAX)   NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);