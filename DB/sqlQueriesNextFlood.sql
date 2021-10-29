-- Database Creation: nextflooddb
CREATE SCHEMA `nextflooddb` ;

-- Table Creation: markerpoints
CREATE TABLE `nextflooddb`.`markerpoints` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `UserID` TEXT NOT NULL,
  `DateAdded` DATETIME NOT NULL,
  `ExpiresAfter` DATETIME NOT NULL,
  `Latitude` VARCHAR(50) NOT NULL,
  `Longitude` VARCHAR(50) NOT NULL,
  `Description` VARCHAR(500) NULL,
  `Severity` VARCHAR(10) NULL,
  `ImageURL` TEXT NULL,
  `VideoURL` TEXT NULL,
  PRIMARY KEY (`ID`),
  INDEX `latitude_longitude_dateadded_expiresafter_idx` (`DateAdded` ASC, `ExpiresAfter` ASC, `Latitude` ASC, `Longitude` ASC) VISIBLE);

-- Test data insertion
INSERT INTO `nextflooddb`.`markerpoints` (`ID`, `UserID`, `DateAdded`, `ExpiresAfter`, `Latitude`, `Longitude`, `ImageURL`) VALUES ('1', '123', '2020-09-14 23:18:17', '2021-12-30 23:18:17', '29.715981', '-95.428841', 'https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iUM87hW9S7rI/v1/1000x-1.jpg');

-- Fetching data from markerpoints table
SELECT * FROM nextflooddb.markerpoints;

--Stored Procedure: GetAllMarkerpoints which will be used by the API
USE `nextflooddb`;
DROP procedure IF EXISTS `GetAllMarkerpoints`;

DELIMITER $$
CREATE PROCEDURE `GetAllMarkerpoints` ()
BEGIN
    SELECT * FROM `markerpoints`;
END$$
DELIMITER ;


--Stored Procedure: GetMarkerpointsBySeverity which will be used by the API
USE `nextflooddb`;
DROP procedure IF EXISTS `GetMarkerpointsBySeverity`;

DELIMITER $$
CREATE PROCEDURE `GetMarkerpointsBySeverity`(IN param_severity VARCHAR(10))
    BEGIN
        SELECT * FROM `markerpoints` WHERE Severity = param_severity;
    END
$$
DELIMITER ;

