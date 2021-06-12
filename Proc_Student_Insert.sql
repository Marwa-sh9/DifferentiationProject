use Differentiation;
create  proc Student_Insert
@ID_Number bigint,
@Email varchar(50),
@Password varchar(50)
as
begin
  Update Student_Imported_Data set ID_Number = @ID_Number, Email = @Email,Password = @Password 
  where  ID_Number = @ID_Number 
end