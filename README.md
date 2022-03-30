# .NET-BijithVS
architecture used:onion architecture

POST
​/api​/Survivor​/CreateSurvivor--Create and update api for Survivor(pass id for update,we can update location and witness count)

POST
​/api​/Survivor​/CreateSurvivorInventory--Create api for Survivor inventory

GET
​/api​/Survivor​/Infected--List of infected

GET
​/api​/Survivor​/UnInfected--List of infected

GET
​/api​/Survivor​/InfectedInPercentage--percentage of infected 

GET
​/api​/Survivor​/UnInfectedInPercentage--percentage of uninfected 

GET
​/api​/Survivor​/GetAllRobots--Get api for fetching details of robots

table structure for api--
survivor--
CREATE TABLE `survivors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(256) COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Age` int(11) NOT NULL,
  `Location` varchar(256) COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gender` varchar(256) COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NoOfWitness` int(11) DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci

survivor inventory--
CREATE TABLE `survivorinventory` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `SurvivorId` int(11) NOT NULL,
  `ResourcesName` varchar(256) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `QuantityinGram` int(11) DEFAULT NULL,
  `Created` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
