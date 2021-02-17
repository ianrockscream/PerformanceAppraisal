-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: perfappraisal
-- ------------------------------------------------------
-- Server version	8.0.22

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
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `password` varchar(500) DEFAULT NULL,
  `loginname` varchar(50) DEFAULT NULL,
  `email` varchar(200) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adminlog`
--

DROP TABLE IF EXISTS `adminlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `adminlog` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `description` varchar(500) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adminlog`
--

LOCK TABLES `adminlog` WRITE;
/*!40000 ALTER TABLE `adminlog` DISABLE KEYS */;
/*!40000 ALTER TABLE `adminlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `businessobjective`
--

DROP TABLE IF EXISTS `businessobjective`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `businessobjective` (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(200) NOT NULL,
  `weight` int NOT NULL,
  `goalachievement` varchar(200) DEFAULT NULL,
  `employeescore` varchar(10) DEFAULT NULL,
  `managerscore` varchar(10) DEFAULT NULL,
  `performanceappraisalid` bigint NOT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `perfappbo_idx` (`performanceappraisalid`),
  KEY `bo_idx` (`id`,`createdate`),
  CONSTRAINT `perfappbo` FOREIGN KEY (`performanceappraisalid`) REFERENCES `performanceappraisal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `businessobjective`
--

LOCK TABLES `businessobjective` WRITE;
/*!40000 ALTER TABLE `businessobjective` DISABLE KEYS */;
INSERT INTO `businessobjective` VALUES (1,'goals 1',20,'achievement 1','3',NULL,3,NULL),(2,'goals 2',20,'achievement 2','2',NULL,3,NULL),(3,'goals 3',20,'achievement 3','1',NULL,3,NULL),(4,'goals 4',20,'achievement 4','2',NULL,3,NULL),(5,'goals 5',20,'achievement 5','2',NULL,3,NULL);
/*!40000 ALTER TABLE `businessobjective` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `departmentindex` (`id`,`name`,`description`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'IT','Department IT','2020-01-06 00:00:00',NULL),(2,'Finance','Departement Finance','2020-01-06 00:00:00',NULL),(3,'Sales','Departement Sales','2020-01-06 00:00:00',NULL);
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `developmentplan`
--

DROP TABLE IF EXISTS `developmentplan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `developmentplan` (
  `id` int NOT NULL AUTO_INCREMENT,
  `performanceappraisalid` bigint NOT NULL,
  `plan` varchar(100) DEFAULT NULL,
  `methods` varchar(100) DEFAULT NULL,
  `strengtharea` varchar(100) DEFAULT NULL,
  `developmentarea` varchar(100) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `perfappdevplan_idx` (`performanceappraisalid`),
  KEY `devplan_idx` (`id`,`createdate`),
  CONSTRAINT `perfappdevplan` FOREIGN KEY (`performanceappraisalid`) REFERENCES `performanceappraisal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `developmentplan`
--

LOCK TABLES `developmentplan` WRITE;
/*!40000 ALTER TABLE `developmentplan` DISABLE KEYS */;
INSERT INTO `developmentplan` VALUES (1,3,'Plan','Methods','Strength','Area','2021-02-03 06:25:37',NULL);
/*!40000 ALTER TABLE `developmentplan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `documenthistory`
--

DROP TABLE IF EXISTS `documenthistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `documenthistory` (
  `id` bigint NOT NULL,
  `performanceappraisalid` bigint NOT NULL,
  `employeeid` int NOT NULL,
  `changelog` varchar(500) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `perfappdochistory_idx` (`performanceappraisalid`),
  KEY `employeedochistory_idx` (`employeeid`),
  CONSTRAINT `employeedochistory` FOREIGN KEY (`employeeid`) REFERENCES `employee` (`id`),
  CONSTRAINT `perfappdochistory` FOREIGN KEY (`performanceappraisalid`) REFERENCES `performanceappraisal` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `documenthistory`
--

LOCK TABLES `documenthistory` WRITE;
/*!40000 ALTER TABLE `documenthistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `documenthistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `nik` varchar(50) NOT NULL,
  `email` varchar(200) DEFAULT NULL,
  `password` varchar(200) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `positionId` int DEFAULT NULL,
  `departmentId` int DEFAULT NULL,
  `subdepartmentId` int DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `departmentemployee_idx` (`departmentId`),
  KEY `subdepartemployee_idx` (`subdepartmentId`) /*!80000 INVISIBLE */,
  KEY `positionemployee_idx` (`positionId`),
  CONSTRAINT `departmentemployee` FOREIGN KEY (`departmentId`) REFERENCES `department` (`id`),
  CONSTRAINT `positionemployee` FOREIGN KEY (`positionId`) REFERENCES `position` (`id`),
  CONSTRAINT `subdepartemployee` FOREIGN KEY (`subdepartmentId`) REFERENCES `subdepartment` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Employee 1','11111','1@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','081100000',1,1,1,'2021-01-09 00:00:00',NULL),(2,'Employee 2','22222','2@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','0811100000',2,1,1,'2021-01-09 00:00:00',NULL),(3,'Employee 3','33333','3@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','0811300000',1,2,1,'2021-01-09 00:00:00',NULL),(4,'Employee4','44444','4@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','0814000000',2,2,1,'2021-01-09 00:00:00',NULL),(5,'Employee 5','55555','5@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','081500000',1,1,1,'2021-01-09 00:00:00',NULL),(6,'Employee 6','66666','6@gmail.com','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','0816000000',3,1,1,'2021-01-09 00:00:00',NULL),(7,'Susandi Sofyan','5758','susandi.sofyan@megah-perkasa.co.id','9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08','0856100000',3,3,9,'2021-01-14 00:00:00',NULL);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `globalbehavior`
--

DROP TABLE IF EXISTS `globalbehavior`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `globalbehavior` (
  `id` int NOT NULL AUTO_INCREMENT,
  `performanceappraisalid` bigint NOT NULL,
  `expectedbehavior` varchar(200) NOT NULL,
  `demonstratedbehavior` varchar(200) DEFAULT NULL,
  `employeescore` varchar(10) DEFAULT NULL,
  `managerscore` varchar(10) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `perfappgb_idx` (`performanceappraisalid`),
  CONSTRAINT `perfappgb` FOREIGN KEY (`performanceappraisalid`) REFERENCES `performanceappraisal` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `globalbehavior`
--

LOCK TABLES `globalbehavior` WRITE;
/*!40000 ALTER TABLE `globalbehavior` DISABLE KEYS */;
INSERT INTO `globalbehavior` VALUES (1,3,'exp 1','Demo 1','2',NULL,'2021-02-03 06:25:30'),(2,3,'exp 2','Demo 2','3',NULL,'2021-02-03 06:25:30'),(3,3,'Exp 3','Demo 3','1',NULL,'2021-02-03 06:25:30'),(4,3,'Exp 4','Demo 4','3',NULL,'2021-02-03 06:25:30');
/*!40000 ALTER TABLE `globalbehavior` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `managerial`
--

DROP TABLE IF EXISTS `managerial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `managerial` (
  `id` int NOT NULL AUTO_INCREMENT,
  `employeeid` int NOT NULL,
  `departmentId` int DEFAULT NULL,
  `name` varchar(200) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `managerial_idx` (`departmentId`),
  KEY `managerialemployee_idx` (`employeeid`),
  CONSTRAINT `managerialdepartment` FOREIGN KEY (`departmentId`) REFERENCES `department` (`id`),
  CONSTRAINT `managerialemployee` FOREIGN KEY (`employeeid`) REFERENCES `employee` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `managerial`
--

LOCK TABLES `managerial` WRITE;
/*!40000 ALTER TABLE `managerial` DISABLE KEYS */;
/*!40000 ALTER TABLE `managerial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `managerialstaff`
--

DROP TABLE IF EXISTS `managerialstaff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `managerialstaff` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `managerialid` int NOT NULL,
  `employeeid` int NOT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `managerial_idx` (`managerialid`),
  KEY `staffemployee_idx` (`employeeid`),
  CONSTRAINT `managerial` FOREIGN KEY (`managerialid`) REFERENCES `managerial` (`id`) ON DELETE RESTRICT,
  CONSTRAINT `staffemployee` FOREIGN KEY (`employeeid`) REFERENCES `employee` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `managerialstaff`
--

LOCK TABLES `managerialstaff` WRITE;
/*!40000 ALTER TABLE `managerialstaff` DISABLE KEYS */;
/*!40000 ALTER TABLE `managerialstaff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mobilitycode`
--

DROP TABLE IF EXISTS `mobilitycode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mobilitycode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `code` varchar(20) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mobilitycode`
--

LOCK TABLES `mobilitycode` WRITE;
/*!40000 ALTER TABLE `mobilitycode` DISABLE KEYS */;
INSERT INTO `mobilitycode` VALUES (1,'M','Mobile','2021-02-03 00:00:00',NULL),(2,'PM','Partially Mobile','2021-02-03 00:00:00',NULL),(3,'NM','Not Mobile','2021-02-03 00:00:00',NULL);
/*!40000 ALTER TABLE `mobilitycode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `performanceappraisal`
--

DROP TABLE IF EXISTS `performanceappraisal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `performanceappraisal` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `employeeid` int NOT NULL,
  `bonumericscore` varchar(10) DEFAULT NULL,
  `bodescriptivescore` varchar(200) DEFAULT NULL,
  `gbnumericscore` varchar(10) DEFAULT NULL,
  `gbdescriptivescore` varchar(200) DEFAULT NULL,
  `overallnumericscore` varchar(10) DEFAULT NULL,
  `overalldescriptivescore` varchar(200) DEFAULT NULL,
  `mobilityId` int DEFAULT NULL,
  `mobilitydesc` varchar(200) DEFAULT NULL,
  `careeraspirationcomment` varchar(500) DEFAULT NULL,
  `employeecomment` varchar(500) DEFAULT NULL,
  `managercomment` varchar(500) DEFAULT NULL,
  `2ndlvlmanagercomment` varchar(500) DEFAULT NULL,
  `statusid` int DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `perfappemployee_idx` (`employeeid`),
  KEY `perfappmobility_idx` (`mobilityId`),
  KEY `perfappstatus_idx` (`statusid`),
  CONSTRAINT `perfappemployee` FOREIGN KEY (`employeeid`) REFERENCES `employee` (`id`),
  CONSTRAINT `perfappmobility` FOREIGN KEY (`mobilityId`) REFERENCES `mobilitycode` (`id`),
  CONSTRAINT `perfappstatus` FOREIGN KEY (`statusid`) REFERENCES `statuscode` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `performanceappraisal`
--

LOCK TABLES `performanceappraisal` WRITE;
/*!40000 ALTER TABLE `performanceappraisal` DISABLE KEYS */;
INSERT INTO `performanceappraisal` VALUES (3,7,'2.00','Meets Expectation','2.25','Meets Expectations','2.125','Meets Expectations',2,'test','aspirasi','1','2','3',2,'2021-02-03 06:24:43',NULL);
/*!40000 ALTER TABLE `performanceappraisal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `position`
--

DROP TABLE IF EXISTS `position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `position` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `level` int DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `position`
--

LOCK TABLES `position` WRITE;
/*!40000 ALTER TABLE `position` DISABLE KEYS */;
INSERT INTO `position` VALUES (1,'Staff','Posisi Staff',NULL,'2020-01-06 00:00:00',NULL),(2,'Supervisor','Posisi Supervisor',NULL,'2020-01-06 00:00:00',NULL),(3,'Kepala Bagian','Posisi Kepala Bagian',NULL,'2020-01-06 00:00:00',NULL),(4,'Kepala Divisi','Posisi Kepala Divisi',NULL,'2020-01-06 00:00:00',NULL);
/*!40000 ALTER TABLE `position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuscode`
--

DROP TABLE IF EXISTS `statuscode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statuscode` (
  `id` int NOT NULL AUTO_INCREMENT,
  `description` varchar(100) NOT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuscode`
--

LOCK TABLES `statuscode` WRITE;
/*!40000 ALTER TABLE `statuscode` DISABLE KEYS */;
INSERT INTO `statuscode` VALUES (1,'PROGRESS','2021-01-21 00:00:00',NULL),(2,'SUBMITTED','2021-01-21 00:00:00',NULL),(3,'AUDITED','2021-01-21 00:00:00',NULL),(4,'APPROVED','2021-01-21 00:00:00',NULL);
/*!40000 ALTER TABLE `statuscode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subdepartment`
--

DROP TABLE IF EXISTS `subdepartment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subdepartment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `departmentid` int NOT NULL,
  `createdate` datetime DEFAULT NULL,
  `updatedate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `departmentsub_idx` (`departmentid`),
  CONSTRAINT `departmentsub` FOREIGN KEY (`departmentid`) REFERENCES `department` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subdepartment`
--

LOCK TABLES `subdepartment` WRITE;
/*!40000 ALTER TABLE `subdepartment` DISABLE KEYS */;
INSERT INTO `subdepartment` VALUES (1,'Infrastructure','IT Infrastructure',1,'2020-01-06 00:00:00',NULL),(2,'Web Development','IT Web Development',1,'2020-01-06 00:00:00',NULL),(3,'Mobile Development','IT Mobile Development',1,'2020-01-06 00:00:00',NULL),(4,'Front End Development','IT Frontend Development',1,'2020-01-06 00:00:00',NULL),(5,'Research','IT Research',1,'2020-01-06 00:00:00',NULL),(6,'Accounting','Finance Accounting',2,'2020-01-06 00:00:00',NULL),(7,'Tax','Finance Tax',2,'2020-01-06 00:00:00',NULL),(8,'Payroll','Finance Payroll',2,'2020-01-06 00:00:00',NULL),(9,'Marketing','Sales Marketing',3,'2020-01-06 00:00:00',NULL),(10,'Sales','Sales',3,'2020-01-06 00:00:00',NULL);
/*!40000 ALTER TABLE `subdepartment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userlog`
--

DROP TABLE IF EXISTS `userlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userlog` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `description` varchar(500) DEFAULT NULL,
  `createdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userlog`
--

LOCK TABLES `userlog` WRITE;
/*!40000 ALTER TABLE `userlog` DISABLE KEYS */;
/*!40000 ALTER TABLE `userlog` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-17 10:52:43
