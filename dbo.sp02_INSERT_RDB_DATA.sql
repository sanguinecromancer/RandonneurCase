CREATE PROCEDURE sp02_INSERT_RDB_DATA

AS

DELETE FROM Club;
DELETE FROM Brevet_Rider;
DELETE FROM Brevet;
DELETE FROM Rider;


INSERT INTO Club (clubId, clubName, city, email)
VALUES 
(208, 'KFK',    'Oulu','kfk@yahoo.com'),
(209, 'RocketRider',     'Keski-Suomi', 'rocketrider@yahoo.com'),
(210, 'DreamWheel', 'Muhos', 'dreamwheel@yahoo.com'),
(211, 'CycleAgainstCancer',    'Reisjarvi', 'cycleagainstcancer@new.com'),
(213, 'Pyorailijat', 'Kokkola', 'pyorailijat@gmail.com');

INSERT INTO Brevet (brevetId, distance, brevetDate, location, climbing)
VALUES 
(51, 400,    '2007-08-01',   'Porvoo', 150),
(52, 400,     '2008-08-02', 'Reisjarvi', 150),
(53, 400, '2010-08-06',     'Hameenlinna', 300),
(54, 600,    '2010-08-03', 'Tampere', 300),
(55, 600,    '2010-08-07', 'Turku', 300),
(56, 600,    '2013-08-01', 'Haukipudas', 400),
(57, 300,    '2014-08-08', 'Tuusula', 400),
(58, 600,    '2014-08-08', 'Jarvenpaa', 400);

INSERT INTO Rider 
(riderId, familyName, givenName, gender, email, phone, clubId, username, password, role)
 VALUES
 (321, 'User', 'user', 'M', 'gg@gmail.com', '0000', 208, 'User','user', 'user'),
 (320, 'Admin', 'admin', 'M', 'zeynepaykal@gmail.com', '0000', 209, 'Admin','admin', 'admin'),
(300, 'Gustavsson', 'Geoffrey', 'M', 'g.g@yahoo.com', '0345323', 208, 'Geoffrey','geoffrey', 'user'),
(301, 'Lambert', 'Alex', 'M', 'eget.ipsum@neque.net', '4923439', 209, 'Alex','alex', 'user'),
(302, 'Rasmussen', 'Laura', 'F', 'l.r@neque.net', '05342344', 209, 'Laura','laura', 'user'),
(303, 'Stark', 'Owen', 'M', 's.o@neque.net', '04534523', 209, 'Owen','owen', 'user'),
(304, 'Lannister', 'Tyrion', 'M', 'l.t@neque.net', '245454345', 210, 'Tyrion','tyrion', 'admin'),
(305, 'Baratheon', 'Robert', 'F', 'litora.torquent@semmagnanec.ca', '04045345', 210, 'Robert','robert', 'user'),
(306, 'Kline', 'Gustav', 'M', 'g.k@semmagnanec.ca', '034534234', 210, 'Kline','kline', 'user'),
(307, 'Tyrell', 'Olena','F', 'o.t@semmagnanec.ca', '0345345234', 208, 'Olena','olena', 'user'),
(308, 'Tyrell', 'Myrcela','F', 'sit@diamat.ca', '023423435', 211, 'Myrcela','myrcela', 'user'),
(309, 'Fredrik', 'Trevor', 'M', 'm.t@diamat.ca', '067564563', 211, 'Huber','huber', 'user'),
(310, 'Huber', 'Sean', 'M', 'sh@diamat.ca', '453452342', 210, 'Sean','sean', 'user'),
(311, 'Riley', 'Rachel', 'F', 'rrr@diamat.ca', '12312423', 213, 'Rachel','rachel', 'user'),
(312, 'Herman', 'Linda', 'F', 'herman@diamat.ca', '78967865', 211, 'Linda','linda', 'user'),
(313, 'Rossmann', 'Linus', 'M', 'risus.varius@egetmagna.org', '22323232',208,  'Rosman','rosman', 'user'),
(314, 'Bergen', 'Jens', 'M', 'jens@egetmagna.org', '345345345', 211, 'Jens','jens', 'user'),
(315, 'Vang', 'Daniel', 'M', 'rvargs@egetmagna.org', '234234234', 208, 'Daniel','daniel', 'user'),
(316, 'Vikernes', 'Niklas', 'M', 'niklas@egetmagna.org', '546456456', 211, 'Niklas','niklas', 'user'),
(317, 'Leblanc', 'Anna', 'F', 'anna@egetmagna.org', '654654565', 213, 'Anna','anna', 'user'),
(318, 'Faulkner', 'Reuben', 'M', 'reuben@egetmagna.org', '26465465', 213, 'Reuben','reuben', 'user'),
(319, 'Holtz', 'Pieter', 'M', 'pieter@egetmagna.org', '465646345', 211, 'Pieter','pieter', 'user');


INSERT INTO Brevet_Rider 
(riderId, brevetId, isCompleted, finishingTime)
 VALUES 
(300, 51, 'Y', '59:00'),
(301, 51, 'Y', '59:00'),
(302, 51, 'Y', '59:00'),
(303, 52, 'Y', '59:00'),
(304, 52, 'Y', '59:00'),
(305, 52, 'Y', '59:00'),
(306, 58, 'Y', '59:00'),
(307, 53, 'Y', '59:00'),
(308, 53, 'Y', '59:00'),
(309, 53, 'Y', '59:00'),
(310, 53, 'Y', '59:00'),
(311, 53, 'Y', '59:00'),
(312, 54, 'Y', '59:00'),
(313, 54, 'Y', '59:00'),
(314, 57, 'Y', '59:00'),
(315, 54, 'Y', '59:00'),
(316, 54, 'Y', '59:00'),
(317, 54, 'Y', '59:00'),
(318, 55, 'Y', '59:00'),
(319, 55, 'N', '59:00'),
(301, 58, 'N', '59:00'),
(303, 56, 'N', '59:00'),
(304, 56, 'N', '59:00'),
(305, 57, 'N', '59:00'),
(306, 57, 'N', '59:00');

IF (@@Error = 0) 
  BEGIN
    PRINT '=========================================='
    PRINT ' RANDONNEUR TEST DATA INSERTED SUCCESSFULLY.'
    PRINT '=========================================='
    PRINT ' '
  END
ELSE
  BEGIN
    PRINT '==========================================='
    PRINT ' INSERTING TEST DATA FAILED!'
    PRINT ' See the error messages above.'
    PRINT ' '
    PRINT ' (Maybe Brevet tables do not exist yet?)'
    PRINT '==========================================='
    PRINT ' '
  END

-- End --