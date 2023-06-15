-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 15, 2023 at 10:39 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `atm`
--

-- --------------------------------------------------------

--
-- Table structure for table `bank_account`
--

CREATE TABLE `bank_account` (
  `bank_number` int(22) NOT NULL,
  `cash_available` int(11) NOT NULL,
  `id_personne` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `bank_account`
--

INSERT INTO `bank_account` (`bank_number`, `cash_available`, `id_personne`) VALUES
(159357, 0, 12345);

-- --------------------------------------------------------

--
-- Table structure for table `card_b`
--

CREATE TABLE `card_b` (
  `card_number` bigint(16) NOT NULL,
  `Pin` int(4) NOT NULL,
  `date_d'expiration` date NOT NULL,
  `id_personne` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `card_b`
--

INSERT INTO `card_b` (`card_number`, `Pin`, `date_d'expiration`, `id_personne`) VALUES
(1234567891234567, 1235, '2023-06-30', 12345);

-- --------------------------------------------------------

--
-- Table structure for table `personne`
--

CREATE TABLE `personne` (
  `name` varchar(10) NOT NULL,
  `ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `personne`
--

INSERT INTO `personne` (`name`, `ID`) VALUES
('melek', 12345),
('semi', 14725);

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `id_personne` int(11) NOT NULL,
  `Id_pers` int(11) NOT NULL,
  `cash` int(11) NOT NULL,
  `id_transaction` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`id_personne`, `Id_pers`, `cash`, `id_transaction`) VALUES
(12345, 14725, 10, 1),
(14725, 12345, 20, 2);

-- --------------------------------------------------------

--
-- Table structure for table `withdraw`
--

CREATE TABLE `withdraw` (
  `card_number` bigint(16) NOT NULL,
  `id_personne` int(11) NOT NULL,
  `bank_number` int(22) NOT NULL,
  `cash` int(11) NOT NULL,
  `id_withdraw` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `withdraw`
--

INSERT INTO `withdraw` (`card_number`, `id_personne`, `bank_number`, `cash`, `id_withdraw`) VALUES
(1234567891234567, 12345, 159357, 0, 1),
(1234567891234567, 12345, 159357, 0, 2),
(1234567891234567, 12345, 159357, 0, 3),
(1234567891234567, 12345, 159357, 0, 4),
(1234567891234567, 12345, 159357, 50, 5),
(1234567891234567, 12345, 159357, 10, 6),
(1234567891234567, 12345, 159357, 50, 7),
(1234567891234567, 12345, 159357, 10, 8),
(1234567891234567, 12345, 159357, 10, 9),
(1234567891234567, 12345, 159357, 50, 10),
(1234567891234567, 12345, 159357, 10, 11),
(1234567891234567, 12345, 159357, 50, 12),
(1234567891234567, 12345, 159357, 10, 13),
(1234567891234567, 12345, 159357, 20, 14),
(1234567891234567, 12345, 159357, 100, 15),
(1234567891234567, 12345, 159357, 10, 16),
(1234567891234567, 12345, 159357, 100, 17);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bank_account`
--
ALTER TABLE `bank_account`
  ADD PRIMARY KEY (`bank_number`),
  ADD KEY `id_personne` (`id_personne`),
  ADD KEY `bank_number` (`bank_number`);

--
-- Indexes for table `card_b`
--
ALTER TABLE `card_b`
  ADD PRIMARY KEY (`card_number`),
  ADD KEY `id_personne` (`id_personne`),
  ADD KEY `card_number` (`card_number`);

--
-- Indexes for table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ID` (`ID`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`id_personne`,`Id_pers`,`id_transaction`),
  ADD KEY `Id_pers` (`Id_pers`),
  ADD KEY `id_personne` (`id_personne`),
  ADD KEY `id_transaction` (`id_transaction`);

--
-- Indexes for table `withdraw`
--
ALTER TABLE `withdraw`
  ADD PRIMARY KEY (`card_number`,`id_personne`,`bank_number`,`id_withdraw`),
  ADD KEY `id_personne` (`id_personne`),
  ADD KEY `bank_number` (`bank_number`),
  ADD KEY `card_number` (`card_number`),
  ADD KEY `id_withdraw` (`id_withdraw`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `id_transaction` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `withdraw`
--
ALTER TABLE `withdraw`
  MODIFY `id_withdraw` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bank_account`
--
ALTER TABLE `bank_account`
  ADD CONSTRAINT `bank_account_ibfk_1` FOREIGN KEY (`id_personne`) REFERENCES `personne` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `card_b`
--
ALTER TABLE `card_b`
  ADD CONSTRAINT `card_b_ibfk_1` FOREIGN KEY (`id_personne`) REFERENCES `personne` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`id_personne`) REFERENCES `personne` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`Id_pers`) REFERENCES `personne` (`ID`) ON DELETE CASCADE;

--
-- Constraints for table `withdraw`
--
ALTER TABLE `withdraw`
  ADD CONSTRAINT `withdraw_ibfk_1` FOREIGN KEY (`id_personne`) REFERENCES `personne` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `withdraw_ibfk_2` FOREIGN KEY (`bank_number`) REFERENCES `bank_account` (`bank_number`) ON DELETE CASCADE,
  ADD CONSTRAINT `withdraw_ibfk_3` FOREIGN KEY (`card_number`) REFERENCES `card_b` (`card_number`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
