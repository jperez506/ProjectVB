use tienda;
select * from usuariosusuarios;
CREATE TABLE  `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(20),
  `nombre` varchar(50),
  `telefono` varchar(50),
  `direccion` varchar(50) ,
  PRIMARY KEY (`id`)
);
CREATE TABLE  `impresion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
);
select * from tienda.clientes;
CREATE TABLE `pagos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_factura` varchar(20),
  `subtotal` float,
  `descuento` float,
  `total` float,
  `fecha` date NOT NULL,
  PRIMARY KEY (`id`)
);
CREATE TABLE  `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20),
  `descripcion` varchar(50) ,
  `precio` float ,
  PRIMARY KEY (`id`)
);
CREATE TABLE  `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50),
  `username` varchar(20),
  `clave` varchar(20),
  
  PRIMARY KEY (`id`)
);
CREATE TABLE  `ventas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date,
  `id_factura` varchar(15),
  `codigo_cliente` varchar(20),
  `estado` varchar(10),
  `id_usuario` int(11),
  PRIMARY KEY (`id`)
);
CREATE TABLE  `ventas_detalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_factura` varchar(20),
  `codigo` varchar(20),
  `descripcion` varchar(50),
  `precio` float,
  `cantidad` float,
  `descuento` float,
  PRIMARY KEY (`id`)
);
#Inserts de las tablas. 
select * from tienda.usuarios;
select * from tienda.clientes;
select * from productos;
INSERT INTO tienda.usuarios (id,nombre,username,clave)
VALUES(1,'joharce','jperez',1234);
INSERT INTO tienda.usuarios (id,nombre,username,clave)
VALUES(2,'diego','dvr',12345);
