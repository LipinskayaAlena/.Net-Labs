CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FistName] NCHAR(20) NOT NULL, 
    [LastName] NCHAR(20) NOT NULL, 
    [Date] DATE NOT NULL, 
    [Balance] MONEY NOT NULL, 
    [BonusPoints] MONEY NOT NULL, 
    [Type] NCHAR(20) NOT NULL, 
    CONSTRAINT [FK_Type] FOREIGN KEY ([Type]) REFERENCES [TypeAccount]([Name])
)