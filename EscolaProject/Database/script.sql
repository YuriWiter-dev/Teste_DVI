create database [escola]

USE [escola]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 3/21/2023 1:12:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome_aluno] [nchar](50) NOT NULL,
	[email] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 3/21/2023 1:12:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome_materia] [nchar](10) NOT NULL,
	[descricao] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materia_aluno]    Script Date: 3/21/2023 1:12:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materia_aluno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_aluno] [int] NOT NULL,
	[id_materia] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 3/21/2023 1:12:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Id_aluno] [int] NOT NULL,
	[id_materia] [int] NOT NULL,
	[nota] [int] NOT NULL,
	[data] [date] NOT NULL,
 CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aluno] ON 

INSERT [dbo].[Aluno] ([id], [nome_aluno], [email]) VALUES (1, N'Yuri                                              ', N'yuri@gmail                                                                                          ')
INSERT [dbo].[Aluno] ([id], [nome_aluno], [email]) VALUES (2, N'Yan                                               ', N'yan@gmail                                                                                           ')
INSERT [dbo].[Aluno] ([id], [nome_aluno], [email]) VALUES (3, N'Izabella                                          ', N'izabela@gmail                                                                                       ')
SET IDENTITY_INSERT [dbo].[Aluno] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([id], [nome_materia], [descricao]) VALUES (1, N'Portugues ', N'Literatura')
INSERT [dbo].[Materia] ([id], [nome_materia], [descricao]) VALUES (2, N'Matematica', N'Algebra   ')
INSERT [dbo].[Materia] ([id], [nome_materia], [descricao]) VALUES (3, N'Geografia ', N'Pampas    ')
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[Notas] ON 

INSERT [dbo].[Notas] ([id], [Id_aluno], [id_materia], [nota], [data]) VALUES (1, 1, 1, 2, CAST(N'0001-01-10' AS Date))
SET IDENTITY_INSERT [dbo].[Notas] OFF
GO
ALTER TABLE [dbo].[materia_aluno]  WITH CHECK ADD  CONSTRAINT [FK_materia_aluno_Aluno] FOREIGN KEY([id_aluno])
REFERENCES [dbo].[Aluno] ([id])
GO
ALTER TABLE [dbo].[materia_aluno] CHECK CONSTRAINT [FK_materia_aluno_Aluno]
GO
ALTER TABLE [dbo].[materia_aluno]  WITH CHECK ADD  CONSTRAINT [FK_materia_aluno_Materia] FOREIGN KEY([id_materia])
REFERENCES [dbo].[Materia] ([id])
GO
ALTER TABLE [dbo].[materia_aluno] CHECK CONSTRAINT [FK_materia_aluno_Materia]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Aluno] FOREIGN KEY([id])
REFERENCES [dbo].[Aluno] ([id])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Aluno]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Materia] FOREIGN KEY([id])
REFERENCES [dbo].[Materia] ([id])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Materia]
GO
