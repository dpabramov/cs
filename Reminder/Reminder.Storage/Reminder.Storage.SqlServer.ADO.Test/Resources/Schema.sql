IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U ' AND name = 'Reminder')
drop table dbo.Reminder
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U ' AND name = 'Status')
drop table dbo.Status
go

create table [Status] (
		id int identity(0,1), 
		[name] varchar(32) not null,
		constraint Pk_Status primary key clustered (id),
		constraint Status_Unique unique ([name]))
go

create table Reminder (
						id  uniqueidentifier,
						--id  int identity(1,1),
						date datetimeoffset not null,
						message nvarchar(max) not null,
						contact_id nvarchar(max) not null,
						status int not null,
						constraint Pk_Reminder primary key clustered (id),
						constraint Fk__Reminder_Status foreign key (status) references dbo.Status (Id) 
					  )
go
