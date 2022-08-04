-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-08-2022 a las 06:11:00
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prestamobiciclestas`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bdprestamosestaciones`
--

CREATE TABLE `bdprestamosestaciones` (
  `id` int(11) NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `id_bicicleta` varchar(60) DEFAULT NULL,
  `modelo` varchar(60) DEFAULT NULL,
  `ubicacion` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bd_bicicleta`
--

CREATE TABLE `bd_bicicleta` (
  `id` int(11) NOT NULL,
  `id_bicicleta` varchar(60) NOT NULL,
  `modelo` varchar(60) DEFAULT NULL,
  `matricula` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bd_bicicleta`
--

INSERT INTO `bd_bicicleta` (`id`, `id_bicicleta`, `modelo`, `matricula`) VALUES
(2, 'B1', 'Standard', 'XYZM-202207'),
(3, 'B2', 'Standard', '20220730-ICR'),
(4, 'B3', 'Premium', 'AAA-250-202207'),
(5, 'B4', 'Standard', '20210701-KLF');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bd_estacion`
--

CREATE TABLE `bd_estacion` (
  `id` int(11) NOT NULL,
  `ubicacion` varchar(60) DEFAULT NULL,
  `cantidad_prestamos` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bd_estacion`
--

INSERT INTO `bd_estacion` (`id`, `ubicacion`, `cantidad_prestamos`) VALUES
(1, 'Pies Descalzos', 0),
(2, 'Rosales', 0),
(3, 'Miraflores', 0),
(4, 'Campo Amor', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bd_estacionbicicleta`
--

CREATE TABLE `bd_estacionbicicleta` (
  `id` int(11) NOT NULL,
  `id_estacion` int(11) DEFAULT NULL,
  `id_bicicleta` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bd_estacionbicicleta`
--

INSERT INTO `bd_estacionbicicleta` (`id`, `id_estacion`, `id_bicicleta`) VALUES
(1, 1, 'B1'),
(2, 1, 'B2'),
(3, 2, 'B3'),
(4, 2, 'B4');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bd_prestamo`
--

CREATE TABLE `bd_prestamo` (
  `id` int(11) NOT NULL,
  `id_estacion` int(11) DEFAULT NULL,
  `id_bicicleta` varchar(60) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bd_prestamo`
--

INSERT INTO `bd_prestamo` (`id`, `id_estacion`, `id_bicicleta`, `id_usuario`) VALUES
(1, 1, 'B1', 2),
(4, 1, 'B1', 2),
(5, 2, 'B2', 3);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bd_usuario`
--

CREATE TABLE `bd_usuario` (
  `id` int(11) NOT NULL,
  `apellido` varchar(255) NOT NULL,
  `cedula` int(11) NOT NULL,
  `nombre` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bd_usuario`
--

INSERT INTO `bd_usuario` (`id`, `apellido`, `cedula`, `nombre`) VALUES
(1, 'CASTRO RUIZ', 72009461, 'IVAN JESUS'),
(2, 'CASTRO RUIZ', 72009461, 'IVAN JESUS');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bdprestamosestaciones`
--
ALTER TABLE `bdprestamosestaciones`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `bd_bicicleta`
--
ALTER TABLE `bd_bicicleta`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `bd_estacion`
--
ALTER TABLE `bd_estacion`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `bd_estacionbicicleta`
--
ALTER TABLE `bd_estacionbicicleta`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `bd_prestamo`
--
ALTER TABLE `bd_prestamo`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `bd_usuario`
--
ALTER TABLE `bd_usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `bdprestamosestaciones`
--
ALTER TABLE `bdprestamosestaciones`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `bd_bicicleta`
--
ALTER TABLE `bd_bicicleta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `bd_estacion`
--
ALTER TABLE `bd_estacion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `bd_estacionbicicleta`
--
ALTER TABLE `bd_estacionbicicleta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `bd_prestamo`
--
ALTER TABLE `bd_prestamo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `bd_usuario`
--
ALTER TABLE `bd_usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
