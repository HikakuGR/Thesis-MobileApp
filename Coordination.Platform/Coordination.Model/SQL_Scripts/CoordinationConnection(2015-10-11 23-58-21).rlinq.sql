-- Coordination.Model.Job
CREATE TABLE [Job] (
    [Longitude] varchar(255) NULL,          -- _longitude
    [Latitude] varchar(255) NULL,           -- _latitude
    [JobName] varchar(255) NULL,            -- _jobName
    [ID] int IDENTITY NOT NULL,             -- _iD
    [Description] varchar(255) NULL,        -- _description
    [Completed] tinyint NULL,               -- _completed
    [Assigned] tinyint NULL,                -- _assigned
    CONSTRAINT [pk_Job] PRIMARY KEY ([ID])
)
go

-- Coordination.Model.User
CREATE TABLE [usr] (
    [Username] varchar(255) NULL,           -- _username
    [passwd] varchar(255) NULL,             -- _password
    [Longitude] varchar(255) NULL,          -- _longitude
    [Latitude] varchar(255) NULL,           -- _latitude
    [ID] int IDENTITY NOT NULL,             -- _iD
    [Email] varchar(255) NULL,              -- _email
    CONSTRAINT [pk_usr] PRIMARY KEY ([ID])
)
go

-- System.Collections.Generic.IList`1 Coordination.Model.User._jobs
CREATE TABLE [usr_Job] (
    [ID] int NOT NULL,
    [ID2] int NOT NULL,
    CONSTRAINT [pk_usr_Job] PRIMARY KEY ([ID], [ID2])
)
go

CREATE INDEX [idx_usr_Job_ID2] ON [usr_Job]([ID2])
go

ALTER TABLE [usr_Job] ADD CONSTRAINT [ref_usr_Job_usr] FOREIGN KEY ([ID]) REFERENCES [usr]([ID])
go

ALTER TABLE [usr_Job] ADD CONSTRAINT [ref_usr_Job_Job] FOREIGN KEY ([ID2]) REFERENCES [Job]([ID])
go

