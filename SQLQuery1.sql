Create database QlyQuanCaphe
Go
USE QlyQuanCaphe
go
-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- Billinfor

create table TBFood
(
	id int identity primary key,
	ten Nvarchar (100)not null default N'Chua dat ten ',
	status Nvarchar(100) not null default N'Trống'

)
go
create table Tablle
(
	id int identity primary key,
	ten Nvarchar (100)not null default N'Chua dat ten ',
	

)
go
create table Acc
(
	Username nvarchar(100) not null primary key,
	DisplayName nvarchar(100) not null default N'HaDo',
	
	Password nvarchar (1000) not null default 0,
	type int not null default 0
)
go
create table FoodCategory
(
	id int identity primary key,
	ten Nvarchar (100)default N'chua dat ten',

)
go

create table Food
(
	id int identity primary key,
	ten Nvarchar (100)not null default N'chua dat ten',
	idCategory int not null,
	price float not null,
	foreign key (idCategory) references dbo.FoodCategory(id)
)
go
create table Bill
(
	id int identity primary key,
	Datecheckin date default Getdate(),
	Datecheckout date,
	idTable int not null,
	status int  not null
	foreign key (idTable) references dbo.TBFood(id)
)
go

create table Billinfor
(
	id int identity primary key,
	idBill int not null,
	idFood int not null,
	count int not null default 0

	foreign key (idBill) references dbo.Bill(id),

	foreign key (idFood) references dbo.Food(id)
)
go
--

--
insert into Acc
(
	Username,
	DisplayName,
	Password,
	type
)
values ( N'H' ,
		N'hado ',
		N'1',
		1
	)
insert into Acc
(
	Username,
	DisplayName,
	Password,
	type
)
values ( N'D' ,
		N'Dat ',
		N'1',
		1
	)
go

create proc USP_GetAccbyusername
@userName nvarchar (100)
as
begin
	select * from dbo.Acc where Username= @userName

end
go
 exec dbo.USP_GetAccbyusername @userName = N'H'
 go

create proc USP_Login
@userName nvarchar (100),@passWord nvarchar(100)
as
begin
	select * from Acc where Username=@userName and Password= @passWord 
end
go

declare @i int =0
while @i <=10
begin
		insert TBFood (ten) values (N'Ban' +  cast(@i as nvarchar(100)))
		set @i=@i+1
end
go


go
create proc USP_GetTableList
as
begin
	select *from TBFood
end
go
	exec USP_GetTableList
	
--them FoodCategory
	select * from FoodCategory
	insert into FoodCategory
	(namefood)
	values (N'Hải Sản')
	insert into FoodCategory
	(namefood)
	values (N'Nông Sản')
	insert into FoodCategory
	(namefood)
	values (N'Nông Sản')
	insert into FoodCategory
	(namefood)
	values (N'Nước Giải Khát')
--them Food
	insert into Food
	(ten,idCategory,price)
	values (N'Mực Nướng ',10,105500)
	insert into Food
	(ten,idCategory,price)
	values (N'Rau Củ Xào ',11,250000)
	insert into Food
	(ten,idCategory,price)
	values (N'Heo Rừng Cháy Tỏi ',12,320000)
	insert into Food
	(ten,idCategory,price)
	values (N'Coca',13,10550)
--them Bill
	select * from Bill
	insert into Bill
	(Datecheckin,Datecheckout,idTable,status)
	values (GETDATE(),null,76745,0)
	insert into Bill
	(Datecheckin,Datecheckout,idTable,status)
	values (GETDATE(),GETDATE(),76747,1)
	insert into Bill
	(Datecheckin,Datecheckout,idTable,status)
	values (GETDATE(),null,76750,0)
--them Billinfor
	select * from Billinfor
	insert into Billinfor
	(idBill,idFood,count)
	values (7,11,5)
	insert into Billinfor
	(idBill,idFood,count)
	values (7,12,3)
	insert into Billinfor
	(idBill,idFood,count)
	values (8,10,6)

	---
	select * from Bill where idTable= 76747 and status = 0
	select f.ten,bi.count,f.price,f.price*bi.count as totalPrice from Billinfor as bi , Bill as b , Food as f
	where bi.idBill = b.id and bi.idFood = f.id and b.idTable = 76747
	select f.ten,bi.count,f.price,f.price*bi.count as totalPrice from Billinfor as bi , Bill as b , Food as f where bi.idBill = b.id and bi.idFood = f.id and b.idTable = 76747
	--
	update FoodCategory  set namefood = N'Lâm Sản ' where id = 12 

	--
	go
	alter proc USP_insertBill
	 @idTable int
	 as
	 begin
	 insert into Bill
		(Datecheckin,Datecheckout,idTable,status,Discount)
	 values (GETDATE(),null,@idTable,0,0)

	 end 
	 go 

	 ---
	 
	 alter proc USP_insertBillInfo
	 @idBill int  , @idFood int ,@count int 
	as 
	begin
		declare @isExitsBill int 
		declare @foodCount int =1

		select @isExitsBill = id , @foodCount = bi.count from Billinfor as bi where idBill = @idBill and idFood = @idFood 

		if (@isExitsBill>0)
		begin
		declare @newCount int= @foodCount + @count
			if (@newCount>0)
				update Billinfor set count = @foodCount + @count where idBill = @idBill and idFood= @idFood 
			else
				delete Billinfor where idBill = @idBill and idFood= @idFood 
		end
		else
		begin
			insert into Billinfor
			(idBill,idFood,count)
			values (@idBill,@idFood,@count)
		end

		end
	  go
	  --
	  --
	  select * from Bill
	  --
	  go
	  alter trigger UTG_updateBillInfo
	  on Billinfor for insert , update  
	  as 
	  begin
		declare @idBill int
		select @idBill=idBill from inserted
		declare @idTable int
		select @idTable=idTable from Bill where id = @idBill and status =0 

		declare @count int
		select @count = COUNT(*) from Billinfor where idBill =@idBill
		if (@count>0)
			begin
			update TBFood set status = N'Có Người' where id =@idTable

			end
		else
			update TBFood set status = N'Trống' where id =@idTable

	  end
	  go
	  --
	  alter trigger UTG_UpdateBill
	  on Bill for update
	  as 
	  begin
		declare @idBill int
		select @idBill = id from inserted

		declare @idTable int
		select @idTable=idTable from Bill where id = @idBill

		declare @count int =0
		select @count =COUNT(*) from Bill where idTable = @idTable and status =0 

		if (@count = 0)
			update TBFood set status = N'Trống' where id  = @idTable 

	  end 
	  go

	  --
	   delete from Billinfor
	  --
	  alter table Bill
	  add Discount int 
	  --
	  alter table Billinfor add idTableFood int not null
		foreign key (idTableFood) references dbo.TBFood(id)

	  --
	  update Bill set Discount = 0 
	  --
	  go
	  alter proc USP_SwitchTable
	  @idTable1 int , @idTable2 int 

	  as 
	  begin

			declare @idFistBill int 
			declare @idsecondBill int

			declare @isFistTableEmty int =1
			declare @isSecondTablEmty int =1

			select @idsecondBill= id from Bill where idTable= @idTable2 and status = 0
			select @idFistBill= id from Bill where idTable= @idTable1 and status = 0

			if(@idFistBill is null)
			begin

				insert into Bill(Datecheckin,Datecheckout,idTable,status)
					values(GETDATE(),null,@idTable1,0)
				select @idFistBill=max(id) from Bill where  idTable=@idTable1 and status =0


			end
			select @isFistTableEmty = COUNT(*) from Billinfor where  idBill= @idFistBill


			if(@idsecondBill is null)
			begin

				insert into Bill(Datecheckin,Datecheckout,idTable,status)
					   values(GETDATE(),null,@idTable2,0)
				select @idsecondBill=max(id) from Bill where  idTable=@idTable2 and status = 0

			end

			select @isSecondTablEmty = COUNT(*) from Billinfor where  idBill= @idsecondBill



			select id into IDBillInfoeTable From Billinfor where idBill = @idsecondBill

			update Billinfor set idBill = @idsecondBill where idBill = @idFistBill

			update Billinfor set idBill = @idFistBill where id in (select * from IDBillInfoeTable)
			drop table IDBillInfoeTable
			if(@isFistTableEmty=0)
				update TBFood set status =N'Trống' where id = @idTable2
	

			if(@isSecondTablEmty=0)
				update TBFood set status =N'Trống' where id = @idTable1

		
	  end
	  go
	  UPDATE TBFood SET status = N'Trống'
	  --
	  go
	  alter proc USP_GetListBillByDate
	  @Checkin date , @Ckeckout date
	  as
	  begin
	  select  t.ten as [Tên Bàn ] , Datecheckin as [Thời gian vào] , Datecheckout as [Thời gian ra], b.totalPrice as [Thành Tiền(vnd)], Discount as [Giảm giá(%)] 
	  from Bill as b  , TBFood as t 
	  where Datecheckin >= @Checkin and Datecheckout <= @Ckeckout and b.status= 1 
	  and t.id= b.idTable 
	  end

	  --

	   alter table Bill add totalPrice float
	   --
	   update Acc set type = 0 where Username = N'D'
	   select * from Acc
	   --
	   go
	   create proc USP_updateACC
	   @username nvarchar (100), @displayname nvarchar (100), @password nvarchar (100) , @newpass nvarchar (100)
	   as
	   begin
		declare @isrightPass int =0 
		 select @isrightPass = COUNT(*) from Acc where Username = @username and Password = @password

		 if (@isrightPass=1)
		 begin 
			if (@newpass =null or @newpass= '')
			begin
				update Acc set DisplayName =@displayname where Username = @username
			end
		 end
	   end
	   go
	   --
	   update Food set ten = N'' , idCategory = 0 , price = 0 where id = 1  
	   delete Food where id = 1
	   insert into Food (ten, idCategory, price) values (N'', 0, 0)
	   --
	   go
	   create trigger UTG_DeleteBillinfo
	   on Billinfor for Delete
	   as
	   begin
			declare @idBillinfor int
			declare @idBill int
			select  @idBillinfor = id , @idBill= Deleted.idBill from deleted

			declare @idTable int
			select @idTable = idTable from Bill where id= @idBill

			declare @count int
			select @count = count(*) from Billinfor as bi , Bill as b where b.id =bi.idBill and b.id=@idBill and b.id=@idBillinfor
			if(@count=0)
				update TBFood set status= N'Trống' where id = @idTable

		
	   end
	   go
	   --
	   
	   create function funConvertToUnsign (@strInput nvarchar(4000)) returns nvarchar(4000)  
	   as 
	   begin
		if @strInput is null
			return @strInput 
		if @strInput = '' 
			return @strInput 
		declare @RT nvarchar(136)
		declare @Sign_Chars nchar(136)
		declare @unsign_chars nchar (136)
			set @Sign_Chars = N'ăâđêôươàảãạáàảãáạăằẳẵắặâầẩẫấậèẻẽéẹêềểễếệ ìỉĩíịòỏõóọôồổỗốộơờởỡớợùủũúụưừửữứựỳỷỹyý ĂÂĐÊÔƯƠÀẢÃẠÁÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬÈẺẼÉẸÊỀỂỄẾỆ ÌỈĨÍỊÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢÙỦŨÚỤƯỪỬỮỨỰỲỶỸYÝ' +NCHAR(272)+ NCHAR(208) 
			Set @unsign_chars=N'aadeouoaaaaaaaaaaaaaaaaaaaaaaeeeeeeeeeee iiiiiooooooooooooooooouuuuuuuuuuuyyyyy AADEOUOAAAAAAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIII OOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYDD'
		declare @counter int
		declare @counter1 int
			set @counter = 1 
		while (@counter < LEN(@strInput))
			begin
				set @counter =1 
				while(@counter1<=Len(@Sign_Chars)+1)
					begin 
						if UNICODE(SUBSTRING(@Sign_Chars,@counter1,1))=UNICODE(SUBSTRING(@strInput,@counter,1))
							begin
								if @counter =1 
									set @strInput = SUBSTRING(@unsign_chars,@counter1,1)+SUBSTRING(@strInput,@counter+1,len(@strInput)-@counter)
									break
							end
							set @counter1=@counter1+1 
					end
					set @counter = @counter +1 
			end
			set @strInput = REPLACE(@strInput,' ','-')
		return @strInput
		end
		--
		select * from Food where dbo.funConvertToUnsign(ten) like N'%'+funConvertToUnsign(N'MUC')+'%'
		select Username,DisplayName,type from Acc
		--
		

