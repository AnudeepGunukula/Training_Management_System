
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2021 12:45:17
-- Generated from EDMX file: C:\Users\anude\source\repos\AnudeepGunukula\Training_Management_System\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrainingDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TrainingDetails'
CREATE TABLE [dbo].[TrainingDetails] (
    [TrainingId] int IDENTITY(1,1) NOT NULL,
    [TrainingName] nvarchar(max)  NOT NULL,
    [Technology] nvarchar(max)  NOT NULL,
    [ExpectedStartDate] datetime  NOT NULL,
    [ExpectedDurationInHours] int  NOT NULL,
    [TotalDuration] nvarchar(max)  NOT NULL,
    [ExpectedEndDate] DateTime  NOT NULL,
    [TrainingType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Attendences'
CREATE TABLE [dbo].[Attendences] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TraineeName] nvarchar(max)  NOT NULL,
    [TrainingName] nvarchar(max)  NOT NULL,
    [Attendance] bit  NOT NULL,
    [Date] datetime  NOT NULL,
    [EmpId] int  NOT NULL
);
GO

-- Creating table 'Trainees'
CREATE TABLE [dbo].[Trainees] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [CertificationType] nvarchar(max)  NOT NULL,
    [TrainingType] nvarchar(max)  NOT NULL,
    [TrainingFrom] nvarchar(max)  NOT NULL,
    [Score] int NOT NULL,
    [IsCertified] bit  NOT NULL,
    [NumberOfAttempt] int  NOT NULL,
    [TrainingId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TrainingId] in table 'TrainingDetails'
ALTER TABLE [dbo].[TrainingDetails]
ADD CONSTRAINT [PK_TrainingDetails]
    PRIMARY KEY CLUSTERED ([TrainingId] ASC);
GO

-- Creating primary key on [Id] in table 'Attendences'
ALTER TABLE [dbo].[Attendences]
ADD CONSTRAINT [PK_Attendences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EmpId] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [PK_Trainees]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmpId] in table 'Attendences'
ALTER TABLE [dbo].[Attendences]
ADD CONSTRAINT [FK_TraineeAttendence]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Trainees]
        ([EmpId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TraineeAttendence'
CREATE INDEX [IX_FK_TraineeAttendence]
ON [dbo].[Attendences]
    ([EmpId]);
GO

-- Creating foreign key on [TrainingId] in table 'Trainees'
ALTER TABLE [dbo].[Trainees]
ADD CONSTRAINT [FK_TrainingDetailsTrainee]
    FOREIGN KEY ([TrainingId])
    REFERENCES [dbo].[TrainingDetails]
        ([TrainingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingDetailsTrainee'
CREATE INDEX [IX_FK_TrainingDetailsTrainee]
ON [dbo].[Trainees]
    ([TrainingId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------