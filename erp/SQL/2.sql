USE [tsJXC]
GO
/****** Object:  StoredProcedure [dbo].[sp_mrpResult]    Script Date: 01/12/2011 16:54:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER     procedure [dbo].[sp_mrpResult]
as

create table #temp
(
  F_ItemID   varchar(30),
  F_ItemName varchar(60), 
  F_Spec     varchar(40),
  F_Unit     varchar(10),
  F_SupplierID   varchar(30),
  F_Qty      decimal(18,4),
  F_StoreQty decimal(18,4),
  F_StockQty decimal(18,4),
  F_TaskQty  decimal(18,4),
  F_NeedQty  decimal(18,4)
)

select * from #temp

drop table #temp





