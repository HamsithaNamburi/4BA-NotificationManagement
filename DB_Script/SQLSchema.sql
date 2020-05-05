Create Database NotificationDB
Use NotificationDB
create table UserDetails(UserId int Identity(1,1) primary key,UserName varchar(30) unique not null,UserPassword varchar(50) not null,
FirstName varchar(50) not null,
LastName varchar(50) not null,EmailAddr varchar(50),ContactNumber varchar(50),
RegisteredDatetime DateTime default getdate(),UpdatedDate DateTime,UserAddress varchar(250))
create table Notifications(NotificationId int Identity(100,1) primary key,NotificationName varchar(50) not null,
Description varchar(250),CreatedDatetime DateTime default getdate(),UserId int foreign key references UserDetails(UserId))
insert into UserDetails(UserName,UserPassword,FirstName,LastName,EmailAddr,ContactNumber,UserAddress) values('skvali5',
'abcd123','MeeraVali','Shaik','skvali5@gmail.com','7989209071','Dronadula')
insert into Notifications(NotificationName,Description,UserId) values('ABC','xyz of abc',1)