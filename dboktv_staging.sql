/*
 Navicat Premium Data Transfer

 Source Server         : mssql
 Source Server Type    : SQL Server
 Source Server Version : 15004073
 Source Host           : localhost:1433
 Source Catalog        : ktv_staging
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15004073
 File Encoding         : 65001

 Date: 29/11/2020 17:59:47
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [__EFMigrationsHistory]
-- ----------------------------
BEGIN TRANSACTION
GO

INSERT INTO [dbo].[__EFMigrationsHistory]  VALUES (N'20201122081757_v.0.0.1', N'3.1.9')
GO

INSERT INTO [dbo].[__EFMigrationsHistory]  VALUES (N'20201122092953_v.0.0.2', N'3.1.9')
GO

INSERT INTO [dbo].[__EFMigrationsHistory]  VALUES (N'20201128052730_v.0.0.3', N'3.1.9')
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_AsignUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_AsignUser]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_AsignUser]
GO

CREATE TABLE [dbo].[CCNS_AsignUser] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [ToId] bigint NOT NULL,
  [ToName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FromId] bigint NOT NULL,
  [FromName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreatedDate] date NULL,
  [UpdatedDate] date NULL,
  [DeletedDate] date NULL,
  [AsignById] bigint NOT NULL,
  [AsignStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdateByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] date NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_AsignUser] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_AutoNumber
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_AutoNumber]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_AutoNumber]
GO

CREATE TABLE [dbo].[CCNS_AutoNumber] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [nvarchar(125)] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Prefix] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [AutoKey] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Started] bigint NOT NULL,
  [Next] bigint NOT NULL,
  [End] bigint NOT NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_AutoNumber] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_AutoNumber]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_AutoNumber] ON
GO

INSERT INTO [dbo].[CCNS_AutoNumber] ([Id], [nvarchar(125)], [Prefix], [AutoKey], [Started], [Next], [End], [LineStatus], [Deleted]) VALUES (N'1', N'Invoice', N'B-', N'I', N'19000000001', N'19000000000', N'19999999999', N'N', N'N')
GO

INSERT INTO [dbo].[CCNS_AutoNumber] ([Id], [nvarchar(125)], [Prefix], [AutoKey], [Started], [Next], [End], [LineStatus], [Deleted]) VALUES (N'2', N'Receipt', N'R-', N'R', N'19000000001', N'19000000000', N'19999999999', N'N', N'N')
GO

INSERT INTO [dbo].[CCNS_AutoNumber] ([Id], [nvarchar(125)], [Prefix], [AutoKey], [Started], [Next], [End], [LineStatus], [Deleted]) VALUES (N'3', N'Order', N'O-', N'O', N'19000000001', N'19000000000', N'19999999999', N'N', N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_AutoNumber] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Batch
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Batch]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Batch]
GO

CREATE TABLE [dbo].[CCNS_Batch] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [BatchNum] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemId] bigint NOT NULL,
  [ItemName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [SaleQty] decimal(18,6) NOT NULL,
  [SaleUoMId] bigint NOT NULL,
  [SaleUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UoMId] bigint NOT NULL,
  [GUoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EXP] datetime NULL,
  [MFG] datetime NULL,
  [CreatedDate] datetime NULL,
  [DeletedById] bigint NULL,
  [DeletedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedDate] datetime NULL,
  [CreatedById] bigint NULL,
  [CreatedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedDate] datetime NULL,
  [UpdatedById] bigint NULL,
  [UpdateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Batch] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Booking_Section
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Booking_Section]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Booking_Section]
GO

CREATE TABLE [dbo].[CCNS_Booking_Section] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [CustomerId] bigint NOT NULL,
  [CustomerStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Gender] nvarchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Phone1] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Phone2] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Pax] int NOT NULL,
  [Floor] int NOT NULL,
  [SectionId] bigint NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GSectionId] bigint NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TypeId] bigint NOT NULL,
  [TypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BookedById] bigint NOT NULL,
  [BookedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreatedById] bigint NOT NULL,
  [CreatedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BookedDate] datetime NULL,
  [UpdatedDate] datetime NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [StartDate] datetime NULL,
  [StartTime] time(7) NULL,
  [Hour] nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Minute] nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EndHour] nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EndMinute] nvarchar(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [EndTime] time(7) NULL,
  [ConfirmStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ConfirmDate] datetime NULL,
  [ConfirmById] bigint NOT NULL,
  [ConfirmByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelDate] datetime NULL,
  [CancelTime] time(7) NULL,
  [CancelById] bigint NOT NULL,
  [CancelByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineStatus] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Booking_Section] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Branch
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Branch]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Branch]
GO

CREATE TABLE [dbo].[CCNS_Branch] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Branch_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Branch_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Company_Id] bigint NOT NULL,
  [Company_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Whs_Id] bigint NOT NULL,
  [Whs_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [No_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [St_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Sangkat] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Khan] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [City] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Province] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Old_Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CompanyId] bigint NULL
)
GO

ALTER TABLE [dbo].[CCNS_Branch] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_BusinessPartner
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_BusinessPartner]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_BusinessPartner]
GO

CREATE TABLE [dbo].[CCNS_BusinessPartner] (
  [VendorId] bigint IDENTITY(1,1) NOT NULL,
  [PriceListId] bigint NOT NULL,
  [VendorName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Gender] nvarchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Email] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Phone1] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Phone2] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Address] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Type] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Delete] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateDate] datetime NOT NULL,
  [CreateById] bigint NOT NULL,
  [CreateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdateDate] datetime NULL,
  [UpdateById] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [UpdateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeleteDate] datetime NULL,
  [DeleteById] bigint NOT NULL,
  [DeleteByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_BusinessPartner] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_CashIn
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_CashIn]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_CashIn]
GO

CREATE TABLE [dbo].[CCNS_CashIn] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [CashInById] bigint NOT NULL,
  [CashInByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ReceivedById] bigint NOT NULL,
  [ReceivedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CashInDate] datetime NULL,
  [ShiftId] bigint NOT NULL,
  [ShiftStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] datetime NULL,
  [CashInUSD] decimal(18,6) NOT NULL,
  [CashInRiel] decimal(18,6) NOT NULL,
  [TotalUSD] decimal(18,6) NOT NULL,
  [TotalRiel] decimal(18,6) NOT NULL,
  [ExchangeRate] decimal(18,6) NOT NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Delete] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PaymentCode] bigint NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_CashIn] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_CashOut
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_CashOut]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_CashOut]
GO

CREATE TABLE [dbo].[CCNS_CashOut] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [CashInId] bigint NOT NULL,
  [CashOutById] bigint NOT NULL,
  [CashOutByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ReceivedById] bigint NOT NULL,
  [ReceivedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CashOutDate] datetime NULL,
  [CloseShiftId] bigint NOT NULL,
  [CloseShiftStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] datetime NULL,
  [CashOutUSD] decimal(18,6) NOT NULL,
  [CashOutRiel] decimal(18,6) NOT NULL,
  [TotalCashInUSD] decimal(18,6) NOT NULL,
  [TotalCashInRiel] decimal(18,6) NOT NULL,
  [TotalCashOutUSD] decimal(18,6) NOT NULL,
  [TotalCashOutRiel] decimal(18,6) NOT NULL,
  [ExchangeRate] decimal(18,6) NOT NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [CloseDate] datetime NULL,
  [CloseById] bigint NOT NULL,
  [CloseByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Delete] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PayCodeMin] bigint NOT NULL,
  [PayCodeMax] bigint NOT NULL,
  [SaleAmount] decimal(18,6) NOT NULL,
  [SaleAmountReil] decimal(18,6) NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_CashOut] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Category
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Category]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Category]
GO

CREATE TABLE [dbo].[CCNS_Category] (
  [CateId] bigint IDENTITY(1,1) NOT NULL,
  [Cate_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Cate_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Color] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Category] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Category]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Category] ON
GO

INSERT INTO [dbo].[CCNS_Category] ([CateId], [Cate_En], [Cate_Str], [Color], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted], [Status]) VALUES (N'1', N'Service', N'Service', N'IndianRed', N'0', NULL, NULL, N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Category] ([CateId], [Cate_En], [Cate_Str], [Color], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted], [Status]) VALUES (N'2', N'Beverage', N'Beverage', N'DodgerBlue', N'0', NULL, NULL, N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Category] ([CateId], [Cate_En], [Cate_Str], [Color], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted], [Status]) VALUES (N'3', N'Food', N'Food', N'CornflowerBlue', N'0', NULL, NULL, N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, N'N', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Category] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_CheckIn_Section
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_CheckIn_Section]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_CheckIn_Section]
GO

CREATE TABLE [dbo].[CCNS_CheckIn_Section] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Pax] int NOT NULL,
  [Floor] int NOT NULL,
  [GSectionId] bigint NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SectionId] bigint NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TypeId] bigint NOT NULL,
  [TypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [StartDate] datetime NULL,
  [StartTime] datetime NULL,
  [EndTime] time(7) NULL,
  [EndDate] datetime NULL,
  [Duration] int NOT NULL,
  [CheckedInById] bigint NOT NULL,
  [CheckedInByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CheckedInDate] datetime NULL,
  [UpdatedInById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedDate] datetime NULL,
  [CancelById] bigint NOT NULL,
  [CancelByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelDate] datetime NULL,
  [TransferFromSectionId] bigint NOT NULL,
  [TransferFromSectionName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TransferFromSectionTypeId] bigint NOT NULL,
  [TransferFromSectionTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TransferToSectionId] bigint NOT NULL,
  [TransferToSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TransferToSectionTypeId] bigint NOT NULL,
  [TransferToSectionTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TransferDate] datetime NULL,
  [TransferTime] datetime NULL,
  [TransferById] bigint NOT NULL,
  [TransferByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TransferStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_CheckIn_Section] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Commission
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Commission]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Commission]
GO

CREATE TABLE [dbo].[CCNS_Commission] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ReceivedById] bigint NOT NULL,
  [ReceivedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] datetime NULL,
  [PaymentCode] bigint NOT NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [Prcnt] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Rate] decimal(18,6) NOT NULL,
  [CommissionTotalUSD] decimal(18,6) NOT NULL,
  [CommissionTotalRiel] decimal(18,6) NOT NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [AcceptById] bigint NOT NULL,
  [AcceptByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [AcceptDate] datetime NULL,
  [AcceptStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Remark] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Commission] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Company
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Company]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Company]
GO

CREATE TABLE [dbo].[CCNS_Company] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Company_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Company_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Phone1] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Phone2] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Email] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Wifi] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [No_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [St_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Sangkat] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Khan] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [City] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Province] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Old_Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Updated_Date] date NULL,
  [Deleted_Date] date NULL,
  [Created_By_Id] bigint NULL,
  [Created_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_By_Id] bigint NULL,
  [Updated_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_By_Id] bigint NULL,
  [Deleted_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Company] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Company]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Company] ON
GO

INSERT INTO [dbo].[CCNS_Company] ([Id], [Company_En], [Company_Str], [Phone1], [Phone2], [Email], [Wifi], [No_Num], [St_Num], [Sangkat], [Khan], [City], [Province], [Img], [Old_Img], [Created_Date], [Updated_Date], [Deleted_Date], [Created_By_Id], [Created_By_Name], [Updated_By_Id], [Updated_By_Name], [Deleted_By_Id], [Deleted_By_Name], [Deleted], [Default], [Description], [Status]) VALUES (N'1', N'CCNS', N'CCNS', N'098888333', N'087333999', N'ccns@gmail.com.kh', N'9998888', N'268EO', N'589', N'Toul Sangke', N'Russey Keo', N'Phnom Penh', N'Phnom Penh', N'3900a6ade0204bfb8c34cccca690ed6b.png', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'N', N'Y', N'Have a nice day', NULL)
GO

SET IDENTITY_INSERT [dbo].[CCNS_Company] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Dept
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Dept]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Dept]
GO

CREATE TABLE [dbo].[CCNS_Dept] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Dept_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Dept_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Color] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Dept] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Dept]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Dept] ON
GO

INSERT INTO [dbo].[CCNS_Dept] ([Id], [Dept_En], [Dept_Str], [Color], [Deleted], [Status]) VALUES (N'1', N'Logistic & Warehouse', N'Logistic & Warehouse', N'ForestGreen', N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Dept] ([Id], [Dept_En], [Dept_Str], [Color], [Deleted], [Status]) VALUES (N'2', N'Account', N'Account', N'Salmon', N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Dept] ([Id], [Dept_En], [Dept_Str], [Color], [Deleted], [Status]) VALUES (N'3', N'Finance', N'Finance', N'Coral', N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Dept] ([Id], [Dept_En], [Dept_Str], [Color], [Deleted], [Status]) VALUES (N'4', N'IT', N'Information Technology', N'CornflowerBlue', N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Dept] ([Id], [Dept_En], [Dept_Str], [Color], [Deleted], [Status]) VALUES (N'5', N'None', N'None', N'Azure', N'N', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Dept] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_DUOM
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_DUOM]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_DUOM]
GO

CREATE TABLE [dbo].[CCNS_DUOM] (
  [DUoM_Id] bigint IDENTITY(1,1) NOT NULL,
  [GUoM_Id] bigint NOT NULL,
  [UoM_Id] bigint NOT NULL,
  [AltUoMName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [AltQty] decimal(18,6) NOT NULL,
  [BaseUoM_Id] bigint NOT NULL,
  [BaseUoM_Name] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BaseQty] decimal(18,6) NOT NULL,
  [Used] bit NOT NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_DUOM] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Emp
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Emp]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Emp]
GO

CREATE TABLE [dbo].[CCNS_Emp] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Emp_Code] nvarchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Emp_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Gender] nvarchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Join_Date] date NULL,
  [DoB] date NULL,
  [Card_Num] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Email] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Phone1] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Phone2] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Shift_Id] bigint NOT NULL,
  [Shift_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Dept_Id] bigint NOT NULL,
  [Dept_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Post_Id] bigint NOT NULL,
  [Post_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Updated_Date] date NULL,
  [Deleted_Date] date NULL,
  [Created_By_Id] bigint NULL,
  [Created_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_By_Id] bigint NULL,
  [Updated_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_By_Id] bigint NULL,
  [Deleted_By_Name] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [No_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [St_Num] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Sangkat] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Khan] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [City] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Province] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Old_Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Emp] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Emp]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Emp] ON
GO

INSERT INTO [dbo].[CCNS_Emp] ([Id], [Emp_Code], [Emp_Name], [Gender], [Join_Date], [DoB], [Card_Num], [Email], [Phone1], [Phone2], [Shift_Id], [Shift_Str], [Dept_Id], [Dept_Str], [Post_Id], [Post_Str], [Created_Date], [Updated_Date], [Deleted_Date], [Created_By_Id], [Created_By_Name], [Updated_By_Id], [Updated_By_Name], [Deleted_By_Id], [Deleted_By_Name], [No_Num], [St_Num], [Sangkat], [Khan], [City], [Province], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'1', N'0001', N'CCNS', N'Male', N'2020-11-29', N'2020-11-29', N'', N'ccns@gmail.com', N'098738933', N'0968737483', N'1', N'None', N'1', N'IT', N'1', N'Programmer', N'2020-11-29', NULL, NULL, N'1', N'Admin', NULL, NULL, NULL, NULL, N'ST0021', N'St.235', N'Saen Sok', N'Saen Sok', N'Phnom Penh', N'Phnom Penh', N'ce7ee2d651f743159559c9ce491d74df.png', N'ce7ee2d651f743159559c9ce491d74df.png', N'N', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Emp] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Exchange
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Exchange]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Exchange]
GO

CREATE TABLE [dbo].[CCNS_Exchange] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [ExStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Dollar] decimal(18,6) NOT NULL,
  [Riel] decimal(18,6) NOT NULL,
  [Started] date NULL,
  [Start_Time] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [End] date NULL,
  [End_Time] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Exchange] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Exchange]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Exchange] ON
GO

INSERT INTO [dbo].[CCNS_Exchange] ([Id], [ExStr], [Dollar], [Riel], [Started], [Start_Time], [End], [End_Time], [Default], [DocDate], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted]) VALUES (N'1', NULL, N'1.000000', N'4100.000000', N'2020-11-29', N'00:00 am', N'2021-01-29', N'12:59 pm', N'N', N'2020-11-29', N'0', NULL, NULL, NULL, N'0', NULL, NULL, N'0', NULL, N'N')
GO

INSERT INTO [dbo].[CCNS_Exchange] ([Id], [ExStr], [Dollar], [Riel], [Started], [Start_Time], [End], [End_Time], [Default], [DocDate], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted]) VALUES (N'2', NULL, N'1.000000', N'4050.000000', N'2020-11-29', N'00:00 am', N'2020-12-29', N'12:59 pm', N'N', N'2020-11-29', N'0', NULL, NULL, NULL, N'0', NULL, NULL, N'0', NULL, N'N')
GO

INSERT INTO [dbo].[CCNS_Exchange] ([Id], [ExStr], [Dollar], [Riel], [Started], [Start_Time], [End], [End_Time], [Default], [DocDate], [Deleted_By_Id], [Deleted_By_Name], [Deleted_Date], [Created_Date], [Created_By_Id], [Created_By_Name], [Updated_Date], [Updated_By_Id], [Updated_By_Name], [Deleted]) VALUES (N'3', NULL, N'1.000000', N'4000.000000', N'2020-11-29', N'00:00 am', N'2020-12-29', N'12:59 pm', N'Y', N'2020-11-29', N'0', NULL, NULL, NULL, N'0', NULL, NULL, N'0', NULL, N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Exchange] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_GoodsIssue
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_GoodsIssue]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_GoodsIssue]
GO

CREATE TABLE [dbo].[CCNS_GoodsIssue] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [CreateById] bigint NOT NULL,
  [CreateByName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateDate] date NULL,
  [Amount] decimal(18,6) NOT NULL,
  [Description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_GoodsIssue] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_GoodsIssue01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_GoodsIssue01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_GoodsIssue01]
GO

CREATE TABLE [dbo].[CCNS_GoodsIssue01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [DocEntry] bigint NOT NULL,
  [LineNum] int NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NULL,
  [UoMId] bigint NULL,
  [UoMStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NULL,
  [GUoMStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [WhsId] bigint NULL,
  [WhsStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TotalLine] decimal(18,6) NULL,
  [VendorId] bigint NULL,
  [VendorStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] date NULL
)
GO

ALTER TABLE [dbo].[CCNS_GoodsIssue01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_GoodsReceipt
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_GoodsReceipt]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_GoodsReceipt]
GO

CREATE TABLE [dbo].[CCNS_GoodsReceipt] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [CreateById] bigint NOT NULL,
  [CreateByName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateDate] date NULL,
  [Amount] decimal(18,6) NOT NULL,
  [Description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_GoodsReceipt] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_GoodsReceipt01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_GoodsReceipt01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_GoodsReceipt01]
GO

CREATE TABLE [dbo].[CCNS_GoodsReceipt01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [DocEntry] bigint NOT NULL,
  [LineNum] int NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NULL,
  [UoMId] bigint NULL,
  [UoMStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NULL,
  [GUoMStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [WhsId] bigint NULL,
  [WhsStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TotalLine] decimal(18,6) NULL,
  [VendorId] bigint NULL,
  [VendorStr] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] date NULL
)
GO

ALTER TABLE [dbo].[CCNS_GoodsReceipt01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Group_Section
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Group_Section]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Group_Section]
GO

CREATE TABLE [dbo].[CCNS_Group_Section] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [GSectionEn] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Floor] int NOT NULL,
  [Description] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Type] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Group_Section] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_GUOM
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_GUOM]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_GUOM]
GO

CREATE TABLE [dbo].[CCNS_GUOM] (
  [GUoM_Id] bigint IDENTITY(1,1) NOT NULL,
  [GUoM_Name] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GUoM_Foreign] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_GUOM] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Invoice
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Invoice]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Invoice]
GO

CREATE TABLE [dbo].[CCNS_Invoice] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [InvCode] bigint NOT NULL,
  [OrderCode] bigint NOT NULL,
  [Floor] int NOT NULL,
  [SectionId] bigint NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Duration] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FreeHour] decimal(18,6) NOT NULL,
  [TotalHour] decimal(18,6) NOT NULL,
  [SectionPrice] decimal(18,6) NOT NULL,
  [SectionAmount] decimal(18,6) NOT NULL,
  [GSectionId] bigint NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SectionTypeId] bigint NOT NULL,
  [SectionTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NOT NULL,
  [TotalDiscUSD] decimal(18,6) NOT NULL,
  [TotalDiscRiel] decimal(18,6) NOT NULL,
  [TaxPrcnt] decimal(18,6) NOT NULL,
  [TotalTaxUSD] decimal(18,6) NOT NULL,
  [TotalTaxRiel] decimal(18,6) NOT NULL,
  [ExchangeRate] decimal(18,6) NOT NULL,
  [ServiceChargeUSD] decimal(18,6) NOT NULL,
  [ServiceChargeRiel] decimal(18,6) NOT NULL,
  [OtherChargeUSD] decimal(18,6) NOT NULL,
  [OtherChargeRiel] decimal(18,6) NOT NULL,
  [ShiftId] bigint NOT NULL,
  [ShiftStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BookingId] bigint NOT NULL,
  [BookingStatus] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ComissionPrcnt] decimal(18,6) NOT NULL,
  [ComissionRate] decimal(18,6) NOT NULL,
  [ComissionUSD] decimal(18,6) NOT NULL,
  [ComssionRiel] decimal(18,6) NOT NULL,
  [ComissionById] decimal(18,6) NOT NULL,
  [ComissionByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SubTotalUSD] decimal(18,6) NOT NULL,
  [SubTotalRiel] decimal(18,6) NOT NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [ReceivedUSD] decimal(18,6) NOT NULL,
  [ReceivedRiel] decimal(18,6) NOT NULL,
  [CreateById] bigint NOT NULL,
  [CreateByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateDate] datetime NULL,
  [DocTime] time(7) NOT NULL,
  [CloseById] bigint NOT NULL,
  [CloseByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CloseDate] datetime NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [PayStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CustomerId] bigint NOT NULL,
  [PayDate] datetime NULL,
  [InvType] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TimeIn] time(7) NULL,
  [TimeOut] time(7) NULL
)
GO

ALTER TABLE [dbo].[CCNS_Invoice] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Invoice01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Invoice01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Invoice01]
GO

CREATE TABLE [dbo].[CCNS_Invoice01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [DocEntry] bigint NOT NULL,
  [OrderById] bigint NOT NULL,
  [OrderByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] datetime NOT NULL,
  [LineNum] int NOT NULL,
  [BaseLine] int NOT NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ItemStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemTypeId] bigint NOT NULL,
  [ItemTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NOT NULL,
  [Currency] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UnitPrice] decimal(18,6) NOT NULL,
  [SizeId] bigint NOT NULL,
  [SizeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NOT NULL,
  [GUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NULL,
  [TotalDiscUSD] decimal(18,6) NULL,
  [TotalDiscRiel] decimal(18,6) NULL,
  [TaxPrcnt] decimal(18,6) NULL,
  [TaxRate] decimal(18,6) NULL,
  [TotalTaxUSD] decimal(18,6) NULL,
  [TotalTaxRiel] decimal(18,6) NULL,
  [TotalLine] decimal(18,6) NOT NULL,
  [WhsId] bigint NOT NULL,
  [WhsStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineStatus] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [LineFree] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Invoice01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Item
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Item]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Item]
GO

CREATE TABLE [dbo].[CCNS_Item] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [ItemCode] nvarchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemEn] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ItemStr] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CateId] bigint NOT NULL,
  [CateStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SubCateL0Id] bigint NOT NULL,
  [SubCateL0Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SubCateL1Id] bigint NOT NULL,
  [SubCateL1Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InStock] decimal(18,6) NOT NULL,
  [GUoMId] bigint NOT NULL,
  [GUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Inv] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InvPch] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InvSale] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SaleUoMId] bigint NOT NULL,
  [SaleUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InvUoMId] bigint NOT NULL,
  [InvUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PchUoMId] bigint NOT NULL,
  [PchUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TaxId] bigint NOT NULL,
  [TaxStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TaxRate] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NOT NULL,
  [SalePrice] decimal(18,6) NOT NULL,
  [QrCodeId] bigint NOT NULL,
  [QrCodeGuidStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Barcode] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PriceListId] bigint NOT NULL,
  [PriceListStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PrintTo] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ManageBy] nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemType] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedDate] date NULL,
  [CreatedDate] date NULL,
  [UpdatedDate] date NULL,
  [CreatedById] bigint NOT NULL,
  [CreatedByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [OldImg] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Item] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Kds
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Kds]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Kds]
GO

CREATE TABLE [dbo].[CCNS_Kds] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [GKdsStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Date] date NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Kds] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Kds]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Kds] ON
GO

INSERT INTO [dbo].[CCNS_Kds] ([Id], [GKdsStr], [Date], [Deleted]) VALUES (N'1', N'Bar', N'2020-11-29', N'N')
GO

INSERT INTO [dbo].[CCNS_Kds] ([Id], [GKdsStr], [Date], [Deleted]) VALUES (N'2', N'Dessert', N'2020-11-29', N'N')
GO

INSERT INTO [dbo].[CCNS_Kds] ([Id], [GKdsStr], [Date], [Deleted]) VALUES (N'3', N'Fried', N'2020-11-29', N'N')
GO

INSERT INTO [dbo].[CCNS_Kds] ([Id], [GKdsStr], [Date], [Deleted]) VALUES (N'4', N'Soup', N'2020-11-29', N'N')
GO

INSERT INTO [dbo].[CCNS_Kds] ([Id], [GKdsStr], [Date], [Deleted]) VALUES (N'5', N'None', N'2020-11-29', N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Kds] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Kds01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Kds01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Kds01]
GO

CREATE TABLE [dbo].[CCNS_Kds01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [KdsStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Type] nvarchar(3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [KdsGroupId] bigint NOT NULL,
  [KdsGroupStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreatedDate] date NULL,
  [UpdatedDate] date NULL,
  [DeletedDate] date NULL,
  [CreateById] bigint NOT NULL,
  [CreateStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [IPConfig] nvarchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GetKdsId] bigint NULL
)
GO

ALTER TABLE [dbo].[CCNS_Kds01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_MenuPermission
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_MenuPermission]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_MenuPermission]
GO

CREATE TABLE [dbo].[CCNS_MenuPermission] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [ParentId] bigint NOT NULL,
  [Name] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Controller] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Action] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [OrderBy] int NULL,
  [Icon] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Type] nvarchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_by] bigint NOT NULL,
  [Created_At] datetime NULL,
  [Updated_by] bigint NULL,
  [Update_At] datetime NULL
)
GO

ALTER TABLE [dbo].[CCNS_MenuPermission] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Order
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Order]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Order]
GO

CREATE TABLE [dbo].[CCNS_Order] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [OrderCode] bigint NOT NULL,
  [CheckInId] bigint NOT NULL,
  [CheckInStr] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Floor] int NOT NULL,
  [SectionId] bigint NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GSectoinId] bigint NOT NULL,
  [GSectoinStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SectionTypeId] bigint NOT NULL,
  [SectionTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Duration] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FreeHour] decimal(18,6) NOT NULL,
  [TotalHour] decimal(18,6) NOT NULL,
  [SectionPrice] decimal(18,6) NOT NULL,
  [SectionAmount] decimal(18,6) NOT NULL,
  [BookingId] bigint NOT NULL,
  [BookingStatus] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ExchangeRate] decimal(18,6) NOT NULL,
  [ServiceChargeUSD] decimal(18,6) NOT NULL,
  [ServiceChargeRiel] decimal(18,6) NOT NULL,
  [OtherChargeUSD] decimal(18,6) NOT NULL,
  [OtherChargeRiel] decimal(18,6) NOT NULL,
  [DiscPrcnt] decimal(18,6) NOT NULL,
  [TotalDiscUSD] decimal(18,6) NOT NULL,
  [TotalDiscRiel] decimal(18,6) NOT NULL,
  [TaxPrcnt] decimal(18,6) NOT NULL,
  [TotalTaxUSD] decimal(18,6) NOT NULL,
  [TotalTaxRiel] decimal(18,6) NOT NULL,
  [SubTotalUSD] decimal(18,6) NOT NULL,
  [SubTotalRiel] decimal(18,6) NOT NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [OrderById] bigint NOT NULL,
  [OrderByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ShiftId] bigint NOT NULL,
  [ShiftStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] datetime NULL,
  [DocTime] time(7) NOT NULL,
  [OrderDate] datetime NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedDate] datetime NULL,
  [CancelById] bigint NOT NULL,
  [CancelByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelDate] datetime NULL,
  [CloseById] bigint NOT NULL,
  [CloseByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CloseDate] datetime NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [OrderStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [OrderType] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TimeIn] time(7) NULL,
  [TimeOut] time(7) NULL
)
GO

ALTER TABLE [dbo].[CCNS_Order] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Order01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Order01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Order01]
GO

CREATE TABLE [dbo].[CCNS_Order01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [LineNumber] int NOT NULL,
  [DocEntry] bigint NOT NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NOT NULL,
  [UnitPrice] decimal(18,6) NOT NULL,
  [Currency] nvarchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NOT NULL,
  [GUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NULL,
  [TotalDiscUSD] decimal(18,6) NULL,
  [TotalDiscRiel] decimal(18,6) NULL,
  [TotalTaxPrcnt] decimal(18,6) NULL,
  [TotalTaxRate] decimal(18,6) NULL,
  [TotalTaxUSD] decimal(18,6) NULL,
  [TotalTaxRiel] decimal(18,6) NULL,
  [TotalLine] decimal(18,6) NOT NULL,
  [UpdateById] bigint NOT NULL,
  [UpdateByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedDate] datetime NULL,
  [CancelById] bigint NOT NULL,
  [CancelByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelDate] datetime NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [BillStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [LineFree] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Description] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Order01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Payment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Payment]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Payment]
GO

CREATE TABLE [dbo].[CCNS_Payment] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [PaymentCode] bigint NOT NULL,
  [DiscPrcnt] decimal(18,6) NOT NULL,
  [TotalDiscUSD] decimal(18,6) NOT NULL,
  [TotalDiscRiel] decimal(18,6) NOT NULL,
  [TaxPrcnt] decimal(18,6) NOT NULL,
  [TotalTaxUSD] decimal(18,6) NOT NULL,
  [TotalTaxRiel] decimal(18,6) NOT NULL,
  [ExchangeRate] decimal(18,6) NOT NULL,
  [ShiftId] bigint NOT NULL,
  [ShiftStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ServiceChargeUSD] decimal(18,6) NOT NULL,
  [ServiceChargeRiel] decimal(18,6) NOT NULL,
  [OtherChargeUSD] decimal(18,6) NOT NULL,
  [OtherChargeRiel] decimal(18,6) NOT NULL,
  [SubTotalUSD] decimal(18,6) NOT NULL,
  [SubTotalRiel] decimal(18,6) NOT NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [ReceivedUSD] decimal(18,6) NOT NULL,
  [ReceivedRiel] decimal(18,6) NOT NULL,
  [ComissionPrcn] decimal(18,6) NOT NULL,
  [ComissionRate] decimal(18,6) NOT NULL,
  [ComissionUSD] decimal(18,6) NOT NULL,
  [ComissionRiel] decimal(18,6) NOT NULL,
  [ComissionById] bigint NOT NULL,
  [ComissionByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BookingId] bigint NOT NULL,
  [BookingStatus] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [PaymentDate] datetime NULL,
  [PaidDate] datetime NULL,
  [ReceivedById] bigint NOT NULL,
  [ReceivedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MethodTypeId] bigint NOT NULL,
  [MethodTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CancelDate] datetime NULL,
  [CancelById] bigint NOT NULL,
  [CancelByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PayType] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Received_USD] decimal(18,6) NOT NULL,
  [Received_Riel] decimal(18,6) NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_Payment] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Payment01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Payment01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Payment01]
GO

CREATE TABLE [dbo].[CCNS_Payment01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [DocEntry] bigint NOT NULL,
  [InvCode] bigint NOT NULL,
  [OrderCode] bigint NOT NULL,
  [OrderById] bigint NOT NULL,
  [OrderByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Floor] int NOT NULL,
  [SectionId] bigint NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [GSectionId] bigint NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SectionTypeId] bigint NOT NULL,
  [SectionTypeStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [FreeHour] decimal(18,6) NOT NULL,
  [DocDate] datetime NULL,
  [LineNumber] int NOT NULL,
  [BaseLine] int NOT NULL,
  [RefLine] int NOT NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ItemStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ItemType] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NOT NULL,
  [Currency] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UnitPrice] decimal(18,6) NOT NULL,
  [UoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NOT NULL,
  [GUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [WhsId] bigint NOT NULL,
  [WhsStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NULL,
  [TotalDiscUSD] decimal(18,6) NULL,
  [TotalDiscRiel] decimal(18,6) NULL,
  [TaxPrcnt] decimal(18,6) NULL,
  [TaxRate] decimal(18,6) NULL,
  [TotalTaxUSD] decimal(18,6) NULL,
  [TotalTaxRiel] decimal(18,6) NULL,
  [TotalLine] decimal(18,6) NOT NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineFree] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Payment01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_PaymentMethod
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_PaymentMethod]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_PaymentMethod]
GO

CREATE TABLE [dbo].[CCNS_PaymentMethod] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [MethodEn] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MethodStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Description] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_PaymentMethod] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Permission
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Permission]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Permission]
GO

CREATE TABLE [dbo].[CCNS_Permission] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Permis_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Create] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Update] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Delete] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Read] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Level] int NOT NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Permission] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Permission]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Permission] ON
GO

INSERT INTO [dbo].[CCNS_Permission] ([Id], [Permis_En], [Create], [Update], [Delete], [Read], [Level], [Status], [Deleted]) VALUES (N'1', N'None', N'N', N'N', N'N', N'Y', N'0', N'Y', N'N')
GO

INSERT INTO [dbo].[CCNS_Permission] ([Id], [Permis_En], [Create], [Update], [Delete], [Read], [Level], [Status], [Deleted]) VALUES (N'2', N'Read-Only', N'N', N'N', N'N', N'Y', N'1', N'Y', N'N')
GO

INSERT INTO [dbo].[CCNS_Permission] ([Id], [Permis_En], [Create], [Update], [Delete], [Read], [Level], [Status], [Deleted]) VALUES (N'3', N'Read-Write', N'Y', N'N', N'N', N'Y', N'2', N'Y', N'N')
GO

INSERT INTO [dbo].[CCNS_Permission] ([Id], [Permis_En], [Create], [Update], [Delete], [Read], [Level], [Status], [Deleted]) VALUES (N'4', N'Read-Write', N'Y', N'Y', N'N', N'Y', N'3', N'Y', N'N')
GO

INSERT INTO [dbo].[CCNS_Permission] ([Id], [Permis_En], [Create], [Update], [Delete], [Read], [Level], [Status], [Deleted]) VALUES (N'5', N'Read-Write', N'Y', N'Y', N'Y', N'Y', N'4', N'Y', N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Permission] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Permission01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Permission01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Permission01]
GO

CREATE TABLE [dbo].[CCNS_Permission01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Perm_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocEntry] bigint NOT NULL,
  [Permis_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Role_Id] bigint NOT NULL,
  [Role_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Level] int NOT NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Permission01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Permission01]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Permission01] ON
GO

INSERT INTO [dbo].[CCNS_Permission01] ([Id], [Perm_En], [DocEntry], [Permis_Str], [Role_Id], [Role_Str], [Level], [Status], [Deleted]) VALUES (N'1', N'Programmer', N'1', N'Read-Write', N'2', N'Admin', N'0', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Permission01] ([Id], [Perm_En], [DocEntry], [Permis_Str], [Role_Id], [Role_Str], [Level], [Status], [Deleted]) VALUES (N'2', N'Cashier', N'2', N'Read-Write', N'4', N'User', N'0', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Permission01] ([Id], [Perm_En], [DocEntry], [Permis_Str], [Role_Id], [Role_Str], [Level], [Status], [Deleted]) VALUES (N'3', N'Order', N'2', N'Read-Only', N'4', N'User', N'0', N'Y', NULL)
GO

SET IDENTITY_INSERT [dbo].[CCNS_Permission01] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Position
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Position]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Position]
GO

CREATE TABLE [dbo].[CCNS_Position] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Position_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Position_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Dept_Id] bigint NOT NULL,
  [Color] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Position] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Position]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Position] ON
GO

INSERT INTO [dbo].[CCNS_Position] ([Id], [Position_En], [Position_Str], [Dept_Id], [Color], [Deleted], [Status]) VALUES (N'1', N'Cashier', N'Cashier', N'3', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Position] ([Id], [Position_En], [Position_Str], [Dept_Id], [Color], [Deleted], [Status]) VALUES (N'2', N'Programmer', N'Programmer', N'5', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_Position] ([Id], [Position_En], [Position_Str], [Dept_Id], [Color], [Deleted], [Status]) VALUES (N'3', N'None', N'None', N'1', NULL, N'N', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Position] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_PriceList
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_PriceList]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_PriceList]
GO

CREATE TABLE [dbo].[CCNS_PriceList] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [PriceList_En] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PriceList_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_PriceList] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_PriceList01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_PriceList01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_PriceList01]
GO

CREATE TABLE [dbo].[CCNS_PriceList01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [PriceList_Id] bigint NOT NULL,
  [Item_Id] bigint NOT NULL,
  [Item_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UoM_ID] bigint NOT NULL,
  [UoM_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Price_USD] decimal(18,6) NOT NULL,
  [Price_Riel] decimal(18,6) NOT NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_PriceList01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Purchase
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Purchase]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Purchase]
GO

CREATE TABLE [dbo].[CCNS_Purchase] (
  [DocEntry] bigint IDENTITY(1,1) NOT NULL,
  [PchCode] bigint NOT NULL,
  [InvCode] nvarchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NULL,
  [DiscTotal] decimal(18,6) NULL,
  [TaxPrcnt] decimal(18,6) NULL,
  [TaxTotal] decimal(18,6) NULL,
  [SubTotalUSD] decimal(18,6) NOT NULL,
  [SubTotalRiel] decimal(18,6) NOT NULL,
  [DepositedUSD] decimal(18,6) NULL,
  [DepositedRiel] decimal(18,6) NULL,
  [GrandTotalUSD] decimal(18,6) NOT NULL,
  [GrandTotalRiel] decimal(18,6) NOT NULL,
  [VendorId] bigint NOT NULL,
  [VendorStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateById] bigint NULL,
  [CreateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeleteById] bigint NULL,
  [DeleteByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdateById] bigint NULL,
  [UpdateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CreateDate] date NULL,
  [UpdateDate] date NULL,
  [DeleteDate] date NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [PurchaseDate] datetime2(7) NOT NULL
)
GO

ALTER TABLE [dbo].[CCNS_Purchase] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Purchase01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Purchase01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Purchase01]
GO

CREATE TABLE [dbo].[CCNS_Purchase01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [DocEntry] bigint NOT NULL,
  [LineNum] int NOT NULL,
  [ItemId] bigint NOT NULL,
  [ItemCode] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemStr] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [Cost] decimal(18,6) NOT NULL,
  [UnitPrice] decimal(18,6) NULL,
  [Currentcy] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DiscPrcnt] decimal(18,6) NULL,
  [DiscTotal] decimal(18,6) NULL,
  [UoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GUoMId] bigint NOT NULL,
  [GUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [WhsId] bigint NOT NULL,
  [WhsStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TotalLine] decimal(18,6) NOT NULL,
  [VendorId] bigint NOT NULL,
  [VendorStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DocDate] date NOT NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Purchase01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_QRCoders
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_QRCoders]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_QRCoders]
GO

CREATE TABLE [dbo].[CCNS_QRCoders] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [GuidCode] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Date] date NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_QRCoders] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Role]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Role]
GO

CREATE TABLE [dbo].[CCNS_Role] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Role_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Role]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Role] ON
GO

INSERT INTO [dbo].[CCNS_Role] ([Id], [Role_En], [Status], [Deleted]) VALUES (N'1', N'Supper Admin', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Role] ([Id], [Role_En], [Status], [Deleted]) VALUES (N'2', N'Admin', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Role] ([Id], [Role_En], [Status], [Deleted]) VALUES (N'3', N'Manager', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Role] ([Id], [Role_En], [Status], [Deleted]) VALUES (N'4', N'User', N'Y', NULL)
GO

INSERT INTO [dbo].[CCNS_Role] ([Id], [Role_En], [Status], [Deleted]) VALUES (N'5', N'None', N'N', NULL)
GO

SET IDENTITY_INSERT [dbo].[CCNS_Role] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_SectionType
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_SectionType]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_SectionType]
GO

CREATE TABLE [dbo].[CCNS_SectionType] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Type] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_SectionType] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_SectionType]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_SectionType] ON
GO

INSERT INTO [dbo].[CCNS_SectionType] ([Id], [Type], [Status]) VALUES (N'1', N'VIP', N'Y')
GO

INSERT INTO [dbo].[CCNS_SectionType] ([Id], [Type], [Status]) VALUES (N'2', N'Normal', N'Y')
GO

INSERT INTO [dbo].[CCNS_SectionType] ([Id], [Type], [Status]) VALUES (N'3', N'None', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_SectionType] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Serail
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Serail]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Serail]
GO

CREATE TABLE [dbo].[CCNS_Serail] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [SerailNum] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ItemId] bigint NOT NULL,
  [ItemName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Quantity] decimal(18,6) NOT NULL,
  [SaleQty] decimal(18,6) NOT NULL,
  [SaleUoMId] bigint NOT NULL,
  [SaleUoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UoMId] bigint NOT NULL,
  [UoMStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [MFG] datetime NULL,
  [CreatedDate] datetime2(7) NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedDate] datetime NULL,
  [CreatedById] bigint NOT NULL,
  [CreatedByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedDate] datetime NULL,
  [UpdatedById] bigint NULL,
  [UpdateByName] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Serail] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_SetPermission
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_SetPermission]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_SetPermission]
GO

CREATE TABLE [dbo].[CCNS_SetPermission] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [MenuId] bigint NOT NULL,
  [UserId] bigint NOT NULL,
  [Status] nvarchar(35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_by] bigint NOT NULL,
  [Created_At] datetime NULL,
  [Updated_by] bigint NULL,
  [Update_At] datetime NULL
)
GO

ALTER TABLE [dbo].[CCNS_SetPermission] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Shift
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Shift]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Shift]
GO

CREATE TABLE [dbo].[CCNS_Shift] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Shift_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Hour] int NOT NULL,
  [StartHour] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [EndHour] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Shift] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Shift]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Shift] ON
GO

INSERT INTO [dbo].[CCNS_Shift] ([Id], [Shift_Str], [Hour], [StartHour], [EndHour], [LineStatus], [Deleted]) VALUES (N'1', N'Shift 3', N'8', N'10:00 pm', N'06:00 am', NULL, N'N')
GO

INSERT INTO [dbo].[CCNS_Shift] ([Id], [Shift_Str], [Hour], [StartHour], [EndHour], [LineStatus], [Deleted]) VALUES (N'2', N'Shift 2', N'8', N'02:00 pm', N'10:00 pm', NULL, N'N')
GO

INSERT INTO [dbo].[CCNS_Shift] ([Id], [Shift_Str], [Hour], [StartHour], [EndHour], [LineStatus], [Deleted]) VALUES (N'3', N'Shift 1', N'8', N'06:00 am', N'02:00 pm', NULL, N'N')
GO

INSERT INTO [dbo].[CCNS_Shift] ([Id], [Shift_Str], [Hour], [StartHour], [EndHour], [LineStatus], [Deleted]) VALUES (N'4', N'None', N'0', N'0', N'0', NULL, N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Shift] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_SubCategoryL1
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_SubCategoryL1]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_SubCategoryL1]
GO

CREATE TABLE [dbo].[CCNS_SubCategoryL1] (
  [SubCateL1_Id] bigint IDENTITY(1,1) NOT NULL,
  [SubCateL1_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [SubCateL1_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ColorL1] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Cate_Id] bigint NOT NULL,
  [Cate_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_SubCategoryL1] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_SubCategoryL2
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_SubCategoryL2]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_SubCategoryL2]
GO

CREATE TABLE [dbo].[CCNS_SubCategoryL2] (
  [SubCateL2_Id] bigint IDENTITY(1,1) NOT NULL,
  [SubCateL2_En] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [SubCateL2_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [ColorL2] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [SubCateL1_Id] bigint NOT NULL,
  [SubCateL1_Str] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_SubCategoryL2] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Tax
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Tax]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Tax]
GO

CREATE TABLE [dbo].[CCNS_Tax] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [TaxStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Rate] decimal(18,6) NOT NULL,
  [CreatedDate] date NULL,
  [UpdatedDate] date NULL,
  [DeletedDate] date NULL,
  [CreateById] bigint NOT NULL,
  [CreateStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Tax] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_Tax]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_Tax] ON
GO

INSERT INTO [dbo].[CCNS_Tax] ([Id], [TaxStr], [Rate], [CreatedDate], [UpdatedDate], [DeletedDate], [CreateById], [CreateStr], [UpdatedById], [UpdatedByStr], [DeletedById], [DeletedByStr], [Default], [Deleted]) VALUES (N'1', N'25%', N'25.000000', N'2020-11-29', NULL, NULL, N'1', N'Admin', N'0', NULL, N'0', NULL, N'N', N'N')
GO

INSERT INTO [dbo].[CCNS_Tax] ([Id], [TaxStr], [Rate], [CreatedDate], [UpdatedDate], [DeletedDate], [CreateById], [CreateStr], [UpdatedById], [UpdatedByStr], [DeletedById], [DeletedByStr], [Default], [Deleted]) VALUES (N'2', N'15%', N'15.000000', N'2020-11-29', NULL, NULL, N'1', N'Admin', N'0', NULL, N'0', NULL, N'N', N'N')
GO

INSERT INTO [dbo].[CCNS_Tax] ([Id], [TaxStr], [Rate], [CreatedDate], [UpdatedDate], [DeletedDate], [CreateById], [CreateStr], [UpdatedById], [UpdatedByStr], [DeletedById], [DeletedByStr], [Default], [Deleted]) VALUES (N'3', N'10%', N'10.000000', N'2020-11-29', NULL, NULL, N'1', N'Admin', N'0', NULL, N'0', NULL, N'N', N'N')
GO

INSERT INTO [dbo].[CCNS_Tax] ([Id], [TaxStr], [Rate], [CreatedDate], [UpdatedDate], [DeletedDate], [CreateById], [CreateStr], [UpdatedById], [UpdatedByStr], [DeletedById], [DeletedByStr], [Default], [Deleted]) VALUES (N'4', N'0%', N'0.000000', N'2020-11-29', NULL, NULL, N'1', N'Admin', N'0', NULL, N'0', NULL, N'N', N'N')
GO

SET IDENTITY_INSERT [dbo].[CCNS_Tax] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_UoM
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_UoM]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_UoM]
GO

CREATE TABLE [dbo].[CCNS_UoM] (
  [UoM_Id] bigint IDENTITY(1,1) NOT NULL,
  [UoM_Name] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [UoM_Foreign] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_UoM] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_User]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_User]
GO

CREATE TABLE [dbo].[CCNS_User] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Emp_Id] bigint NOT NULL,
  [Emp_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Username] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Password] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [New_Password] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Old_Password] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Email] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Phone] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Role_Id] bigint NOT NULL,
  [Permis_Id] bigint NULL,
  [CreateDate] date NOT NULL,
  [CreateById] bigint NOT NULL,
  [CreateByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [UpdateDate] date NULL,
  [UpdateById] bigint NOT NULL,
  [UpdateByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeleteDate] date NULL,
  [DeleteById] bigint NOT NULL,
  [DeleteByName] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Old_Img] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of [CCNS_User]
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[CCNS_User] ON
GO

INSERT INTO [dbo].[CCNS_User] ([Id], [Emp_Id], [Emp_Name], [Username], [Password], [New_Password], [Old_Password], [Email], [Phone], [Role_Id], [Permis_Id], [CreateDate], [CreateById], [CreateByName], [UpdateDate], [UpdateById], [UpdateByName], [DeleteDate], [DeleteById], [DeleteByName], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'1', N'1', N'Admin', N'Admin05', N'B509A277F2C72469A920D90D46667763A88200BB', NULL, NULL, N'ccns@gamil.com', N'098767757', N'2', N'1', N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, NULL, N'0', NULL, N'ce7ee2d651f743159559c9ce491d74df.png', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_User] ([Id], [Emp_Id], [Emp_Name], [Username], [Password], [New_Password], [Old_Password], [Email], [Phone], [Role_Id], [Permis_Id], [CreateDate], [CreateById], [CreateByName], [UpdateDate], [UpdateById], [UpdateByName], [DeleteDate], [DeleteById], [DeleteByName], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'2', N'1', N'Admin', N'Admin04', N'B509A277F2C72469A920D90D46667763A88200BB', NULL, NULL, N'ccns@gamil.com', N'098767757', N'2', N'1', N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, NULL, N'0', NULL, N'ce7ee2d651f743159559c9ce491d74df.png', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_User] ([Id], [Emp_Id], [Emp_Name], [Username], [Password], [New_Password], [Old_Password], [Email], [Phone], [Role_Id], [Permis_Id], [CreateDate], [CreateById], [CreateByName], [UpdateDate], [UpdateById], [UpdateByName], [DeleteDate], [DeleteById], [DeleteByName], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'3', N'1', N'Admin', N'Admin03', N'B509A277F2C72469A920D90D46667763A88200BB', NULL, NULL, N'ccns@gamil.com', N'098767757', N'2', N'1', N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, NULL, N'0', NULL, N'ce7ee2d651f743159559c9ce491d74df.png', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_User] ([Id], [Emp_Id], [Emp_Name], [Username], [Password], [New_Password], [Old_Password], [Email], [Phone], [Role_Id], [Permis_Id], [CreateDate], [CreateById], [CreateByName], [UpdateDate], [UpdateById], [UpdateByName], [DeleteDate], [DeleteById], [DeleteByName], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'4', N'1', N'Admin', N'Admin02', N'B509A277F2C72469A920D90D46667763A88200BB', NULL, NULL, N'ccns@gamil.com', N'098767757', N'2', N'1', N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, NULL, N'0', NULL, N'ce7ee2d651f743159559c9ce491d74df.png', NULL, N'N', N'Y')
GO

INSERT INTO [dbo].[CCNS_User] ([Id], [Emp_Id], [Emp_Name], [Username], [Password], [New_Password], [Old_Password], [Email], [Phone], [Role_Id], [Permis_Id], [CreateDate], [CreateById], [CreateByName], [UpdateDate], [UpdateById], [UpdateByName], [DeleteDate], [DeleteById], [DeleteByName], [Img], [Old_Img], [Deleted], [Status]) VALUES (N'5', N'1', N'Admin01', N'Admin', N'B509A277F2C72469A920D90D46667763A88200BB', NULL, NULL, N'ccns@gamil.com', N'098767757', N'2', N'1', N'2020-11-29', N'1', N'Admin', NULL, N'0', NULL, NULL, N'0', NULL, N'ce7ee2d651f743159559c9ce491d74df.png', NULL, N'N', N'Y')
GO

SET IDENTITY_INSERT [dbo].[CCNS_User] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for CCNS_Whs
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Whs]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Whs]
GO

CREATE TABLE [dbo].[CCNS_Whs] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Whs_En] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Whs_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InStock] decimal(18,6) NOT NULL,
  [Default] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Address] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Remark] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Whs] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CCNS_Whs01
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CCNS_Whs01]') AND type IN ('U'))
	DROP TABLE [dbo].[CCNS_Whs01]
GO

CREATE TABLE [dbo].[CCNS_Whs01] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [WhsId] bigint NOT NULL,
  [Item_Id] bigint NOT NULL,
  [Item_Str] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [InStock] decimal(18,6) NOT NULL,
  [Deleted_By_Id] bigint NOT NULL,
  [Deleted_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted_Date] date NULL,
  [Created_Date] date NULL,
  [Created_By_Id] bigint NOT NULL,
  [Created_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Updated_Date] date NULL,
  [Updated_By_Id] bigint NOT NULL,
  [Updated_By_Name] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CCNS_Whs01] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CNNS_CommissionExtension
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CNNS_CommissionExtension]') AND type IN ('U'))
	DROP TABLE [dbo].[CNNS_CommissionExtension]
GO

CREATE TABLE [dbo].[CNNS_CommissionExtension] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [Title] nvarchar(225) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CommissionPrcnt] nvarchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Rate] decimal(18,6) NOT NULL,
  [CommissionValue] decimal(18,6) NOT NULL,
  [Status] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO

ALTER TABLE [dbo].[CNNS_CommissionExtension] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for CNNS_Section
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[CNNS_Section]') AND type IN ('U'))
	DROP TABLE [dbo].[CNNS_Section]
GO

CREATE TABLE [dbo].[CNNS_Section] (
  [Id] bigint IDENTITY(1,1) NOT NULL,
  [SectionEn] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [SectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [GSectionId] bigint NOT NULL,
  [GSectionStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [TypeId] bigint NOT NULL,
  [CreatedDate] date NULL,
  [UpdatedDate] date NULL,
  [DeletedDate] date NULL,
  [CreatedById] bigint NOT NULL,
  [CreateByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [UpdatedById] bigint NOT NULL,
  [UpdatedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [DeletedById] bigint NOT NULL,
  [DeletedByStr] nvarchar(125) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [LineStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [BookingStatus] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [Deleted] nvarchar(1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
  [CheckInId] bigint NOT NULL,
  [BookingId] bigint NOT NULL,
  [Price] decimal(18,6) NOT NULL,
  [GroupSectionId] bigint NULL
)
GO

ALTER TABLE [dbo].[CNNS_Section] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_AsignUser
-- ----------------------------
ALTER TABLE [dbo].[CCNS_AsignUser] ADD CONSTRAINT [PK_CCNS_AsignUser] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_AutoNumber
-- ----------------------------
ALTER TABLE [dbo].[CCNS_AutoNumber] ADD CONSTRAINT [PK_CCNS_AutoNumber] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Batch
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Batch] ADD CONSTRAINT [PK_CCNS_Batch] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Booking_Section
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Booking_Section] ADD CONSTRAINT [PK_CCNS_Booking_Section] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table CCNS_Branch
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_CCNS_Branch_CompanyId]
ON [dbo].[CCNS_Branch] (
  [CompanyId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Branch
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Branch] ADD CONSTRAINT [PK_CCNS_Branch] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_BusinessPartner
-- ----------------------------
ALTER TABLE [dbo].[CCNS_BusinessPartner] ADD CONSTRAINT [PK_CCNS_BusinessPartner] PRIMARY KEY CLUSTERED ([VendorId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_CashIn
-- ----------------------------
ALTER TABLE [dbo].[CCNS_CashIn] ADD CONSTRAINT [PK_CCNS_CashIn] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table CCNS_CashOut
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_CCNS_CashOut_CashInId]
ON [dbo].[CCNS_CashOut] (
  [CashInId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table CCNS_CashOut
-- ----------------------------
ALTER TABLE [dbo].[CCNS_CashOut] ADD CONSTRAINT [PK_CCNS_CashOut] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Category
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Category] ADD CONSTRAINT [PK_CCNS_Category] PRIMARY KEY CLUSTERED ([CateId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_CheckIn_Section
-- ----------------------------
ALTER TABLE [dbo].[CCNS_CheckIn_Section] ADD CONSTRAINT [PK_CCNS_CheckIn_Section] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Commission
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Commission] ADD CONSTRAINT [PK_CCNS_Commission] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Company
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Company] ADD CONSTRAINT [PK_CCNS_Company] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Dept
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Dept] ADD CONSTRAINT [PK_CCNS_Dept] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_DUOM
-- ----------------------------
ALTER TABLE [dbo].[CCNS_DUOM] ADD CONSTRAINT [PK_CCNS_DUOM] PRIMARY KEY CLUSTERED ([DUoM_Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Emp
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Emp] ADD CONSTRAINT [PK_CCNS_Emp] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Exchange
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Exchange] ADD CONSTRAINT [PK_CCNS_Exchange] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_GoodsIssue
-- ----------------------------
ALTER TABLE [dbo].[CCNS_GoodsIssue] ADD CONSTRAINT [PK_CCNS_GoodsIssue] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_GoodsIssue01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_GoodsIssue01] ADD CONSTRAINT [PK_CCNS_GoodsIssue01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_GoodsReceipt
-- ----------------------------
ALTER TABLE [dbo].[CCNS_GoodsReceipt] ADD CONSTRAINT [PK_CCNS_GoodsReceipt] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_GoodsReceipt01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_GoodsReceipt01] ADD CONSTRAINT [PK_CCNS_GoodsReceipt01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Group_Section
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Group_Section] ADD CONSTRAINT [PK_CCNS_Group_Section] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_GUOM
-- ----------------------------
ALTER TABLE [dbo].[CCNS_GUOM] ADD CONSTRAINT [PK_CCNS_GUOM] PRIMARY KEY CLUSTERED ([GUoM_Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Invoice
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Invoice] ADD CONSTRAINT [PK_CCNS_Invoice] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Invoice01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Invoice01] ADD CONSTRAINT [PK_CCNS_Invoice01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Item
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Item] ADD CONSTRAINT [PK_CCNS_Item] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Kds
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Kds] ADD CONSTRAINT [PK_CCNS_Kds] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table CCNS_Kds01
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_CCNS_Kds01_GetKdsId]
ON [dbo].[CCNS_Kds01] (
  [GetKdsId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Kds01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Kds01] ADD CONSTRAINT [PK_CCNS_Kds01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_MenuPermission
-- ----------------------------
ALTER TABLE [dbo].[CCNS_MenuPermission] ADD CONSTRAINT [PK_CCNS_MenuPermission] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Order
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Order] ADD CONSTRAINT [PK_CCNS_Order] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Order01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Order01] ADD CONSTRAINT [PK_CCNS_Order01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Payment
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Payment] ADD CONSTRAINT [PK_CCNS_Payment] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Payment01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Payment01] ADD CONSTRAINT [PK_CCNS_Payment01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_PaymentMethod
-- ----------------------------
ALTER TABLE [dbo].[CCNS_PaymentMethod] ADD CONSTRAINT [PK_CCNS_PaymentMethod] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Permission
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Permission] ADD CONSTRAINT [PK_CCNS_Permission] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Permission01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Permission01] ADD CONSTRAINT [PK_CCNS_Permission01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Position
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Position] ADD CONSTRAINT [PK_CCNS_Position] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_PriceList
-- ----------------------------
ALTER TABLE [dbo].[CCNS_PriceList] ADD CONSTRAINT [PK_CCNS_PriceList] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_PriceList01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_PriceList01] ADD CONSTRAINT [PK_CCNS_PriceList01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Purchase
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Purchase] ADD CONSTRAINT [PK_CCNS_Purchase] PRIMARY KEY CLUSTERED ([DocEntry])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Purchase01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Purchase01] ADD CONSTRAINT [PK_CCNS_Purchase01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_QRCoders
-- ----------------------------
ALTER TABLE [dbo].[CCNS_QRCoders] ADD CONSTRAINT [PK_CCNS_QRCoders] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Role
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Role] ADD CONSTRAINT [PK_CCNS_Role] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_SectionType
-- ----------------------------
ALTER TABLE [dbo].[CCNS_SectionType] ADD CONSTRAINT [PK_CCNS_SectionType] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Serail
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Serail] ADD CONSTRAINT [PK_CCNS_Serail] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_SetPermission
-- ----------------------------
ALTER TABLE [dbo].[CCNS_SetPermission] ADD CONSTRAINT [PK_CCNS_SetPermission] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Shift
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Shift] ADD CONSTRAINT [PK_CCNS_Shift] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_SubCategoryL1
-- ----------------------------
ALTER TABLE [dbo].[CCNS_SubCategoryL1] ADD CONSTRAINT [PK_CCNS_SubCategoryL1] PRIMARY KEY CLUSTERED ([SubCateL1_Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_SubCategoryL2
-- ----------------------------
ALTER TABLE [dbo].[CCNS_SubCategoryL2] ADD CONSTRAINT [PK_CCNS_SubCategoryL2] PRIMARY KEY CLUSTERED ([SubCateL2_Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Tax
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Tax] ADD CONSTRAINT [PK_CCNS_Tax] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_UoM
-- ----------------------------
ALTER TABLE [dbo].[CCNS_UoM] ADD CONSTRAINT [PK_CCNS_UoM] PRIMARY KEY CLUSTERED ([UoM_Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_User
-- ----------------------------
ALTER TABLE [dbo].[CCNS_User] ADD CONSTRAINT [PK_CCNS_User] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Whs
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Whs] ADD CONSTRAINT [PK_CCNS_Whs] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CCNS_Whs01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Whs01] ADD CONSTRAINT [PK_CCNS_Whs01] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table CNNS_CommissionExtension
-- ----------------------------
ALTER TABLE [dbo].[CNNS_CommissionExtension] ADD CONSTRAINT [PK_CNNS_CommissionExtension] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Indexes structure for table CNNS_Section
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_CNNS_Section_GroupSectionId]
ON [dbo].[CNNS_Section] (
  [GroupSectionId] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table CNNS_Section
-- ----------------------------
ALTER TABLE [dbo].[CNNS_Section] ADD CONSTRAINT [PK_CNNS_Section] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table CCNS_Branch
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Branch] ADD CONSTRAINT [FK_CCNS_Branch_CCNS_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [CCNS_Company] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table CCNS_CashOut
-- ----------------------------
ALTER TABLE [dbo].[CCNS_CashOut] ADD CONSTRAINT [FK_CCNS_CashOut_CCNS_CashIn_CashInId] FOREIGN KEY ([CashInId]) REFERENCES [CCNS_CashIn] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table CCNS_Kds01
-- ----------------------------
ALTER TABLE [dbo].[CCNS_Kds01] ADD CONSTRAINT [FK_CCNS_Kds01_CCNS_Kds_GetKdsId] FOREIGN KEY ([GetKdsId]) REFERENCES [CCNS_Kds] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table CNNS_Section
-- ----------------------------
ALTER TABLE [dbo].[CNNS_Section] ADD CONSTRAINT [FK_CNNS_Section_CCNS_Group_Section_GroupSectionId] FOREIGN KEY ([GroupSectionId]) REFERENCES [CCNS_Group_Section] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

