USE [CATALOGO_WEB_DB]
GO

create procedure [dbo].[storedListar] as
Select Codigo, Nombre, A.Descripcion Descripcion, ImagenUrl, A.Precio, M.Descripcion Marca, 
C.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Id 
from ARTICULOS A, MARCAS M, CATEGORIAS C 
where M.Id = A.IdMarca and C.Id = A.IdCategoria

go

create procedure [dbo].[storedAltaArticulo]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagen varchar(1500),
@precio money
as
insert into ARTICULOS values (@codigo, @nombre, @descripcion, @idMarca,
@idCategoria, @imagen, @precio)

go

create procedure [dbo].[storedModificarArticulo]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@imagen varchar(1000),
@idMarca int,
@idCategoria int,
@precio money,
@id int
as
update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @imagen,
IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio 
where Id = @id

go

create procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar(50)
as
insert into USERS (email, pass, admin) output inserted.Id 
values (@email, @pass, 0)