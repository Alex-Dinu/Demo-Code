USE [WideWorldImporters]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Application].[GetOrder]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [Application].[GetOrder]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [Application].[GetOrder]
	@orderId int

As
-- exec [Application].[GetOrder] 45
select ol.OrderID, ol.Description, ol.UnitPrice, cust.CustomerID
from [Sales].[Orders] ord
	Join [Sales].[OrderLines] ol on ol.OrderID = ord.OrderID
	Join [Sales].[Customers] cust on cust.CustomerID = ord.CustomerID

Where 1=1
	And ol.OrderID = @orderId
