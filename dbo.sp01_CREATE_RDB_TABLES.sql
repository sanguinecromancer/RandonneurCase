

CREATE PROCEDURE sp01_CREATE_RDB_TABLES

AS


CREATE TABLE Brevet
(
  brevetId     INTEGER     NOT NULL,
  distance   INTEGER  NOT NULL,
  brevetDate    DATE NOT NULL,
  location     VARCHAR(50) NOT NULL,
  climbing        INTEGER NOT NULL,

  CONSTRAINT PK_Brevet PRIMARY KEY (brevetId),
  CONSTRAINT CHK_Brevet_brevetId CHECK(brevetId BETWEEN 10 AND 9999),
  CONSTRAINT CHK_Brevet_distance CHECK(distance = 200 OR distance = 300 OR distance = 400 OR distance = 600 OR
  distance = 1000 OR distance = 2000),
  CONSTRAINT CHK_Brevet_climbing CHECK(climbing BETWEEN 0 AND 9999),
);

CREATE TABLE Brevet_Rider
(
riderId     INTEGER     NOT NULL,
  brevetId   INTEGER  NOT NULL,
  isCompleted    CHAR(1)  NOT NULL,
  finishingTime  CHAR(5) NOT NULL,
  
  
  CONSTRAINT FK_Brevet_Rider_Rider FOREIGN KEY (riderId) REFERENCES Rider(riderId),
  CONSTRAINT FK_Brevet_Rider_Brevet FOREIGN KEY (brevetId) REFERENCES Brevet(brevetId),
  CONSTRAINT CHK_Brevet_Rider_isCompleted CHECK(isCompleted = 'Y' OR isCompleted ='N' )
);

CREATE TABLE Club
(
          clubId     INTEGER     NOT NULL,
  clubName  VARCHAR(50)  NOT NULL,
  city    VARCHAR(50)  NOT NULL,
  email  VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Club PRIMARY KEY (clubId),
  CONSTRAINT AK_Club UNIQUE (clubName),
  CONSTRAINT CHK_Club_clubId CHECK(clubId BETWEEN 101 AND 9999),


);

CREATE TABLE Rider
(
         riderId     INTEGER     NOT NULL,
  familyName  VARCHAR(50)  NOT NULL,
  givenName  VARCHAR(50)  NOT NULL,
  gender    CHAR(1)  NOT NULL,
  email  VARCHAR(50) NOT NULL,
  phone  VARCHAR(50) NOT NULL,
  clubId INTEGER NOT NULL,
  username  VARCHAR(20) NOT NULL,
  password  VARCHAR(20) NOT NULL,
  role VARCHAR(20) NOT NULL,
  CONSTRAINT PK_Rider PRIMARY KEY (riderId),
  CONSTRAINT FK_Rider_Club FOREIGN KEY (clubId) REFERENCES Club(clubId),
  CONSTRAINT AK_Rider UNIQUE (username),
  CONSTRAINT CHK_Rider_riderId CHECK(riderId BETWEEN 10 AND 99999),
  CONSTRAINT CHK_Rider_gender CHECK(gender = 'F' or gender = 'M'),
  CONSTRAINT CHK_Rider_role CHECK(role = 'user' or role = 'admin'),
);











-- Finally, display a message
IF (@@Error = 0) 
  BEGIN
    PRINT '======================================'
    PRINT ' TAKKULA TABLES CREATED SUCCESSFULLY.'
    PRINT '======================================'
    PRINT ' '
  END

-- End --