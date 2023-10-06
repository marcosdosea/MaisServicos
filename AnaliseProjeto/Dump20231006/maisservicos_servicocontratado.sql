CREATE DATABASE  IF NOT EXISTS `maisservicos` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `maisservicos`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: maisservicos
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `servicocontratado`
--

DROP TABLE IF EXISTS `servicocontratado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicocontratado` (
  `id` int NOT NULL AUTO_INCREMENT,
  `valor` float NOT NULL,
  `idPessoa` int NOT NULL,
  `idAvaliacao` int NOT NULL,
  `idTemplateContrato` int NOT NULL,
  `idOrcamento` int NOT NULL,
  PRIMARY KEY (`id`,`idOrcamento`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_ServicoContratado_Pessoa1_idx` (`idPessoa`),
  KEY `fk_ServicoContratado_Avaliacao1_idx` (`idAvaliacao`),
  KEY `fk_ServicoContratado_TemplateContrato1_idx` (`idTemplateContrato`),
  KEY `fk_ServicoContratado_Orcamento1_idx` (`idOrcamento`),
  CONSTRAINT `fk_ServicoContratado_Avaliacao1` FOREIGN KEY (`idAvaliacao`) REFERENCES `avaliacao` (`id`),
  CONSTRAINT `fk_ServicoContratado_Orcamento1` FOREIGN KEY (`idOrcamento`) REFERENCES `orcamento` (`id`),
  CONSTRAINT `fk_ServicoContratado_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`),
  CONSTRAINT `fk_ServicoContratado_TemplateContrato1` FOREIGN KEY (`idTemplateContrato`) REFERENCES `templatecontrato` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicocontratado`
--

LOCK TABLES `servicocontratado` WRITE;
/*!40000 ALTER TABLE `servicocontratado` DISABLE KEYS */;
/*!40000 ALTER TABLE `servicocontratado` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-06 10:17:22
