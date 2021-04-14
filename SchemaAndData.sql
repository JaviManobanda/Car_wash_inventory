-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: inventary_car_wash
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bodega`
--

DROP TABLE IF EXISTS `bodega`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bodega` (
  `idbodega` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`idbodega`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bodega`
--

LOCK TABLES `bodega` WRITE;
/*!40000 ALTER TABLE `bodega` DISABLE KEYS */;
INSERT INTO `bodega` VALUES (1,'Master'),(2,'Local 2');
/*!40000 ALTER TABLE `bodega` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bodega_product`
--

DROP TABLE IF EXISTS `bodega_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bodega_product` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_bodega` int NOT NULL,
  `id_product` int NOT NULL,
  `stock` int NOT NULL,
  `id_packing` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `bodega-producto__bodega_idx` (`id_bodega`),
  KEY `bodega-producto__producto_idx` (`id_product`),
  KEY `bodega_producto__packing_idx` (`id_packing`),
  CONSTRAINT `bodega-producto__bodega` FOREIGN KEY (`id_bodega`) REFERENCES `bodega` (`idbodega`),
  CONSTRAINT `bodega-producto__producto` FOREIGN KEY (`id_product`) REFERENCES `products` (`idproducts`),
  CONSTRAINT `bodega_producto__packing` FOREIGN KEY (`id_packing`) REFERENCES `packing` (`idpacking`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bodega_product`
--

LOCK TABLES `bodega_product` WRITE;
/*!40000 ALTER TABLE `bodega_product` DISABLE KEYS */;
INSERT INTO `bodega_product` VALUES (1,1,1,48,1),(2,1,2,67,1),(3,1,3,25,1),(4,1,4,52,1),(5,1,5,72,4),(6,1,6,48,4),(7,1,7,12,4),(8,1,8,12,4),(10,1,10,24,4),(11,1,11,11,4),(12,1,12,51,2),(13,1,13,36,2),(14,1,14,8,2),(15,1,15,10,2),(16,1,16,24,2),(17,1,17,4,2),(18,1,18,12,4),(19,1,19,12,4),(20,1,20,60,5),(21,1,21,41,5),(22,1,22,16,5),(23,1,23,17,5),(24,1,24,36,2),(26,1,26,12,2),(27,1,27,13,5),(28,1,28,24,5),(29,1,29,72,4),(30,1,30,12,4),(31,1,31,12,4),(32,1,32,60,4),(33,1,33,36,4),(34,1,34,12,4),(35,1,35,12,4),(36,1,36,45,1),(37,1,37,30,1),(38,1,38,79,1),(39,1,39,96,4),(40,1,40,24,3),(41,1,41,34,4),(42,1,42,31,1),(43,1,43,30,1),(44,1,44,21,1),(45,1,45,24,4),(46,1,45,12,4),(47,1,47,12,4),(48,1,48,15,2),(49,1,49,9,2),(50,1,50,24,4),(51,1,51,24,4),(52,1,52,12,3),(53,1,53,6,3),(54,1,54,6,3),(55,1,55,24,4),(56,1,56,36,4),(57,1,57,36,4),(58,1,58,82,4),(59,1,59,6,1),(60,1,60,3,1),(61,1,61,36,4),(63,1,63,4,2),(64,1,64,2,2),(65,1,65,81,1),(66,1,66,2,1);
/*!40000 ALTER TABLE `bodega_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `idcategory` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idcategory`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Aceite'),(4,'Filtro Aceite'),(2,'Filtro Aire'),(3,'Filtro combustible'),(6,'Grasa'),(5,'Repuesto');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle`
--

DROP TABLE IF EXISTS `detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle` (
  `idDetalle` int NOT NULL AUTO_INCREMENT,
  `qty` int NOT NULL,
  `unit_cost` decimal(10,0) NOT NULL,
  `id_product` int NOT NULL,
  `id_kardex` int NOT NULL,
  `unit_price` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`idDetalle`),
  KEY `detalle_kardex_idx` (`id_kardex`),
  CONSTRAINT `detalle_kardex` FOREIGN KEY (`id_kardex`) REFERENCES `kardex` (`idkardex`),
  CONSTRAINT `detalle_producto` FOREIGN KEY (`id_kardex`) REFERENCES `products` (`idproducts`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle`
--

LOCK TABLES `detalle` WRITE;
/*!40000 ALTER TABLE `detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `institute`
--

DROP TABLE IF EXISTS `institute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `institute` (
  `idinstitute` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  `address_1` varchar(250) DEFAULT NULL,
  `address_2` varchar(250) DEFAULT NULL,
  `phone_1` varchar(45) DEFAULT NULL,
  `phone_2` varchar(45) DEFAULT NULL,
  `email` varchar(300) DEFAULT NULL,
  `ruc` varchar(20) NOT NULL,
  PRIMARY KEY (`idinstitute`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `institute`
--

LOCK TABLES `institute` WRITE;
/*!40000 ALTER TABLE `institute` DISABLE KEYS */;
/*!40000 ALTER TABLE `institute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kardex`
--

DROP TABLE IF EXISTS `kardex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kardex` (
  `idkardex` int NOT NULL AUTO_INCREMENT,
  `dateTime` timestamp NOT NULL,
  `totalCost` int NOT NULL,
  `id_operation` int NOT NULL,
  `id_user` int DEFAULT NULL,
  PRIMARY KEY (`idkardex`),
  KEY `kardex-operations_idx` (`id_operation`),
  KEY `kardex-user_idx` (`id_user`),
  CONSTRAINT `kardex-operation` FOREIGN KEY (`id_operation`) REFERENCES `operations` (`idoperations`),
  CONSTRAINT `kardex-user` FOREIGN KEY (`id_user`) REFERENCES `user` (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kardex`
--

LOCK TABLES `kardex` WRITE;
/*!40000 ALTER TABLE `kardex` DISABLE KEYS */;
/*!40000 ALTER TABLE `kardex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marca` (
  `idmarca` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  PRIMARY KEY (`idmarca`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` VALUES (1,'Valvoline'),(2,'Pennzoil'),(3,'Mobil'),(4,'Castrol'),(5,'Amalie'),(6,'Energy'),(7,'Golden Bear'),(8,'Kendall'),(9,'Phillips 66');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operations`
--

DROP TABLE IF EXISTS `operations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `operations` (
  `idoperations` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idoperations`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operations`
--

LOCK TABLES `operations` WRITE;
/*!40000 ALTER TABLE `operations` DISABLE KEYS */;
/*!40000 ALTER TABLE `operations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `packing`
--

DROP TABLE IF EXISTS `packing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `packing` (
  `idpacking` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `valor` int NOT NULL,
  PRIMARY KEY (`idpacking`),
  UNIQUE KEY `idpacking_UNIQUE` (`idpacking`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `packing`
--

LOCK TABLES `packing` WRITE;
/*!40000 ALTER TABLE `packing` DISABLE KEYS */;
INSERT INTO `packing` VALUES (1,'Caja de 3',3),(2,'Caja de 4',4),(3,'Caja de 6',6),(4,'Caja de 12',12),(5,'Caja de 8',8);
/*!40000 ALTER TABLE `packing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `idproducts` int NOT NULL AUTO_INCREMENT,
  `name` varchar(250) NOT NULL,
  `description` varchar(300) NOT NULL,
  `unit_price` decimal(10,3) NOT NULL,
  `unit_cost` decimal(10,3) DEFAULT NULL,
  `imagen` varchar(400) DEFAULT NULL,
  `id_units` int NOT NULL,
  `id_category` int NOT NULL,
  `id_marca` int NOT NULL,
  `codigo` varchar(35) NOT NULL,
  PRIMARY KEY (`idproducts`),
  UNIQUE KEY `idproducts_UNIQUE` (`idproducts`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `products-units_idx` (`id_units`),
  KEY `products-category_idx` (`id_category`),
  KEY `products-marca_idx` (`id_marca`),
  CONSTRAINT `products-category` FOREIGN KEY (`id_category`) REFERENCES `category` (`idcategory`),
  CONSTRAINT `products-marca` FOREIGN KEY (`id_marca`) REFERENCES `marca` (`idmarca`),
  CONSTRAINT `products-units` FOREIGN KEY (`id_units`) REFERENCES `units` (`idunits`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (1,'SAE 40','ACEITE 40 PARA GASOLINA',0.000,0.000,'',1,1,1,'20VALSAE40GAL'),(2,'SAE 20W50','BLEND POWER  20W50',0.000,0.000,'',1,1,1,'2021VALSAE20W50GAL'),(3,'SAE 10W30','BLEND POWER  10W30',0.000,0.000,'',1,1,1,'2021VALSAE10W30GAL'),(4,'SAE 15W40','VALVODIESEL 15W40',0.000,0.000,'',1,1,1,'2021VALSAE15W40GAL'),(5,'SAE 40','ACEITE 40 PARA GASOLINA',0.000,0.000,'',2,1,1,'2021VALSAE40CUA'),(6,'SAE 15W40','VALVODIESEL 15W40',0.000,0.000,'',2,1,1,'2021VALSAE15W40CUA'),(7,'10W30','BLEND POWER 10W30',0.000,0.000,'',2,1,1,'2021VAL10W30CUA'),(8,'SAE 20W50','BLEND POWER 20W50',0.000,0.000,'',2,1,1,'2021VALSAE20W50CUA'),(10,'RANGER 20W50','RANGER 20W50',0.000,0.000,'',2,1,1,'2021VALRANGER20W50CUA'),(11,'4 TIEMPOS ','4 TIEMPOS ',0.000,0.000,'',2,1,1,'2021VAL4TIEMPOSCUA'),(12,'SAE 15W40','15W40 NORMAL',0.000,0.000,'',1,1,5,'2021AMASAE15W40GAL'),(13,'SAE 10W30','10W30 NORMAL',0.000,0.000,'',1,1,5,'2021AMASAE10W30GAL'),(14,'SAE 20W50','20W50 NORMAL',0.000,0.000,'',1,1,5,'2021AMASAE20W50GAL'),(15,'SAE 10W30 SINTETICA','10W30 SINTETICA',0.000,0.000,'',1,1,5,'2021AMASAE10W30SINTETICAGAL'),(16,'SAE 15W40 SINTETICA','15 W 40 SINTÉTICA',0.000,0.000,'',1,1,5,'2021AMASAE15W40SINTETICAGAL'),(17,'SAE 5W30','5W30 NORMAL',0.000,0.000,'',1,1,5,'2021AMASAE5W30GAL'),(18,'SAE 10W30','10 W 30 SINTETICO ',0.000,0.000,'',2,1,5,'2021AMASAE10W30CUA'),(19,'SAE 20W50','MOTOR 20 W 50',0.000,0.000,'',2,1,5,'2021AMASAE20W50CUA'),(20,'SAE 20W50','GTX  20W50',0.000,0.000,'',1,1,4,'2021CASSAE20W50GAL'),(21,'SAE 85W140','TRANSMICIÓN 85W140',0.000,0.000,'',1,1,4,'2021CASSAE85W140GAL'),(22,'SAE 80W90 ','ACEITE PARA CAJA  80 W 90 ',0.000,0.000,'',1,1,4,'2021CASSAE80W90GAL'),(23,'SAE 25W60','ACEITE PARA MOTO 25W60',0.000,0.000,'',1,1,4,'2021CASSAE25W60GAL'),(24,'SAE 10W30','MOTOR SINTETICO 10 W 30',0.000,0.000,'',1,1,4,'2021CASSAE10W30GAL'),(26,'SAE 20W50 SINTETICO','SAE 20W50 SINTETICO',0.000,0.000,'',1,1,4,'2021CASSAE20W50SINTETICOGAL'),(27,'SAE 90','ACEITE CAJA SAE 90',0.000,0.000,'',1,1,4,'2021CASSAE90GAL'),(28,'SAE 140','TRANSMISIÓN SAE 140',0.000,0.000,'',1,1,4,'2021CASSAE140GAL'),(29,'SAE 20W50','GTX 20W 50',0.000,0.000,'',2,1,4,'2021CASSAE20W50CUA'),(30,'SAE 10W30','GTX 10W30',0.000,0.000,'',2,1,4,'2021CASSAE10W30CUA'),(31,'SAE 25W60','GTX 25W60',0.000,0.000,'',2,1,4,'2021CASSAE25W60CUA'),(32,'SAE 85W140','TRANSMICION 85 W 140',0.000,0.000,'',2,1,4,'2021CASSAE85W140CUA'),(33,'SAE 140','TRANSMICION 140 ',0.000,0.000,'',2,1,4,'2021CASSAE140CUA'),(34,'SAE 90','ACEITE PARA CAJA 90',0.000,0.000,'',2,1,4,'2021CASSAE90CUA'),(35,'2 TIEMPOS','2 TIEMPOS',0.000,0.000,'',2,1,4,'2021CAS2TIEMPOSCUA'),(36,'SAE 15W40','MOTOR  15W40',0.000,0.000,'',1,1,2,'2021PENSAE15W40GAL'),(37,'SAE 10W40','GARAFA + 1/4  10W30',0.000,0.000,'',7,1,2,'2021PENSAE10W40GAL'),(38,'SAE 20W50','GARAFA + 1/4   20W50',0.000,0.000,'',7,1,2,'2021PENSAE20W50GAR'),(39,'SAE 10W30','MOTOR 10W30',0.000,0.000,'',2,1,2,'2021PENSAE10W30CUA'),(40,'SAE 20W50','MOTOR 20W50',0.000,0.000,'',2,1,2,'2021PENSAE20W50CUA'),(41,'SAE 15W40','DIESEL 15 W 40',0.000,0.000,'',2,1,2,'2021PENSAE15W40CUA'),(42,'SAE 10W30','MOTOR  10W30',0.000,0.000,'',1,1,8,'2021KENSAE10W30GAL'),(43,'SAE 15W40','MOTOR DIESEL 15W40',0.000,0.000,'',1,1,8,'2021KENSAE15W40GAL'),(44,'SAE 20W50','MOTOR 20W50',0.000,0.000,'',1,1,8,'2021KENSAE20W50GAL'),(45,'SAE 15W40','MOTOR  15W40',0.000,0.000,'',2,1,8,'2021KENSAE15W40CUA'),(47,'SAE 10W30','MOTOR 10W30',0.000,0.000,'',2,1,8,'2021KENSAE10W30CUA'),(48,'SAE 10W30','MOTOR 10W30',0.000,0.000,'',1,1,3,'2021MOBSAE10W30GAL'),(49,'SAE 15W40','MOTOR 15W40',0.000,0.000,'',1,1,3,'2021MOBSAE15W40GAL'),(50,'SAE 15W40','MOTOR 15W40',0.000,0.000,'',2,1,3,'2021MOBSAE15W40CUA'),(51,'SAE 10W30','MOTOR 10W30',0.000,0.000,'',2,1,3,'2021MOBSAE10W30CUA'),(52,'SAE 15W40','MOTOR 15W40',0.000,0.000,'',1,1,7,'2021GOLSAE15W40GAL'),(53,'SAE 20W50','SINTETICO 20W50',0.000,0.000,'',1,1,7,'2021GOLSAE20W50GAL'),(54,'SAE 140 ','TRANSMICION 140 ',0.000,0.000,'',1,1,7,'2021GOLSAE140GAL'),(55,'SAE 20W50','NORMAL MOTOR 20W50',0.000,0.000,'',2,1,7,'2021GOLSAE20W50CUA'),(56,'SAE 20W50 SINTETICO ','SINTETICO 20W50',0.000,0.000,'',2,1,7,'2021GOLSAE20W50SINTETICOCUA'),(57,'SAE 15W40','MOTOR 15W40',0.000,0.000,'',2,1,7,'2021GOLSAE15W40CUA'),(58,'4 TIEMPOS','4 TIEMPOS',0.000,0.000,'',2,1,6,'2021ENE4TIEMPOSCUA'),(59,'SAE 15W40','15W40 MOTOR',0.000,0.000,'',1,1,9,'2021PHISAE15W40GAL'),(60,'SAE 20W50','20W50 MOTOR',0.000,0.000,'',1,1,9,'2021PHISAE20W50GAL'),(61,'SAE 75W90','75W90 PARA CAJA',0.000,0.000,'',2,1,9,'2021PHISAE75W90CUA'),(63,'SAE 20W50','SUPER 20W50',0.000,0.000,'',1,1,3,'2021MOBSAE20W50GAL'),(64,'SAE 20W50 SINTETICO','SAE 20W50 SINTETICO',0.000,0.000,'',1,1,5,'2021AMASAE20W50SINTETICOGAL'),(65,'RANGER 20W50','RANGER 20W50',0.000,0.000,'',1,1,1,'2021VALRANGER20W50GAL'),(66,'SAE 10W30','SAE 10W30 GARRAFA',0.000,0.000,'',7,1,2,'2021PENSAE10W30GAR');
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_user`
--

DROP TABLE IF EXISTS `type_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_user` (
  `idtype_user` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`idtype_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_user`
--

LOCK TABLES `type_user` WRITE;
/*!40000 ALTER TABLE `type_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `type_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `units` (
  `idunits` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idunits`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `units`
--

LOCK TABLES `units` WRITE;
/*!40000 ALTER TABLE `units` DISABLE KEYS */;
INSERT INTO `units` VALUES (5,'Caneca'),(2,'Cuarto'),(1,'Galón'),(7,'Garrafa'),(4,'Metro'),(3,'Unidad');
/*!40000 ALTER TABLE `units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `iduser` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(200) DEFAULT NULL,
  `last_name` varchar(200) DEFAULT NULL,
  `address` varchar(300) DEFAULT NULL,
  `phone_1` varchar(45) DEFAULT NULL,
  `phone_2` varchar(45) DEFAULT NULL,
  `email` varchar(300) DEFAULT NULL,
  `ci/ruc` varchar(20) NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_institute`
--

DROP TABLE IF EXISTS `user_institute`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_institute` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `id_institute` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_institute--institute_idx` (`id_institute`),
  KEY `user_institute--user_idx` (`id_user`),
  CONSTRAINT `user_institute--institute` FOREIGN KEY (`id_institute`) REFERENCES `institute` (`idinstitute`),
  CONSTRAINT `user_institute--user` FOREIGN KEY (`id_user`) REFERENCES `user` (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_institute`
--

LOCK TABLES `user_institute` WRITE;
/*!40000 ALTER TABLE `user_institute` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_institute` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_tipo__user`
--

DROP TABLE IF EXISTS `user_tipo__user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_tipo__user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `id_type_user` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_tipo__user--USER_idx` (`id_user`),
  KEY `user_tipo__user--TYPE_USER_idx` (`id_type_user`),
  CONSTRAINT `user_tipo__user--TYPE_USER` FOREIGN KEY (`id_type_user`) REFERENCES `type_user` (`idtype_user`),
  CONSTRAINT `user_tipo__user--USER` FOREIGN KEY (`id_user`) REFERENCES `user` (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_tipo__user`
--

LOCK TABLES `user_tipo__user` WRITE;
/*!40000 ALTER TABLE `user_tipo__user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_tipo__user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-04-05 17:23:55
