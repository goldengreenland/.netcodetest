-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: evochermanagementsystem
-- ------------------------------------------------------
-- Server version	5.7.33-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `buy_type`
--

DROP TABLE IF EXISTS `buy_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `buy_type` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `evoucher_id` bigint(20) NOT NULL,
  `coupon_type_id` bigint(20) NOT NULL,
  `name` varchar(45) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `max_limit_byself` int(11) NOT NULL,
  `max_limit_bygift` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `coupon_type_id_FK_idx` (`coupon_type_id`),
  KEY `evoucher_id_FK_idx` (`evoucher_id`),
  CONSTRAINT `coupon_type_id_FK` FOREIGN KEY (`coupon_type_id`) REFERENCES `coupon_type` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `evoucher_id_FK` FOREIGN KEY (`evoucher_id`) REFERENCES `evoucher` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `buy_type`
--

LOCK TABLES `buy_type` WRITE;
/*!40000 ALTER TABLE `buy_type` DISABLE KEYS */;
INSERT INTO `buy_type` VALUES (1,5,1,'SawZayar','09972649400',10,0),(2,4,2,'saw','09972649400',0,5),(3,6,1,'Saw','09972649400',10,0);
/*!40000 ALTER TABLE `buy_type` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-09-03  2:33:49
