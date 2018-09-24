USE [Agenda]
GO

/****** Object:  Table [dbo].[Amigos]    Script Date: 21/09/2018 9:10:59 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Amigos](
	[AmigoId] [uniqueidentifier] NOT NULL,
	[Nombre] [nchar](30) NULL,
	[Apellido] [nchar](30) NULL,
	[Telefono] [nchar](30) NULL,
	[Ciudad] [int] NULL,
	[Departamento] [int] NULL,
	PRIMARY KEY (AmigoId)
) ON [PRIMARY]
GO


