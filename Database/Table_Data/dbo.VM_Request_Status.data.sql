SET IDENTITY_INSERT [dbo].[VM_Request_Status] ON
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (1, N'Pending')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (2, N'Cancelled')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (3, N'Approved')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (4, N'Denied')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (5, N'Expired')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (6, N'Creating')
INSERT INTO [dbo].[VM_Request_Status] ([Id], [Status]) VALUES (7, N'Created')
SET IDENTITY_INSERT [dbo].[VM_Request_Status] OFF
