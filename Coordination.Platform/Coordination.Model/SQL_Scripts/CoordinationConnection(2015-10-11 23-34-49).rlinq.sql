-- System.Collections.Generic.IList`1 Coordination.Model.User._jobs
CREATE TABLE [UsersJobs] (
    [ID] int NOT NULL,
    [ID2] int NOT NULL,
    CONSTRAINT [pk_UsersJobs] PRIMARY KEY ([ID], [ID2])
)

go

ALTER TABLE [UsersJobs] ADD CONSTRAINT [ref_UsersJobs_usr] FOREIGN KEY ([ID]) REFERENCES [usr]([ID])

go

ALTER TABLE [UsersJobs] ADD CONSTRAINT [ref_UsersJobs_Job] FOREIGN KEY ([ID2]) REFERENCES [Job]([ID])

go

-- Index 'idx_UsersJobs_ID2' was not detected in the database. It will be created
CREATE INDEX [idx_UsersJobs_ID2] ON [UsersJobs]([ID2])

go

