CREATE TABLE [dbo].[Books]
(
	[isbn] BIGINT NOT NULL PRIMARY KEY,
    [title] VARCHAR(255) NOT NULL,
	[authors] VARCHAR(255) NOT NULL,
	[publisher] VARCHAR(255) NOT NULL,
	[release_date] DATE NOT NULL,
	
	[borrower_first_name] VARCHAR(255),
	[borrower_last_name] VARCHAR(255),
	[borrow_date] DATE,
	[should_return] DATE,
)
