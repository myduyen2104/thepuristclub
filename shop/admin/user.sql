CREATE TABLE [dbo].[user] 
(
  [Id] NVARCHAR(20) NOT NULL PRIMARY KEY,
  [pass] nvarchar(20)
)

INSERT [dbo].[user] 
VALUES 
(N'admin3112', N'3112')