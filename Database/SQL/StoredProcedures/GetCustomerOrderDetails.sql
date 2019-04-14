USE [WideWorldImporters]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Application].[GetCustomerOrderDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [Application].[GetCustomerOrderDetails]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [Application].[GetCustomerOrderDetails]
	@personId int

As
-- exec [Application].[GetCustomerOrderDetails] 1009
select p.PersonID, p.FullName, p.EmailAddress, p.PhoneNumber
		, ol.OrderID, ol.Description, ol.UnitPrice
from [Sales].[Orders] ord
	Join [Sales].[OrderLines] ol on ol.OrderID = ord.OrderID
	Join [Sales].[Customers] cust on cust.CustomerID = ord.CustomerID
	Join [Application].[People] p on p.PersonID = ord.CustomerID
Where 1=1
	And p.PersonID = @personId--1009
