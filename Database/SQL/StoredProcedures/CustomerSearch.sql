USE [WideWorldImporters]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Application].[CustomerSearch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [Application].[CustomerSearch]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [Application].[CustomerSearch]
	@SearchText varchar(500)

As
-- exec [Application].[CustomerSearch] 'a'
    SELECT TOP(200)
           c.CustomerID,
           c.CustomerName,
           ct.CityName,
           c.PhoneNumber,
           c.FaxNumber,
           p.FullName ,
           p.PreferredName ,
		   p.LogonName
    FROM Sales.Customers AS c
    INNER JOIN [Application].Cities AS ct
    ON c.DeliveryCityID = ct.CityID
    LEFT OUTER JOIN [Application].People AS p
    ON c.PrimaryContactPersonID = p.PersonID
    WHERE CONCAT(c.CustomerName, N' ', p.FullName, N' ', p.PreferredName) LIKE N'%' + @SearchText + N'%'
    ORDER BY c.CustomerName
