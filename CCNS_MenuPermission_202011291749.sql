INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (1,0,'Administator','home','index',2,'feather icon-users f-34 text-c-white social-icon','Module','This is dashboard for administrator','A',1,'2020-11-24 22:14:26.937',NULL,NULL),
	 (2,1,'Company','Company','Add',3,'feather icon-layers','Function','company','A',1,'2020-11-24 22:21:42.583',NULL,NULL),
	 (4,1,'Authentication','Account','Authentication',1,'feather icon-unlock','Function','Authentication','A',0,NULL,1,'2020-11-24 23:29:41.417'),
	 (5,4,'User Logic Lists','Account','CreateUserAccount',4,NULL,'Sub-Function','User Logic Lists','A',1,'2020-11-24 23:31:33.073',NULL,NULL),
	 (6,4,'Menu','Account','MenuPermission',5,NULL,'Sub-Function','Menu','A',1,'2020-11-24 23:33:21.367',NULL,NULL),
	 (7,1,'User Account','Account','User Account',5,'feather icon-users','Function','User Account','A',1,'2020-11-24 23:37:54.28',NULL,NULL),
	 (8,7,'Create New','Employee','AddNew',6,NULL,'Sub-Function',NULL,'A',1,'2020-11-24 23:38:54.97',NULL,NULL),
	 (9,7,'User Lists','Employee','EmployeeList',7,NULL,'Sub-Function',NULL,'A',1,'2020-11-24 23:40:12.377',NULL,NULL),
	 (10,0,'Purchase','Inventory','index',6,'feather icon-edit f-34 text-c-white social-icon','Module','This is dashboard for purchase','A',0,NULL,1,'2020-11-29 17:25:09.123'),
	 (11,10,'Business Partners','BusinessPartners','BusinessPartners',7,'feather icon-users','Function','Business Partners','A',1,'2020-11-26 20:49:50.89',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (12,11,'Add New','BusinessPartners','BPN_Add',9,'feather icon-users','Sub-Function','Add New Business Partner','A',1,'2020-11-26 20:51:24.877',NULL,NULL),
	 (13,11,'Partners List','BusinessPartners','BPN_List',10,'feather icon-users','Sub-Function','Partners List','A',1,'2020-11-26 20:52:19.817',NULL,NULL),
	 (14,4,'Set Permission','Account','Set_Permission',5,NULL,'Sub-Function','Set Permission','A',1,'2020-11-29 15:26:59.31',NULL,NULL),
	 (15,0,'Order','orders','order',2,'feather icon-shopping-cart f-34 text-c-white social-icon','Module','This is dashboard for order','A',1,'2020-11-29 16:05:45.303',NULL,NULL),
	 (16,0,'POS','pos','sections',3,'feather icon-user f-34 text-c-white social-icon','Module','This is dashboard for cashier','A',1,'2020-11-29 16:07:23.133',NULL,NULL),
	 (17,0,'Inventory','Products','index',4,'feather icon-feather f-34 text-c-white social-icon','Module','This is dashboard for purchase','A',0,NULL,1,'2020-11-29 17:32:42.603'),
	 (18,0,'Reports','dashboard','report',6,'feather icon-clock text-white f-34 m-r-10','Module','This is dashboard for reported','A',1,'2020-11-29 16:11:58.627',NULL,NULL),
	 (19,1,'Shift','Employee','AddNewShift',5,'feather icon-sidebar','Function','Shift','A',1,'2020-11-29 16:26:10.283',NULL,NULL),
	 (20,1,'Exchange Rate','ExchRates','List',7,'feather icon-layers','Function','Exchange Rate','A',1,'2020-11-29 16:26:55.203',NULL,NULL),
	 (21,1,'Section','Sections','Section',8,'feather icon-layers','Function','Section','A',1,'2020-11-29 16:27:56.457',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (22,21,'Group Section','Sections','AddGroupSection',1,'feather icon-layers','Sub-Function','Group Section','A',1,'2020-11-29 16:28:50.493',NULL,NULL),
	 (23,21,'Section','sections','addsection',2,'feather icon-layers','Sub-Function','Section','A',1,'2020-11-29 16:29:28.537',NULL,NULL),
	 (24,18,'Sale Report','report','report',1,'feather icon-credit-card','Function','Sale Report','A',1,'2020-11-29 16:35:49.007',NULL,NULL),
	 (25,24,'Top Sales Report','report','topsales',1,'feather icon-credit-card','Sub-Function','Top Sales Report','A',1,'2020-11-29 16:36:33.36',NULL,NULL),
	 (26,24,'Sale Aging Report','Reports','SaleAgingReport',2,'feather icon-credit-card','Sub-Function','Sale Aging Report','A',1,'2020-11-29 16:37:36.723',NULL,NULL),
	 (27,24,'Sales Report','report','sales',3,'feather icon-credit-card','Sub-Function','Sales Report','A',1,'2020-11-29 16:38:21.863',NULL,NULL),
	 (28,18,'Banking','report','Banking',2,'feather icon-box','Function','Banking','A',1,'2020-11-29 16:40:45.447',NULL,NULL),
	 (29,28,'Aging Report','report','Aging',2,'feather icon-box','Sub-Function','Aging Report','A',1,'2020-11-29 16:42:10.887',NULL,NULL),
	 (30,28,'Invoice Report','Reports','FindReportInvoice',3,'feather icon-box','Sub-Function','Invoice Report','A',1,'2020-11-29 16:43:31.773',NULL,NULL),
	 (31,28,'Payment Report','Reports','FindPaymentReport',4,'feather icon-box','Sub-Function','Payment Report','A',1,'2020-11-29 16:44:49.21',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (32,18,'Commission','commission','commission',3,'feather icon-feather','Function','Commission','A',1,'2020-11-29 16:46:59.033',NULL,NULL),
	 (33,32,'Commossion List','commission','list',1,'feather icon-feather','Sub-Function','Commossion List','A',1,'2020-11-29 16:47:50.18',NULL,NULL),
	 (34,32,'Booking Report','report','booking',2,'feather icon-feather','Sub-Function','Booking Report','A',1,'2020-11-29 16:48:43.767',NULL,NULL),
	 (35,18,'Purchase Report','Purchase','Purchase',4,'feather icon-inbox','Function','Purchase Report','A',1,'2020-11-29 16:49:30.963',NULL,NULL),
	 (36,35,'Purchased Report','Reports','PurchaseReport',1,'feather icon-inbox','Sub-Function','Purchased Report','A',1,'2020-11-29 16:50:15.03',NULL,NULL),
	 (37,18,'Stock Report','report','Stock',1,'feather icon-server','Function','Stock Report','A',1,'2020-11-29 16:52:11.89',NULL,NULL),
	 (38,37,'Inventory Report','report','inventory',2,'feather icon-server','Sub-Function','Inventory Report','A',1,'2020-11-29 16:53:06.243',NULL,NULL),
	 (39,37,'Stock Report','report','stock',3,'feather icon-server','Sub-Function','Stock Report','A',1,'2020-11-29 16:54:28.29',NULL,NULL),
	 (40,37,'Goods Issue Report','report','goodsissue',4,'feather icon-server','Sub-Function','Goods Issue Report','A',1,'2020-11-29 16:55:12.707',NULL,NULL),
	 (41,37,'Goods Receipt Report','report','goodsreceipt',5,'feather icon-server','Sub-Function','Goods Receipt Report','A',1,'2020-11-29 16:55:49.37',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (42,18,'Cash In / Out Report','report','cashinout',6,'feather icon-credit-card','Function','Cash In / Out Report','A',1,'2020-11-29 16:56:54.02',NULL,NULL),
	 (43,42,'Cash In / Out Report','report','cashinout',2,'feather icon-credit-card','Sub-Function','Cash In / Out Report','A',1,'2020-11-29 16:57:50.823',NULL,NULL),
	 (44,17,'Warehouse','Whs','Add',1,'feather icon-layers','Function','Warehouse','A',1,'2020-11-29 17:00:14.937',NULL,NULL),
	 (45,17,'Category','Categories','AddNew',2,'feather icon-layers','Function','Category','A',1,'2020-11-29 17:00:55.197',NULL,NULL),
	 (46,17,'Sub-Category','Categories','CreateSubCateL1',3,'feather icon-layers','Function','Sub-Category','A',1,'2020-11-29 17:01:36.227',NULL,NULL),
	 (47,17,'Sub-Category L1','Categories','CreateSubCateL2',4,'feather icon-layers','Function','Sub-Category L1','A',1,'2020-11-29 17:02:18.65',NULL,NULL),
	 (48,17,'Price List','Products','AddPriceList',6,'feather icon-layers','Function','Price List','A',1,'2020-11-29 17:03:02.217',NULL,NULL),
	 (49,17,'Unit Of Measure','UoMs','UoMs',4,'feather icon-layers','Function','Unit Of Measure','A',1,'2020-11-29 17:03:41.83',NULL,NULL),
	 (50,49,'UoM','UoMs','AddNew',7,'feather icon-layers','Sub-Function','UoM','A',1,'2020-11-29 17:04:25.997',NULL,NULL),
	 (51,49,'Group UoM','UoMs','AddNewGroup',8,'feather icon-layers','Sub-Function','Group UoM','A',1,'2020-11-29 17:05:04.533',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (52,17,'Item','Products','Item',3,'feather icon-layers','Function','Item','A',1,'2020-11-29 17:05:56.44',NULL,NULL),
	 (53,52,'Item Master Data','Products','AddItem',1,NULL,'Sub-Function','Item Master Data','A',1,'2020-11-29 17:06:44.97',NULL,NULL),
	 (54,52,'Item Lists','Products','ItemList',2,'feather icon-layers','Sub-Function','Item Lists','A',1,'2020-11-29 17:07:19.65',NULL,NULL),
	 (55,52,'Set PriceList','PriceLists','PriceList',4,'feather icon-layers','Sub-Function','Set PriceList','A',1,'2020-11-29 17:07:50.623',NULL,NULL),
	 (56,10,'Business Partners','BusinessPartners','BusinessPartners',1,'feather icon-users','Function','BusinessPartners','A',1,'2020-11-29 17:08:50.667',NULL,NULL),
	 (57,56,'Add New','BusinessPartners','BPN_Add',2,'feather icon-users','Sub-Function','BusinessPartners','A',1,'2020-11-29 17:09:37.54',NULL,NULL),
	 (58,56,'BPN Lists','BusinessPartners','BPN_List',3,'feather icon-users','Sub-Function','BusinessPartners','A',1,'2020-11-29 17:10:14.497',NULL,NULL),
	 (59,10,'Purchase','Inventory','Purchase',5,'feather icon-clipboard','Function','Purchase','A',1,'2020-11-29 17:10:56.603',NULL,NULL),
	 (60,59,'Purchase Order','Inventory','Purchase',2,'feather icon-clipboard','Sub-Function','Purchase Order','A',1,'2020-11-29 17:11:51.377',NULL,NULL),
	 (61,59,'Purchase List','Inventory','PurchaseList',4,'feather icon-clipboard','Sub-Function','Purchase List','A',1,'2020-11-29 17:12:39.36',NULL,NULL);
INSERT INTO ktv_22112020.dbo.CCNS_MenuPermission (Id,ParentId,Name,Controller,[Action],OrderBy,Icon,[Type],Description,Status,Created_by,Created_At,Updated_by,Update_At) VALUES
	 (62,10,'Inventory Transaction','Inventory','Transaction',8,'feather icon-book','Function','Inventory Transaction','A',1,'2020-11-29 17:13:21.903',NULL,NULL),
	 (63,62,'Goods Receipt','Inventory','GoodsReceipt',3,'feather icon-book','Sub-Function','Goods Receipt','A',1,'2020-11-29 17:14:04.04',NULL,NULL),
	 (64,62,'Goods Issue','Inventory','GoodsIssue',5,'feather icon-book','Sub-Function','Goods Issue','A',1,'2020-11-29 17:14:42.383',NULL,NULL);