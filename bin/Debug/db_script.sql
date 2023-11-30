
SET ANSI_NULLS ON
GO
use [master]

IF exists(select * from sys.databases where [name] ='oil_points')
begin
alter database [oil_points] set single_user with rollback IMMEDIATE;
drop database  [oil_points]
end
go
-- создаем БД
create database [oil_points]
go

use [oil_points]

-- создаем таблицу пользователей
CREATE TABLE Users
(
    UserID int IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL
)
go

-- добавляем 3-х пользвателй в таблицу
INSERT INTO [dbo].[Users] ([Username], [PasswordHash]) VALUES('Admin','wcIksDzZvHtqhtd/XazkAZF2bEhc1V3EjK+ayHMzXW8=') -- Admin
INSERT INTO [dbo].[Users] ([Username], [PasswordHash]) VALUES('User1','9uCh4qxBlFqap/+KiqoM68EqO8yYGpKa1c+BCgkOEa4=') -- 111
INSERT INTO [dbo].[Users] ([Username], [PasswordHash]) VALUES('User2','m4cVEjJ8Cc6R3WSbP5amO3QI7yZ8jMVxARTmKXMMth8=') -- 222

-- создаем таблицы событий для каждого узла (node)
CREATE TABLE [dbo].[node1_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO

CREATE TABLE [dbo].[node2_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO

CREATE TABLE [dbo].[node3_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO


    CREATE TABLE [dbo].[node1_critical_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO

CREATE TABLE [dbo].[node2_critical_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO

CREATE TABLE [dbo].[node3_critical_events](
	[id] [int] IDENTITY(1,1) NOT NULL,
    [Время] [datetime2] NULL,
	[Событие] [varchar](300) NULL
    )
    GO

----------------------------------------------

-- создаем таблицы часовых отчетов для каждого узла (node)
CREATE TABLE node1_reports (
[id] [int] IDENTITY(1,1) NOT NULL,
[Время] [datetime2] NULL,
[Линия] [int] NOT NULL,
[Средний расход] DECIMAL(18,2) NULL,
[Средняя температура]  DECIMAL(18,2) NULL, 
[Среднее давление] DECIMAL(18,2) NULL,
[Средняя плотность] DECIMAL(18,2) NULL,
[Средняя плотность при 20С] DECIMAL(18,2) NULL,
[Среднее объёмное содержание воды] float,
[Среднее массовое содержание воды] float,
[Объём при 20С] DECIMAL(18,2) NULL,
[Масса нефти при 20С] DECIMAL(18,2) NULL,
)
go

CREATE TABLE node2_reports (
[id] [int] IDENTITY(1,1) NOT NULL,
[Время] [datetime2] NULL,
[Линия] [int] NOT NULL,
[Средний расход] DECIMAL(18,2) NULL,
[Средняя температура]  DECIMAL(18,2) NULL, 
[Среднее давление] DECIMAL(18,2) NULL,
[Средняя плотность] DECIMAL(18,2) NULL,
[Средняя плотность при 20С] DECIMAL(18,2) NULL,
[Среднее объёмное содержание воды] float,
[Среднее массовое содержание воды] float,
[Объём при 20С] DECIMAL(18,2) NULL,
[Масса нефти при 20С] DECIMAL(18,2) NULL,
)
go

CREATE TABLE node3_reports (
[id] [int] IDENTITY(1,1) NOT NULL,
[Время] [datetime2] NULL,
[Линия] [int] NOT NULL,
[Средний расход] DECIMAL(18,2) NULL,
[Средняя температура]  DECIMAL(18,2) NULL, 
[Среднее давление] DECIMAL(18,2) NULL,
[Средняя плотность] DECIMAL(18,2) NULL,
[Средняя плотность при 20С] DECIMAL(18,2) NULL,
[Среднее объёмное содержание воды] float,
[Среднее массовое содержание воды] float,
[Объём при 20С] DECIMAL(18,2) NULL,
[Масса нефти при 20С] DECIMAL(18,2) NULL,
)
go
----------------------------------------------



-- создаем таблицы отчетов за период для каждого узла (node)
CREATE TABLE node1_reports_period
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    StartTime  [datetime2] NULL,
    EndTime  [datetime2] NULL,
    EnterpriseOwner VARCHAR(100) NULL,
    EnterpriseTransporter VARCHAR(100) NULL,
    QualityPassportNumber NVARCHAR(100),
    OilGrossMass float,
    AverageTemperature float,
    AveragePressure float,
    AverageDensityMeasurementConditions float,
    AverageDensity20Degrees float,
    Water float,
    MechanicalImpurities float,
    Sulfur float,
    BallastMass float,
    NetOilMass float
)
go

CREATE TABLE node2_reports_period
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    StartTime  [datetime2] NULL,
    EndTime  [datetime2] NULL,
    EnterpriseOwner VARCHAR(100) NULL,
    EnterpriseTransporter VARCHAR(100) NULL,
    QualityPassportNumber NVARCHAR(100),
    OilGrossMass float,
    AverageTemperature float,
    AveragePressure float,
    AverageDensityMeasurementConditions float,
    AverageDensity20Degrees float,
    Water float,
    MechanicalImpurities float,
    Sulfur float,
    BallastMass float,
    NetOilMass float
)
go

CREATE TABLE node3_reports_period
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    StartTime  [datetime2] NULL,
    EndTime  [datetime2] NULL,
    EnterpriseOwner VARCHAR(100) NULL,
    EnterpriseTransporter VARCHAR(100) NULL,
    QualityPassportNumber NVARCHAR(100),
    OilGrossMass float,
    AverageTemperature float,
    AveragePressure float,
    AverageDensityMeasurementConditions float,
    AverageDensity20Degrees float,
    Water float,
    MechanicalImpurities float,
    Sulfur float,
    BallastMass float,
    NetOilMass float
)
go

------------------------------------------------------------


-- создаем таблицы протоколов для каждого узла (node)
-- kmx_temperature
CREATE TABLE node1_kmx_temperature ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,2), SensorB DECIMAL(18,2), ContrSI DECIMAL(18,2), Difference DECIMAL(18,2))
go
CREATE TABLE node2_kmx_temperature ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,2), SensorB DECIMAL(18,2), ContrSI DECIMAL(18,2), Difference DECIMAL(18,2))
go
CREATE TABLE node3_kmx_temperature ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,2), SensorB DECIMAL(18,2), ContrSI DECIMAL(18,2), Difference DECIMAL(18,2))
-- kmx pressure
CREATE TABLE node1_kmx_pressure ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,4), SensorB DECIMAL(18,4), ContrSI DECIMAL(18,4), Difference DECIMAL(18,4))
go
CREATE TABLE node2_kmx_pressure ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,4), SensorB DECIMAL(18,4), ContrSI DECIMAL(18,4), Difference DECIMAL(18,4))
go
CREATE TABLE node3_kmx_pressure ([id] [int] IDENTITY(1,1) NOT NULL, CheckTime  [datetime2] NULL, ProtocolNumber int NOT NULL, LineID NVARCHAR(10) NOT NULL, SensorA DECIMAL(18,4), SensorB DECIMAL(18,4), ContrSI DECIMAL(18,4), Difference DECIMAL(18,4))
-- kmx density
CREATE TABLE node1_kmx_density (
    ID int IDENTITY(1,1) NOT NULL,
    CheckTime  [datetime2],
    ProtocolNumber int,
    MeasurementNumber int, 
    Temperature float,
    Pressure float,
    DensityAtConditions float,
    DensityAt20C float,
    DensityAtConditionsLab float,
    DensityAt20CLab float,
    DifferenceInDensityAtConditions float,
    DensityDifferenceAt20C float
)
go

CREATE TABLE node2_kmx_density (
    ID int IDENTITY(1,1) NOT NULL,
    CheckTime  [datetime2],
    ProtocolNumber int,
    MeasurementNumber int, 
    Temperature float,
    Pressure float,
    DensityAtConditions float,
    DensityAt20C float,
    DensityAtConditionsLab float,
    DensityAt20CLab float,
    DifferenceInDensityAtConditions float,
    DensityDifferenceAt20C float
)
go

CREATE TABLE node3_kmx_density (
    ID int IDENTITY(1,1) NOT NULL,
    CheckTime  [datetime2],
    ProtocolNumber int,
    MeasurementNumber int, 
    Temperature float,
    Pressure float,
    DensityAtConditions float,
    DensityAt20C float,
    DensityAtConditionsLab float,
    DensityAt20CLab float,
    DifferenceInDensityAtConditions float,
    DensityDifferenceAt20C float
)
go

-- oil quility protocol

CREATE TABLE node1_oil_quality_passport
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    [Время] datetime DEFAULT GETDATE(),
    [Номер паспорта] int,
    [Поставщик] varchar(100),
    [Температура] float,
    [Давление] float,
    [Плотность] float,
    [Плотность при 20°C] float,
    [Массовая доля воды] float,
    [Массовая доля мех. примесей] float,
    [Массовая доля серы] float,
    [Массовая доля парафина] float,
    [Массовая доля сероводорода] float
)
go

CREATE TABLE node2_oil_quality_passport
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    [Время] datetime DEFAULT GETDATE(),
    [Номер паспорта] int,
    [Поставщик] varchar(100),
    [Температура] float,
    [Давление] float,
    [Плотность] float,
    [Плотность при 20°C] float,
    [Массовая доля воды] float,
    [Массовая доля мех. примесей] float,
    [Массовая доля серы] float,
    [Массовая доля парафина] float,
    [Массовая доля сероводорода] float
)
go

CREATE TABLE node3_oil_quality_passport
(
    Id int IDENTITY(1,1) PRIMARY KEY,
    [Время] datetime DEFAULT GETDATE(),
    [Номер паспорта] int,
    [Поставщик] varchar(100),
    [Температура] float,
    [Давление] float,
    [Плотность] float,
    [Плотность при 20°C] float,
    [Массовая доля воды] float,
    [Массовая доля мех. примесей] float,
    [Массовая доля серы] float,
    [Массовая доля парафина] float,
    [Массовая доля сероводорода] float
)
go



