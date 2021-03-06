--初始化展会类型基础表
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'0BB2349D-F71D-4303-A0E8-9EF7C729931C', N'展会分类', 1, N'食品', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'20BDDC30-0861-483B-ACC9-6CE5AD171531', N'展会分类', 1, N'生活', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'7A018D85-7A0B-4ADF-BFD7-397C09C2A365', N'展会分类', 1, N'家居', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'7E22A79C-706C-4D5D-A254-0494F9AC452F', N'展会分类', 1, N'医疗', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'945C3E9B-ECD5-469E-BCDE-6E63863580CE', N'展会分类', 1, N'运动', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'BDDBA713-F71D-44B2-A15C-9DB3D60DB150', N'展会分类', 1, N'旅游', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'D1400D8D-2487-405F-9D10-1563CFFE416B', N'展会分类', 1, N'科技', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')
INSERT Business.BaseTypes ([ID], [TypeName], [TypeID], [TypeValue], [Creater], [CreatTime], [Modifier], [ModifiyTime], [IsDel], [Temp1], [Temp2]) VALUES (N'F79988D2-4B46-432E-9146-94925DCC4AE7', N'展会分类', 1, N'其他', N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, N'', N'')

--初始化

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('19','展会封面图','ExhibitionLogo','zht',GETDATE(),'',NULL,1,10)

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('20','展位分布图','DistributionMap','zht',GETDATE(),'',NULL,1,10)

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('21','展会详情图片','ExhibitionIntroImg','zht',GETDATE(),'',NULL,1,10)

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('22','展会详情视频','ExhibitionIntroVideo','zht',GETDATE(),'',NULL,1,10)

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('23','展品封面图','ProductImage','zht',GETDATE(),'',NULL,1,10)

INSERT Business.AttachmentType ([Code],[CnName],[EnName],[Creator],[CreateTime],[Modifier],[ModifyTime],ValidStatus,SortNo)
VALUES('24','动态多图','MomentImg','zht',GETDATE(),'',NULL,1,10)