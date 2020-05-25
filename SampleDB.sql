--Sample Database
--Complete bs for example only
--Don't forget to grant you user rights to the DB

CREATE DATABASE WidgetSampleDB;
GO
USE [WidgetSampleDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](110) NULL,
	[LastName] [varchar](110) NULL,
	[Email] [varchar](300) NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastUpdatedDateTime] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdatedBy] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Widgets](
	[WidgetID] [int] IDENTITY(1,1) NOT NULL,
	[WidgetContent] [varchar](max) NULL,
	[Color] [varchar](15) NULL,
	[Width] [float] NULL,
	[Height] [float] NULL,
	[Volume] [float] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastUpdatedDateTime] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdatedBy] [int] NULL,
	[fk_UserID] [int] NULL,
 CONSTRAINT [PK_Widgets] PRIMARY KEY CLUSTERED 
(
	[WidgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [CreatedDateTime], [LastUpdatedDateTime], [CreatedBy], [LastUpdatedBy]) VALUES (2, N'Bob', N'Todd', N'bob@widget.co', CAST(N'2020-05-25T09:53:04.080' AS DateTime), CAST(N'2020-05-25T09:53:04.080' AS DateTime), 0, 0)
GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [CreatedDateTime], [LastUpdatedDateTime], [CreatedBy], [LastUpdatedBy]) VALUES (3, N'Gina', N'Ripple', N'gina@widget.co', CAST(N'2020-05-25T09:56:46.193' AS DateTime), CAST(N'2020-05-25T09:56:46.193' AS DateTime), 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Widgets] ON 
GO
INSERT [dbo].[Widgets] ([WidgetID], [WidgetContent], [Color], [Width], [Height], [Volume], [CreatedDateTime], [LastUpdatedDateTime], [CreatedBy], [LastUpdatedBy], [fk_UserID]) VALUES (1, N'Widget Bulb', N'Green', 2, 5, 0, CAST(N'2020-05-25T09:55:39.510' AS DateTime), CAST(N'2020-05-25T09:55:39.510' AS DateTime), 2, 2, 3)
GO
SET IDENTITY_INSERT [dbo].[Widgets] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastUpdatedDateTime]  DEFAULT (getdate()) FOR [LastUpdatedDateTime]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastUpdatedBy]  DEFAULT ((0)) FOR [LastUpdatedBy]
GO
ALTER TABLE [dbo].[Widgets] ADD  CONSTRAINT [DF_Widgets_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Widgets] ADD  CONSTRAINT [DF_Widgets_LastUpdatedDateTime]  DEFAULT (getdate()) FOR [LastUpdatedDateTime]
GO
