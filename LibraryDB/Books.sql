CREATE TABLE [dbo].[Books]
(
	[isbn] BIGINT NOT NULL PRIMARY KEY,
    [title] VARCHAR(255) NOT NULL,
	[authors] VARCHAR(255) NOT NULL,
	[publisher] VARCHAR(255) NOT NULL,
	[releaseDate] DATE NOT NULL,
	
	[borrowerFirstName] VARCHAR(255),
	[borrowerLastName] VARCHAR(255),
	[borrowDate] DATE,
	[shouldReturn] DATE,
)
