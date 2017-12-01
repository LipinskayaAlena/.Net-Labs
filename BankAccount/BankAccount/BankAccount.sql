CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Type] NCHAR(20) NOT NULL, 
    [FistName] NCHAR(20) NOT NULL, 
    [LastName] NCHAR(20) NOT NULL, 
    [Date] DATE NOT NULL, 
    [Account] MONEY NOT NULL, 
    [BonusPoints] MONEY NOT NULL
)