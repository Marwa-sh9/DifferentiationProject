create procedure test
as 

DECLARE @id INT;
DECLARE @capacity INT;

DECLARE @counter INT;
DECLARE @full INT;

DECLARE db_cursor CURSOR FOR SELECT Factuly.Factuly_Id,Factuly.Capacity FROM Factuly 

SET @full=0
SET @counter=1

OPEN db_cursor

FETCH NEXT FROM db_cursor INTO @id,@capacity  

WHILE @@FETCH_STATUS = 0 
 
BEGIN  
  
  WHILE @counter <= 5 and @full!=@capacity
  BEGIN

    DECLARE @id_des INT;

    DECLARE db_cursor2 CURSOR FOR SELECT Desire_Id FROM Desires,Mark where Factuly_Id=@id and Desire_Sequence=@counter 
	and Desires.Id_Number=Mark.Id_Number and Desires.Id_Number not in (select DISTINCT Id_Number from Desires where Accepted='1')
	 order by Mark.Mark_Total        

    OPEN db_cursor2

    FETCH NEXT FROM db_cursor2 INTO @id_des

    WHILE @@FETCH_STATUS = 0 and @full!=@capacity

    BEGIN
       update Desires set Accepted='1' where Desire_Id=@id_des;
       FETCH NEXT FROM db_cursor2 INTO @id_des
       END

      CLOSE db_cursor2
    DEALLOCATE db_cursor2  
    set @counter=@counter+1
  END

  FETCH NEXT FROM db_cursor INTO @id,@capacity  
  SET @full=0
  SET @counter=1

END
CLOSE db_cursor
DEALLOCATE db_cursor  
GO