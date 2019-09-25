--create database siemens_db

--create table categories(
--categoryid int not null primary key identity(1,1),
--categorynme varchar(50) not null
--)

/*
create table products(
productid int not null primary key,
productname varchar(50) not null,
price decimal(18,2) default(0),
description varchar(max)
)

alter table products
add categoryid int

alter table products
add constraint fk_categories_products_categoryid 
foreign key(categoryid) references categories(categoryid)
*/