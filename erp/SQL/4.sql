
/****** Object:  Trigger [dbo].[trg_CheckApplyStock]    Script Date: 01/12/2011 16:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  TRIGGER [dbo].[trg_CheckApplyStock] ON [dbo].[t_ApplyStock]
FOR UPDATE
AS
declare @Check int,
        @Bill varchar(30)

if update(F_Check)
begin
  if exists(select top 1 * from t_StockOrderDetail a,inserted b where a.F_LinkBill = b.F_BillID)
  begin
     rollback tran
     raiserror('本单已被采购订单引用，不能反审！！',18,18)
  end
  
  select @Check = isnull(F_Check,0),@Bill = F_BillID from inserted
  
  if @Check = 1
  begin
     update a set a.F_SupplierID = c.F_SupplierID 
     from t_Item a,inserted b,t_ApplyStockDetail c
     where b.F_BillID = c.F_BillID
     and a.F_ID = c.F_ItemID
     and isnull(a.F_SupplierID,'') = '' 
     
     exec sp_AutoGenStockOrder @Bill
  end
  
end
