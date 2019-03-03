SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT INTO [dbo].[Movie] ([ID], [Book], [LogDate], [Genre], [Price], [Rating]) VALUES (1, N'The Good, the bad, and the ugly', N'2018-11-30 00:00:00', N'Western', CAST(1.19 AS Decimal(18, 2)), N'R')
INSERT INTO [dbo].[Movie] ([ID], [Book], [LogDate], [Genre], [Price], [Rating]) VALUES (2, N'When Harry Met Sally', N'1989-02-12 00:00:00', N'Romantic Comedy', CAST(7.99 AS Decimal(18, 2)), N'R')
INSERT INTO [dbo].[Movie] ([ID], [Book], [LogDate], [Genre], [Price], [Rating]) VALUES (3, N'Ghostbusters', N'1984-03-13 00:00:00', N'Comedy', CAST(8.99 AS Decimal(18, 2)), N'G')
INSERT INTO [dbo].[Movie] ([ID], [Book], [LogDate], [Genre], [Price], [Rating]) VALUES (4, N'Ghostbusters 2', N'1986-02-23 00:00:00', N'Comedy', CAST(9.99 AS Decimal(18, 2)), N'G')
INSERT INTO [dbo].[Movie] ([ID], [Book], [LogDate], [Genre], [Price], [Rating]) VALUES (5, N'Rio Bravo', N'1959-04-15 00:00:00', N'Western', CAST(3.99 AS Decimal(18, 2)), N'NA')
SET IDENTITY_INSERT [dbo].[Movie] OFF
