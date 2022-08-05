IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'AddReminder')
DROP PROCEDURE AddReminder

go
create procedure dbo.AddReminder(@id uniqueidentifier,
								@date DateTimeOffset, 
								@message nvarchar(max), 
								@contactId nvarchar(max),
								@status int)
as
begin
	set nocount on

	insert into Reminder (id, date, message, contact_id, status)
	values (@id, @date, @message, @contactId, @status)
end
go
