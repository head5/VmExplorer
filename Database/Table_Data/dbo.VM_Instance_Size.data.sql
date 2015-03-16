SET IDENTITY_INSERT [dbo].[VM_Instance_Size] ON
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (0, N'Extra Small', N'768 MB', N'Shared Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (1, N'Small', N'1.75 GB', N'1 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (2, N'Medium', N'3.5 GB', N'2 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (3, N'Large', N'7 GB', N'4 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (4, N'Extra Large', N'14 GB', N'8 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (5, N'A6', N'28 GB', N'4 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (6, N'A8', N'56 GB', N'8 Core', N'Y')
INSERT INTO [dbo].[VM_Instance_Size] ([Id], [Name], [Memory], [Core], [Active]) VALUES (7, N'Giant', N'1 TB', N'32 Core', N'N')
SET IDENTITY_INSERT [dbo].[VM_Instance_Size] OFF
