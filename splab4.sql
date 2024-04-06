


create proc USP_listar_productos
as
begin

select  [idproducto]
      ,[nombreProducto]
      ,[cantidadPorUnidad]
      ,[precioUnidad]
      ,[unidadesEnExistencia]
      ,[unidadesEnPedido]
      ,[nivelNuevoPedido]
      ,[suspendido]
      ,[categoriaProducto]
from productos
end;



create proc USP_listar_categorias
as
begin

select  [idcategoria]
      ,[nombrecategoria]
      ,[descripcion]
      ,[Activo]
      ,[CodCategoria]
from categorias
end;


create proc USP_listar_proveedores
as
begin

select [idProveedor]
      ,[nombreCompañia]
      ,[nombrecontacto]
      ,[cargocontacto]
      ,[direccion]
      ,[ciudad]
      ,[pais]
      ,[telefono]
      ,[paginaprincipal]
from proveedores
end;